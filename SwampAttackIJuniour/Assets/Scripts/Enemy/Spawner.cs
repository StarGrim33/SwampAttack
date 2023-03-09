using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private Wave _currentWave;
    private int _currentWavNumber;
    private float _timeAfterLastSpawn;
    private int _spawned;

    private void Start()
    {
        SetWave(_currentWavNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
        }

        if (_currentWave.Count <= _spawned)
            _currentWave = null;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint.position, Quaternion.identity, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_player);
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        _player.AddMoney(enemy.Reward);
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}