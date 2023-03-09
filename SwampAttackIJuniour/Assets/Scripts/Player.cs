using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    public event UnityAction<int, int> HealthChanged;

    public int Money => _money;

    private Weapon _currentWeapon;
    private int _currentHealth;
    private Animator _animator;
    private int _money;

    private void Start()
    {
        _currentWeapon = _weapons[0];
        _animator = GetComponent<Animator>();
        _currentHealth = _health;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    public void OnEnemyDied(int reward)
    {
        _money += reward;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if(_currentHealth < 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int money)
    {
        _money += money;
    }
}
