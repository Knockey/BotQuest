using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private BackPack _backPack;

    public BackPack backPack => _backPack;
}
