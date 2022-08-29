using System;
using BehaviorDesigner.Runtime;

[Serializable]
public class SharedBackpack : SharedVariable<BackPack>
{
    public static implicit operator SharedBackpack(BackPack value) => new SharedBackpack { Value = value };
}
