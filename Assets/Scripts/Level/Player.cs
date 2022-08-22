using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private BackPack _backpack;
    [SerializeField] private UITimer _uiTimer;

    public BackPack Backpack => _backpack;
    public UITimer UITimer => _uiTimer;
}
