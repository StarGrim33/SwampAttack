using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UziBullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private int _criticalDamage = 30;

    private int _chanceCriticalDamage = 20;

    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
        {
            if (CriticalDamage()) 
            {
                enemy.TakeDamage(_criticalDamage);
                Debug.Log("Критический урон!");
            }

            enemy.TakeDamage(_damage);
            Destroy(gameObject);
        }

        if (collision.TryGetComponent<Border>(out Border border))
            Destroy(gameObject);
    }

    private bool CriticalDamage()
    {
        int minNumber = 1;
        int maxNumber = 100;

        int random = Random.Range(minNumber, maxNumber);

        return random < _chanceCriticalDamage;
    }
}
