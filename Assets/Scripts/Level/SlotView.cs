using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SlotView : MonoBehaviour
{
    [SerializeField] private TMP_Text _counter;
    [SerializeField] private Image _image;

    private Slot _slot;

    private void Update()
    {
        if (_slot == null)
            return;

        UpdateCounter();
    }

    public void Init(Slot slot)
    {
        _slot = slot;
        UpdateCounter();
        _image.sprite = slot.sprite;
    }

    public void UpdateCounter()
    {
        _counter.text = $"{_slot.currentAmount}/{_slot.capcity}";
    }
}
