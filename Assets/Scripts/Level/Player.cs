using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private BackPack _backPack;
    [SerializeField] private UITimer _uiTimer;

    public BackPack backPack => _backPack;
    public UITimer uITimer => _uiTimer;
}
