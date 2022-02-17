using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.ChangedHealth += OnValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        _player.ChangedHealth -= OnValueChanged;
    }
}
