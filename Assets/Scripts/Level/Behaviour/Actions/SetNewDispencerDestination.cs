using BehaviorDesigner.Runtime.Tasks;

public class SetNewDispencerDestination : Action
{
    public SharedDispencer CurrentDispancer;
    public SharedNavMeshAgent NavMeshAgent;

    public override TaskStatus OnUpdate()
    {
        NavMeshAgent.Value.SetDestination(CurrentDispancer.Value.PickUpPoint);
        return TaskStatus.Success;
    }
}
