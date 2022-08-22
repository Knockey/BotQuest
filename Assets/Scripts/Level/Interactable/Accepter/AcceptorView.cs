using System.Collections.Generic;
using UnityEngine;

public class AcceptorView : MonoBehaviour
{
    [SerializeField] private SlotView _slotView;
    [SerializeField] private GameObject _floorMarker;

    public SlotView CurrentSlotView { get; private set; }

    public void Init(IReadOnlyCollection<Slot> slots)
    {
        foreach (var slot in slots)
        {
            CreateSlotView(slot);
        }

        _floorMarker.SetActive(true);
    }

    public void CreateSlotView(Slot slot)
    {
        CurrentSlotView = Instantiate(_slotView, transform);

        CurrentSlotView.Init(slot);
    }
}
