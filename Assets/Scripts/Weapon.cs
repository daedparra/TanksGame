using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] protected float RPM = 100f;
    [SerializeField] protected projectile ProjectilePreFab;


    protected bool _wantsTofire;
    private float _lastFireTime;
    protected Rigidbody _parentribigbody;
    protected Collider _parentCollider;
    protected AudioSource audioSource;
    protected virtual void Start()
    {
        _parentribigbody = transform.parent.GetComponent<Rigidbody>();
        _parentCollider = transform.parent.GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();

    }

    public virtual void StartFireing()
    {
        _wantsTofire = true;
    }

    public virtual void StopFiring()
    {
        _wantsTofire = false;
    }

    protected virtual void Update()
    {
        if (_wantsTofire && CanFire()) {
            _lastFireTime = Time.timeSinceLevelLoad;
            Fire();
        }
    }

    protected bool CanFire()
    {
        float firePeriod = 60f / RPM;
        bool canFire = Time.timeSinceLevelLoad > _lastFireTime + firePeriod;
        return canFire;
    }

    protected virtual void Fire()
    {
        Debug.Log("Fire");
        projectile spawendeProjectile = Instantiate(ProjectilePreFab, transform.position, transform.rotation);
        spawendeProjectile.Shoot(_parentribigbody.velocity, _parentCollider);
        audioSource.Play();
    }
}
