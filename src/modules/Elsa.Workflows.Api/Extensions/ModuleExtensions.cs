using Elsa.Features.Services;
using Elsa.Workflows.Api.Features;

// ReSharper disable once CheckNamespace
namespace Elsa.Extensions;

/// <summary>
/// Provides extensions to <see cref="IModule"/>.
/// </summary>
public static class ModuleExtensions
{
    /// <summary>
    /// Configures the workflows API feature.
    /// </summary>
    public static IModule UseWorkflowsApi(this IModule module, Action<WorkflowsApiFeature>? configure = default)
    {
        module.Configure(configure);
        return module;
    }
}