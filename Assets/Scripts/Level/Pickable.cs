using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] private PickableType _type;
    [SerializeField] private PickableUI _pickableUI;

    public PickableType type => _type;
    public PickableUI pickableUI => _pickableUI;

    public void DESTROY()
    {
        Destroy(gameObject);
    }
}

public enum PickableType
{
    Cube,
    Sphere,
    Cylinder
}
