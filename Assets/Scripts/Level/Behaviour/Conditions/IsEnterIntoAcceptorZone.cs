using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class IsEnterIntoAcceptorZone : Conditional
{
    public SharedAcceptor CurrentAcceptor;
    public SharedFloat WaitTime;

    public override TaskStatus OnUpdate()
    {
        if (CurrentAcceptor.Value.IsBusy == false)
            return TaskStatus.Running;

        WaitTime.Value = CurrentAcceptor.Value.PickUpTime;

        return TaskStatus.Failure;
    }
}
