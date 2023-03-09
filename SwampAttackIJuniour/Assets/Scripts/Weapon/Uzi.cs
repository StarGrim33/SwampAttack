using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi : Weapon
{
    [SerializeField] UziBullet UziBullet; 

    public override void Shoot(Transform shootPoint)
    {
        Instantiate(UziBullet, shootPoint.position, Quaternion.identity);
    }
}
