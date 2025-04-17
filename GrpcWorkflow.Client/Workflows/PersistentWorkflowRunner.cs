using CoreWf;
using CoreWf.Hosting;
using CoreWf.Statements;

public class PersistentWorkflowRunner
{
    public static void Run()
    {
        var workflow = new Sequence
        {
            Activities =
            {
                new WriteLine { Text = "Persistent workflow start..." },
                new Delay { Duration = TimeSpan.FromSeconds(2) },
                new WriteLine { Text = "Persistent workflow end!" }
            }
        };

        var app = new WorkflowApplication(workflow);

        app.PersistableIdle = e => PersistableIdleAction.Unload;
        app.Unloaded = e => Console.WriteLine("Workflow unloaded.");
        app.Completed = e => Console.WriteLine("Workflow completed.");

        app.Run();
    }
}
