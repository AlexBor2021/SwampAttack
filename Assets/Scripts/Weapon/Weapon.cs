using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _lable;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _price;
    [SerializeField] private bool _isBuy = false;

    [SerializeField] protected Bullet Bullet;

    public string Label => _lable;
    public Sprite Icon => _icon;
    public int Price => _price;
    public bool IsBuy => _isBuy;

    public abstract void Shoot(Transform pointShoot);

    public void Sell()
    {
        _isBuy = true;
    }
}
