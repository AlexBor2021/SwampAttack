using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawner;
    private int _spawned;

    public event UnityAction _allSpawnedEnemy;

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawner += Time.deltaTime;

        if (_timeAfterLastSpawner >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawner = 0;
        }

        if (_spawned >= _currentWave.Count)
        {
            _currentWave = null;
            _spawned = 0;
            if (_waves.Count > _currentWaveNumber+1)
            {
                 _allSpawnedEnemy.Invoke();
            }
        }
        
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_player);
        enemy.Dying += OnEnemyDying;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    public void SetNextWave()
    {
        SetWave(++_currentWaveNumber);
    }
    
    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;

        _player.AddMoney(enemy.Revard);
    }
}

[System.Serializable]

public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}
