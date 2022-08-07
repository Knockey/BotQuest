using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Accepter : Interactable
{
    [SerializeField] private Slot[] _slots;
    [SerializeField] private AccepterView _accepterView;

    private Coroutine _placingCoroutine;

    public bool IsActive { get; private set; }
    public bool IsCompleted { get; private set; }

    public event Action<Accepter> Completed;

    public void ActivateAndEnableThisEbanieCollider()
    {
        boxCollider.enabled = true;
        IsActive = true;
        _accepterView.Init(_slots);
    }

    public void DisableThisEbanieCollider()
    {
        boxCollider.enabled = false;
    }

    public override void OnInteraction(Player player)
    {
        if (CanInteract(player))
            _placingCoroutine = StartCoroutine(Placing(player));
    }

    public override void OnZoneExit(Player player)
    {
        StopCoroutine(_placingCoroutine);
        player.uITimer.StopCount();
    }

    public bool IsFull()
    {
        return _slots.FirstOrDefault(slot => slot.isFull == false) == default;
    }

    public List<PickableType> GetIncompleteSlotTypes()
    {
        var types = _slots.ToList().FindAll(slot => slot.isFull == false).ToList().ConvertAll(slot => slot.type);

        return types;
    }

    private bool TryPlace(Pickable pickable)
    {
        if (CanPlace(pickable.type, out Slot slot))
        {
            Place(pickable, slot);

            return true;
        }

        return false;
    }

    private void Place(Pickable pickable, Slot slot)
    {
        slot.Add();
        pickable.DESTROY();

        if (IsFull())
        {
            Completed?.Invoke(this);
            IsCompleted = true;
        }
    }

    private bool CanPlace(PickableType type, out Slot slot)
    {
        slot = _slots.FirstOrDefault(slot => IsSlotHasSpace(slot, type));

        return slot != default;
    }

    public bool CanPlace(PickableType type)
    {
        return _slots.FirstOrDefault(slot => IsSlotHasSpace(slot, type)) != default;
    }

    private bool CanInteract(Player player)
    {
        return IsActive && player.backPack.HasPickable && CanPlace(player.backPack.lastPickableType);
    }

    private bool IsSlotHasSpace(Slot slot, PickableType type)
    {
        return slot.type == type && slot.isFull == false;
    }

     private IEnumerator Placing(Player player)
    {
        int delay = UnityEngine.Random.Range(0, 4);
        player.uITimer.StartCount(delay);

        yield return new WaitForSeconds(delay);
        Debug.Log("hi");

        if (player.backPack.TryGetPickable(out Pickable pickable))
            TryPlace(pickable);
    }
}
