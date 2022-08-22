using System.Collections;
using UnityEngine;

public class Dispencer : Interactable
{
    [SerializeField] private Pickable _pickable;

    private Coroutine _pickUpCoroutine;

    public bool IsBusy => _pickUpCoroutine != null;
    public int PickUpTime { get; private set; } 

    public PickableType PickableType => _pickable.PickableType;

    protected override void OnZoneEnter(Player player)
    {
        if (player.Backpack.IsFull == false)
            _pickUpCoroutine = StartCoroutine(PickUp(player));
    }

    protected override void OnZoneExit(Player player)
    {
        if (_pickUpCoroutine != null)
            StopCoroutine(_pickUpCoroutine);

        _pickUpCoroutine = null;
        player.UITimer.StopTimer();
    }

    private IEnumerator PickUp(Player player)
    {
        PickUpTime = Random.Range(0, 4);
        player.UITimer.StartTimer(PickUpTime);

        yield return new WaitForSeconds(PickUpTime);

        player.Backpack.TryPutIn(GetPickable());
    }

    private Pickable GetPickable()
    {
        return Instantiate(_pickable, transform, true);
    }

}
