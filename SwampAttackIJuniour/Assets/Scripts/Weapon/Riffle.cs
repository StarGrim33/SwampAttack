using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riffle : Weapon
{
    [SerializeField] RiffleBullet RiffleBullet;

    public override void Shoot(Transform shootPoint)
    {
        Instantiate(RiffleBullet, shootPoint.position, Quaternion.identity);
    }
}
