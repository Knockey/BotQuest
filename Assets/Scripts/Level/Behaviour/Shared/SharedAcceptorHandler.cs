using System;
using BehaviorDesigner.Runtime;

[Serializable]
public class SharedAcceptorHandler : SharedVariable<AcceptorHandler>
{
    public static implicit operator SharedAcceptorHandler(AcceptorHandler value) => new SharedAcceptorHandler { Value = value };
}
