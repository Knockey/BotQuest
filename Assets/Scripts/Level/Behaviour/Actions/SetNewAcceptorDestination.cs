using BehaviorDesigner.Runtime.Tasks;

public class SetNewAcceptorDestination : Action
{
    public SharedAcceptor CurrentAcceptor;
    public SharedNavMeshAgent NavMeshAgent;

    public override TaskStatus OnUpdate()
    {
        NavMeshAgent.Value.SetDestination(CurrentAcceptor.Value.PickUpPoint);
        return TaskStatus.Success;
    }
}
