using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccepterView : MonoBehaviour
{
    [SerializeField] private SlotView _slotView;

    public SlotView CurrentSlotView { get; private set; }

    public void Init(IReadOnlyCollection<Slot> slots)
    {
        foreach (var slot in slots)
        {
            CreateSlotView(slot);
        }
    }

    public void CreateSlotView(Slot slot)
    {
        CurrentSlotView = Instantiate(_slotView, transform);

        CurrentSlotView.Init(slot);
    }

    private void ShowSlotView()
    {
        enabled = true;
    }

    private void HideSlotView()
    {
        enabled = false;
    }
}
