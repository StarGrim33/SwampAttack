using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    public Player Target => _target;

    public int Reward => _reward;

    public event UnityAction<Enemy> Died;

    private Player _target;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            Destroy(gameObject);
            _target.OnEnemyDied(Reward);
            Died?.Invoke(this);
        }
    }

    public void Init(Player target)
    {
        _target = target;
    }
}
