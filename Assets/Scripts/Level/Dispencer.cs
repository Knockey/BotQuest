using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dispencer : Interactable
{
    [SerializeField] private Pickable _pickable;

    public override void OnInteraction(Player player)
    {
        if(player.backPack.IsFull == false)
            player.backPack.TryPutIn(GetPickable());
    }

    private Pickable GetPickable()
    {
        var pickable = Instantiate(_pickable, transform, true);

        return pickable;
    }
}
