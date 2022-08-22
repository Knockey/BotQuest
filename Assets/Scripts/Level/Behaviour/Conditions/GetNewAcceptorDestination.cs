using BehaviorDesigner.Runtime.Tasks;

public class GetNewAcceptorDestination : Conditional
{
    public SharedAcceptorHandler AcceptorsHandler;
    public SharedAcceptor CurrentAcceptor;

    public override TaskStatus OnUpdate()
    {
        if (AcceptorsHandler.Value.TryGetIncompleteAcceptor(out Acceptor acceptor) == false)
            return TaskStatus.Failure;

        CurrentAcceptor.Value = acceptor;
        return TaskStatus.Success;
    }
}
