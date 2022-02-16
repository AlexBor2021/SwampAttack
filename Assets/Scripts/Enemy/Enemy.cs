using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _revard;

    private Player _taget;

    public event UnityAction<Enemy> Dying;

    public Player Target => _taget;
    public int Revard => _revard;

    public void Init(Player target)
    {
        _taget = target;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0 )
        {
            Dying?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
