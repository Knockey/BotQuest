using UnityEngine;

public class Pickable : MonoBehaviour
{
    [SerializeField] private PickableType _type;
    [SerializeField] private PickableUI _pickableUI;

    public PickableType PickableType => _type;
    public PickableUI PickableUI => _pickableUI;

    public void Destroy() => Destroy(gameObject);
}

public enum PickableType
{
    Cube,
    Sphere,
    Cylinder
}
