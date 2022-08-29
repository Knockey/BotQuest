using BehaviorDesigner.Runtime.Tasks;

public class DoBackflip : Action
{
    private const string BackflipAnimation = "DoBackflip";

    public SharedAnimator Animator;

    public override TaskStatus OnUpdate()
    {
        Animator.Value.SetTrigger(BackflipAnimation);
        return TaskStatus.Success;
    }

}
