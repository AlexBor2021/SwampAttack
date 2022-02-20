using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpirianceBar : Bar
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.ChangedSpawned += OnValueChanged;
        Slider.value = 0;
    }

    private void OnDisable()
    {
        _spawner.ChangedSpawned -= OnValueChanged;
    }
}
