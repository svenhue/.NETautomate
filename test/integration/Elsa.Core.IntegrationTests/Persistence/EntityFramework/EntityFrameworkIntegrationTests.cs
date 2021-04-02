using Xunit;
using System.Threading.Tasks;
using Elsa.Core.IntegrationTests.Autofixture;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using Elsa.Services;
using Elsa.Core.IntegrationTests.Workflows;
using Elsa.Persistence;
using Elsa.Persistence.EntityFramework.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using Elsa.Persistence.EntityFramework.Core;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using Elsa.Testing.Shared.Helpers;

namespace Elsa.Core.IntegrationTests.Persistence.EntityFramework
{
    public class EntityFrameworkIntegrationTests
    {
        [Theory(DisplayName = "A persistable workflow instance with default persistence behaviour should be persisted-to and readable-from an Entity Framework store after being run"), AutoMoqData]
        public async Task APersistableWorkflowInstanceWithDefaultPersistanceBehaviourShouldBeRoundTrippable([WithPersistableWorkflow,WithEntityFramework] ElsaHostBuilderBuilder hostBuilderBuilder)
        {
            var hostBuilder = hostBuilderBuilder.GetHostBuilder();
            hostBuilder.ConfigureServices((ctx, services) => services.AddHostedService<HostedWorkflowRunner>());
            var host = await hostBuilder.StartAsync();
        }

        [Theory(DisplayName = "A resolved context should come from the pool when set up with pooling"), AutoMoqData]
        public void DbContextShouldBeCreatedFromPoolWhenSetUpWithPooling(ServiceCollection serviceCollection,
                                                                         [StubElsaContext] ElsaContext pooledContext,
                                                                         IDbContextPool<ElsaContext> pool)
        {
            serviceCollection
                .AddElsa(elsa => {
                    elsa
                        .UseEntityFrameworkPersistence(opts => {
                            opts.UseSqlite("Data Source=:memory:;Mode=Memory;");
                        });
                })
                .AddSingleton(pool);

            Mock.Get(pool).Setup(x => x.Rent()).Returns(pooledContext);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var contextFactory = serviceProvider.GetRequiredService<IDbContextFactory<ElsaContext>>();

            using(var context = contextFactory.CreateDbContext())
            {
                Assert.Same(pooledContext, context);
            }
        }

        [Theory(DisplayName = "A resolved context should not come from the pool when set up without pooling"), AutoMoqData]
        public void DbContextShouldNotBeCreatedFromPoolWhenSetUpWithoutPooling(ServiceCollection serviceCollection,
                                                                               [StubElsaContext] ElsaContext pooledContext,
                                                                               IDbContextPool<ElsaContext> pool)
        {
            serviceCollection
                .AddElsa(elsa => {
                    elsa
                        .UseNonPooledEntityFrameworkPersistence((services, opts) => {
                            opts.UseSqlite("Data Source=:memory:;Mode=Memory;");
                        },
                        ServiceLifetime.Transient);
                })
                .AddSingleton(pool);

            Mock.Get(pool).Setup(x => x.Rent()).Returns(pooledContext);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var contextFactory = serviceProvider.GetRequiredService<IDbContextFactory<ElsaContext>>();

            using(var context = contextFactory.CreateDbContext())
            {
                Assert.NotSame(pooledContext, context);
            }
        }

        class HostedWorkflowRunner : IHostedService
        {
            readonly IWorkflowRunner workflowRunner;
            readonly IWorkflowInstanceStore instanceStore;

            public async Task StartAsync(CancellationToken cancellationToken)
            {
                var instance = await workflowRunner.RunWorkflowAsync<PersistableWorkflow>();
                var retrievedInstance = await instanceStore.FindByIdAsync(instance.Id);

                Assert.NotNull(retrievedInstance);
            }

            public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

            public HostedWorkflowRunner(IWorkflowRunner workflowRunner, IWorkflowInstanceStore instanceStore)
            {
                this.workflowRunner = workflowRunner ?? throw new System.ArgumentNullException(nameof(workflowRunner));
                this.instanceStore = instanceStore ?? throw new System.ArgumentNullException(nameof(instanceStore));
            }
        }
    }
}