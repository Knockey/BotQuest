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
    }

    private Pickable GetPickable()
    {
        var pickable = Instantiate(_pickable, transform, true);

        return pickable;
    }

    private IEnumerator Puting(Player player)
    {
        yield return new WaitForSeconds(0.8f);

        player.backPack.TryPutIn(GetPickable());
    }
}
