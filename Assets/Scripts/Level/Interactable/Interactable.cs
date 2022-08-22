using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected BoxCollider boxCollider;

    public Vector3 PickUpPoint => transform.position;

    private void Awake()
    {
        boxCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            OnZoneEnter(player);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            OnZoneExit(player);
    }

    protected abstract void OnZoneEnter(Player player);
    protected abstract void OnZoneExit(Player player);
}
