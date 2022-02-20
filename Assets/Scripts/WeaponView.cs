using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    private Weapon _weapon;

    public event UnityAction<Weapon, WeaponView> _sellWepon;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnClickButtton);
        _sellButton.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnClickButtton);
        _sellButton.onClick.RemoveListener(TryLockItem);
    }
    private void TryLockItem()
    {
        if (_weapon.IsBuy)
            _sellButton.interactable = false;
    }

    public void Render(Weapon weapon)
    {
        _weapon = weapon;

        _label.text = weapon.Label;
        _price.text = weapon.Price.ToString();
        _icon.sprite = weapon.Icon;
    }

    private void OnClickButtton()
    {
        _sellWepon?.Invoke(_weapon, this);
    }
}




