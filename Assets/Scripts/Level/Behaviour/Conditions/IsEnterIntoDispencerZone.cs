using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class IsEnterIntoDispencerZone : Conditional
{
    public SharedDispencer CurrentDispancer;
    public SharedFloat WaitTime;

    public override TaskStatus OnUpdate()
    {
        if (CurrentDispancer.Value.IsBusy == false)
            return TaskStatus.Running;

        WaitTime.Value = CurrentDispancer.Value.PickUpTime;

        return TaskStatus.Failure;
    }
}
