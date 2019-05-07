using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotGun : Weapon {

    [SerializeField] private int _Shotcount = 0;
    [SerializeField] private float _HalfSpreadAngle = 30f;

    protected override void Fire()
    {
        if (_Shotcount < 2)
        {
            return;
        }
        Quaternion minRotation = transform.rotation * Quaternion.Euler(0f, -_HalfSpreadAngle, 0f);
        Quaternion maxRotation = transform.rotation * Quaternion.Euler(0f, _HalfSpreadAngle, 0f);

        for (int i=0; i < _Shotcount; i++)
        {
            float lerpValue = (float)i / (_Shotcount - 1);
            Quaternion spawnRotation = Quaternion.Lerp(minRotation, maxRotation, lerpValue);
            projectile spawendProjectile = Instantiate(ProjectilePreFab, transform.position, spawnRotation);
            spawendProjectile.Shoot(_parentribigbody.velocity, _parentCollider);
           
        }
        audioSource.Play();
    }
}
