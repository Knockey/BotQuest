using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Slot
{
    [SerializeField] private Pickable _pickable;
    [SerializeField] private int _capacity;

    public PickableType type => _pickable.type;
    public Sprite sprite => _pickable.pickableUI.sprite;
    public int capcity => _capacity;
    public int freeSpace => _capacity - currentAmount;
    public int currentAmount { get; private set; }
    public bool isFull => currentAmount >= _capacity;

    public void Add()
    {
        currentAmount++;
    }
}
