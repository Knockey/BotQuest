using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] private Type _type;
    [SerializeField] private PickableUI _pickableUI;

    public Type type => _type;
    public PickableUI pickableUI => _pickableUI;

    public void DESTROY()
    {
        Destroy(gameObject);
    }
}

public enum Type
{
    Cube,
    Sphere,
    Cylinder
}
