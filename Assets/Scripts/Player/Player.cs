using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _pointShoot;

    private Animator _animator;
    private int _currentHealth;
    private Weapon _curentWeapon;

    public int Money { get; private set;}

    private void Start()
    {
        _currentHealth = _health;
        _curentWeapon = _weapons[0];
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _curentWeapon.Shoot(_pointShoot);
        }
    }

    private void OnEnemyDied(int revard)
    {
        Money += revard;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    public void AddMoney(int money)
    {
        Money += money;
    }
}
