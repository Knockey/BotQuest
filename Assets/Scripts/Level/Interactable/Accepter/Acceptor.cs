using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Acceptor : Interactable
{
    [SerializeField] private Slot[] _slots;
    [SerializeField] private AcceptorView _accepterView;

    private Coroutine _placingCoroutine;

    public bool IsActive { get; private set; }
    public bool IsCompleted { get; private set; }
    public bool IsBusy => _placingCoroutine != null;
    public int PickUpTime { get; private set; }

    public event Action<Acceptor> Completed;

    public void EnableAcceptor()
    {
        boxCollider.enabled = true;
        IsActive = true;
        _accepterView.Init(_slots);
    }

    public void DisableAcceptor()
    {
        boxCollider.enabled = false;
    }

    public PickableType GetIncompleteSlotType()
    {
        return _slots.ToList().First(slot => slot.IsFull == false).PickableType;
    }

    protected override void OnZoneEnter(Player player)
    {
        if (CanInteract(player))
            _placingCoroutine = StartCoroutine(Placing(player));
    }

    protected override void OnZoneExit(Player player)
    {
        if (_placingCoroutine != null)
            StopCoroutine(_placingCoroutine);

        player.UITimer.StopTimer();
    }

    private bool TryPlace(Pickable pickable)
    {
        if (TryPlace(pickable.PickableType, out Slot slot))
        {
            Place(pickable, slot);

            return true;
        }

        return false;
    }

    private void Place(Pickable pickable, Slot slot)
    {
        slot.Add();
        pickable.Destroy();

        if (_slots.Any(slot => slot.IsFull == false) == false)
        {
            Completed?.Invoke(this);
            IsCompleted = true;
        }
    }

    private bool TryPlace(PickableType type, out Slot slot)
    {
        slot = _slots.FirstOrDefault(slot => IsSlotHasSpace(slot, type));

        return slot != default;
    }

    public bool IsAbleToPlace(PickableType type)
    {
        return _slots.Any(slot => IsSlotHasSpace(slot, type));
    }

    private bool CanInteract(Player player)
    {
        return IsActive && player.Backpack.HasPickable && IsAbleToPlace(player.Backpack.lastPickableType);
    }

    private bool IsSlotHasSpace(Slot slot, PickableType type)
    {
        return slot.PickableType == type && slot.IsFull == false;
    }

    private IEnumerator Placing(Player player)
    {
        PickUpTime = UnityEngine.Random.Range(0, 4);
        player.UITimer.StartTimer(PickUpTime);

        yield return new WaitForSeconds(PickUpTime);

        if (player.Backpack.TryGetPickable(out Pickable pickable))
            TryPlace(pickable);

        _placingCoroutine = null;
    }
}
