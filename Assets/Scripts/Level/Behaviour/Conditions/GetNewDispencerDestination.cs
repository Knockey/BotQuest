using System.Linq;
using BehaviorDesigner.Runtime.Tasks;

public class GetNewDispencerDestination : Conditional
{
    public SharedAcceptorHandler AcceptorsHandler;
    public SharedDispencersList DispancersList;
    public SharedDispencer CurrentDispancer;

    public override TaskStatus OnUpdate()
    {
        if (AcceptorsHandler.Value.TryGetIncompleteAcceptor(out Acceptor acceptor) == false)
            return TaskStatus.Failure;

        var slotType = acceptor.GetIncompleteSlotType();
        CurrentDispancer.Value = DispancersList.Value.First(dispancer => dispancer.PickableType == slotType);

        return TaskStatus.Success;
    }
}
