using Elsa.Activities;
using Elsa.Contracts;
using Elsa.Modules.Activities.Console;
using Elsa.Modules.Activities.Primitives;

namespace Elsa.IntegrationTests.Activities;

public class JoinAnyForkWorkflow : IWorkflow
{
    public void Build(IWorkflowDefinitionBuilder workflow)
    {
        workflow.WithRoot(new Sequence
        {
            Activities =
            {
                new WriteLine("Start"),
                new Fork
                {
                    Branches =
                    {
                        new Sequence
                        {
                            Activities =
                            {
                                new Event("Event 1")
                                {
                                    Id = "Event1"
                                },
                                new WriteLine("Branch 1")
                            }
                        },
                        new Sequence
                        {
                            Activities =
                            {
                                new Event("Event 2")
                                {
                                    Id = "Event2"
                                },
                                new WriteLine("Branch 2")
                            }
                        },
                        new Sequence
                        {
                            Activities =
                            {
                                new Event("Event 3")
                                {
                                    Id = "Event3"
                                },
                                new WriteLine("Branch 3")
                            }
                        },
                    },
                    JoinMode = JoinMode.WaitAny
                },
                new WriteLine("End")
            }
        });
    }
}