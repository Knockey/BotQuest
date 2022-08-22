using BehaviorDesigner.Runtime;

public class SharedDispencer : SharedVariable<Dispencer>
{
    public static implicit operator SharedDispencer(Dispencer value) => new SharedDispencer { Value = value };
}
