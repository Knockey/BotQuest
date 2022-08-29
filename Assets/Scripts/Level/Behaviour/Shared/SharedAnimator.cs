using System;
using BehaviorDesigner.Runtime;
using UnityEngine;

[Serializable]
public class SharedAnimator : SharedVariable<Animator>
{
    public static implicit operator SharedAnimator(Animator value) => new SharedAnimator { Value = value };
}
