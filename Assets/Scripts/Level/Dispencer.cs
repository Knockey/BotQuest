using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispencer : Interactable
{
    [SerializeField] private Pickable _pickable;

    private Coroutine _putingCoroutine;

    public override void OnInteraction(Player player)
    {
        if (player.backPack.IsFull == false)
            _putingCoroutine = StartCoroutine(Puting(player));
    }

    public override void OnZoneExit(Player player)
    {
        if (_putingCoroutine != null)
            StopCoroutine(_putingCoroutine);

        player.uITimer.StopCount();
    }

    private Pickable GetPickable()
    {
        var pickable = Instantiate(_pickable, transform, true);

        return pickable;
    }

    private IEnumerator Puting(Player player)
    {
        int delay = Random.Range(0, 4);
        player.uITimer.StartCount(delay);

        yield return new WaitForSeconds(delay);

        player.backPack.TryPutIn(GetPickable());
    }
}
