using System;
using System.Collections.Generic;
using UnityEngine;

public class BackPack : MonoBehaviour
{
    private const int Capacity = 1;

    [SerializeField] private Transform _point;

    private int _counter;
    private List<Pickable> _pickables = new List<Pickable>();

    public bool IsFull => _counter >= Capacity;
    public bool HasPickable => _pickables.Count > 0;
    public PickableType lastPickableType => _pickables[_pickables.Count - 1].PickableType;
    
    public event Action PickableTaken;
    public event Action PickableGiven;

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
