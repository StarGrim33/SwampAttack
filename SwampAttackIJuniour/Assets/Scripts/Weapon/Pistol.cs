using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    [SerializeField] private Bullet bullet;

    public override void Shoot(Transform shootPoint)
    {
        Instantiate(bullet, shootPoint.position, Quaternion.identity);
    }
}
