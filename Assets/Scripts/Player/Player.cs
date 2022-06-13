using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _pointShoot;
    
    private Animator _animator;
    private int _currentHealth;
    private Weapon _curentWeapon;
    private int _currentWeaponNumber = 0;

    public Animator Animator => _animator;

    public event UnityAction<int , int> ChangedHealth;
    public event UnityAction<int> ChangedMoney;

    public int Money { get; private set;}
    
    private void Start()
    {
        _currentHealth = _health;
        _curentWeapon = _weapons[_currentWeaponNumber];
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayAnimation();
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

        ChangedHealth.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    public void AddMoney(int money)
    {
        Money += money;
        ChangedMoney?.Invoke(Money);
    }

    public void Buy(Weapon weapon)
    {
        Money -= weapon.Price;
        ChangedMoney?.Invoke(Money);
        _weapons.Add(weapon);
    }

    public void ChangeNextWaepon()
    {
        if (_currentWeaponNumber == _weapons.Count - 1)
            _currentWeaponNumber = 0;
        else
            _currentWeaponNumber++;
        StateCurrentWeapon(_weapons[_currentWeaponNumber]);
    }

    public void ChangePriviusWeapon()
    {
        if (_currentWeaponNumber == 0)
            _currentWeaponNumber = _weapons.Count - 1;
        else
            _currentWeaponNumber--;
        StateCurrentWeapon(_weapons[_currentWeaponNumber]);
    }

    private void StateCurrentWeapon(Weapon weapon)
    {
        _curentWeapon = weapon;
    }

    private void PlayAnimation()
    {
        if (_curentWeapon.tag == "Axe")
        {
            _animator.Play("AttackAxe");
        }
        if (_curentWeapon.tag == "Rifle")
        {
            _animator.Play("Attack");
        }
    }
}
