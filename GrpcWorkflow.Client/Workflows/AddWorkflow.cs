using CoreWf;
using CoreWf.Statements;

public class AddWorkflow
{
    public static Activity Create()
    {
        return new Sequence
        {
            Variables =
            {
                new Variable<int>("a", ctx => 7),
                new Variable<int>("b", ctx => 5),
                new Variable<int>("result")
            },
            Activities =
            {
                new WriteLine { Text = "Running CoreWF Workflow..." },
                new Assign<int>
                {
                    To = new OutArgument<int>((ctx) => ctx.GetValue<int>("result")),
                    Value = new InArgument<int>((ctx) =>
                        ctx.GetValue<int>("a") + ctx.GetValue<int>("b"))
                },
                new WriteLine
                {
                    Text = new InArgument<string>(ctx =>
                        $"Workflow result: {ctx.GetValue<int>("result")}")
                }
            }
        };
    }
}
