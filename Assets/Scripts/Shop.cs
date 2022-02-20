using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Player _player;
    [SerializeField] private WeaponView _template;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        for (int i = 0; i < _weapons.Count; i++)
        {
            AddItem(_weapons[i]);
        }
    }

    private void AddItem(Weapon weapon)
    {
        var view = Instantiate(_template, _itemContainer.transform);

        view.Render(weapon);

        view._sellWepon += OnSellWeapon;
    }

    private void OnSellWeapon(Weapon weapon, WeaponView view)
    {
        TrySellWepon(weapon, view);
    }

    private void TrySellWepon(Weapon weapon, WeaponView view)
    {
        if (_player.Money > weapon.Price)
        {
            _player.Buy(weapon);
            weapon.Sell();
            view._sellWepon -= OnSellWeapon;
        }
    }

}
