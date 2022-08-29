using BehaviorDesigner.Runtime.Tasks;

public class GetNewAcceptorDestination : Conditional
{
    public SharedAcceptorHandler AcceptorsHandler;
    public SharedAcceptor CurrentAcceptor;
    public SharedBackpack Backpack;

    public override TaskStatus OnUpdate()
    {
        if (AcceptorsHandler.Value.TryGetIncompleteAcceptor(out Acceptor acceptor) == false || Backpack.Value.IsFull == false)
            return TaskStatus.Failure;

        CurrentAcceptor.Value = acceptor;
        return TaskStatus.Success;
    }
}
