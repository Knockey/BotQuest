using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPack : MonoBehaviour
{
    [SerializeField] private Transform _point;

    private int _counter;
    public bool IsFull => _counter >= Capacity;
    public bool HasPickable => _pickables.Count > 0;
    public Type lastPickableType => _pickables[_pickables.Count - 1].type;

    private const int Capacity = 1;

    public event Action PickableTaken;
    public event Action PickableGiven;

    private List<Pickable> _pickables = new List<Pickable>();

    public bool TryPutIn(Pickable pickable)
    {
        if (IsFull)
            return false;

        _pickables.Add(pickable);
        pickable.transform.SetParent(_point);
        pickable.transform.localPosition = Vector3.zero;
        _counter++;

        PickableTaken?.Invoke();
        return true;
    }

    public bool TryGetPickable(out Pickable pickable)
    {
        pickable = null;

        if (HasPickable)
        {
            int index = _pickables.Count - 1;
            pickable = _pickables[index];
            _pickables.Remove(pickable);
            _counter--;

            PickableGiven?.Invoke();

            return true;
        }

        return false;
    }
}
