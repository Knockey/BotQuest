using System.Collections.Generic;
using BehaviorDesigner.Runtime;

public class SharedDispencersList : SharedVariable<List<Dispencer>>
{
    public static implicit operator SharedDispencersList(List<Dispencer> value) => new SharedDispencersList { Value = value };
}
