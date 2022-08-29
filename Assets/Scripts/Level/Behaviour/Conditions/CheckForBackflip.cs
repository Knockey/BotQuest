using BehaviorDesigner.Runtime.Tasks;

public class CheckForBackflip : Conditional
{
    public SharedAcceptorHandler AcceptorsHandler;
    public SharedBackpack Backpack;

    public override TaskStatus OnUpdate()
    {
        if (AcceptorsHandler.Value.TryGetIncompleteAcceptor(out Acceptor acceptor) == true || Backpack.Value.IsFull == true)
            return TaskStatus.Failure;

        return TaskStatus.Success;
    }
}
