using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableUI : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;

    public Sprite sprite => _sprite;
}
