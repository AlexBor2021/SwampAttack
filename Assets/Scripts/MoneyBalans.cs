using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBalans : MonoBehaviour
{
    [SerializeField] private TMP_Text _moneyBalans;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _moneyBalans.text = _player.Money.ToString();
    }
}
