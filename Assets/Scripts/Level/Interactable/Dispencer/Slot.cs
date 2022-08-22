using System;
using UnityEngine;

[Serializable]
public class Slot
{
    [SerializeField] private Pickable _pickable;
    [SerializeField] private int _capacity;

    public PickableType PickableType => _pickable.PickableType;
    public Sprite Sprite => _pickable.PickableUI.Sprite;
    public int Capcity => _capacity;
    public int FreeSpace => _capacity - CurrentAmount;
    public int CurrentAmount { get; private set; }
    public bool IsFull => CurrentAmount >= _capacity;

    public void Add() => CurrentAmount += 1;
}
