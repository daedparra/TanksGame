using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Napalm : Weapon{

    protected override void Fire()
    {
        //Getting max and min rotation
        Quaternion minRotation = transform.rotation * Quaternion.Euler(0f, -1, 0f);
        Quaternion maxRotation = transform.rotation * Quaternion.Euler(0f, 0, 0f);
        for (int i = 0; i < 3; i++)
        {
            //set 3 shells for making a fire bigger
            float lerpValue = (float)i / (2 - 1);
            Quaternion spawnRotation = Quaternion.Lerp(minRotation, maxRotation, lerpValue);
            projectile spawendProjectile = Instantiate(ProjectilePreFab, transform.position, spawnRotation);
            //setting the projectiles to appear in the tank
            spawendProjectile.Shoot(_parentribigbody.velocity, _parentCollider);


        }
    }
}
