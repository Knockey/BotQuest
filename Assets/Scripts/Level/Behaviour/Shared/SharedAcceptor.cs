using System;
using BehaviorDesigner.Runtime;

[Serializable]
public class SharedAcceptor : SharedVariable<Acceptor>
{
    public static implicit operator SharedAcceptor(Acceptor value) => new SharedAcceptor { Value = value };
}
