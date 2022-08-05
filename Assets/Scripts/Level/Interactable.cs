using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected BoxCollider boxCollider;

    private void Awake()
    {
        boxCollider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
            OnInteraction(player);
    }

    public abstract void OnInteraction(Player player);
}
