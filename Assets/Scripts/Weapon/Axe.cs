using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon
{
    public override void Shoot(Transform pointShoot)
    {
        Instantiate(Bullet, pointShoot.position, Quaternion.identity);
    }
}
