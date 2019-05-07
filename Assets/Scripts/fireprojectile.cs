using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class fireprojectile : MonoBehaviour {
    [Header("Movement")]
    [SerializeField] private float _velocity = 20f;
    [SerializeField] private float _LifeTime = 2f;
    [SerializeField] private float RotationLerpSpeed = 10f;
    [Header("Damage")]
    [SerializeField] private float _Damage = 10f;
    [SerializeField] private float _Radius = 2.5f;
    [SerializeField] private float _KnockBack = 5f;

    [Header("Audio")]
    [SerializeField] private AudioClip _explotionSound;
    [SerializeField] private AudioSource _AudioSource;
    [SerializeField] private float _ExplosionSounDuration = 2f;

    [Header("Particles")]
    [SerializeField] private ParticleSystem _ExplosionParticle;
    [SerializeField] private float _ExplosionParticlesLifetime = 2f;

    private Rigidbody _rigidBody;
    private SphereCollider _sphereCollider;

    // Use this for initialization
    private void Start()
    {


    }
    public void Shoot(Vector3 InitialVelocity, Collider collider)
    {
        Destroy(gameObject, _LifeTime);
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.velocity = transform.forward * _velocity + InitialVelocity;

        _sphereCollider = GetComponent<SphereCollider>();
        //prevent collision with the projectile and spawning tank
        Physics.IgnoreCollision(_sphereCollider, collider, true);
    }

    // Update is called once per frame
    private void Update()
    {
        //rotate projectile in direction of travel
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_rigidBody.velocity.normalized), Time.deltaTime * RotationLerpSpeed);
    }

    //called when a collision occurs, on both gameObjects
    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _Radius);
        for (int i = 0; i < colliders.Length; i++)
        {
            Actor hitActor = colliders[i].GetComponent<Actor>();
            if (hitActor != null)
            {
                hitActor.Damage(_Damage);
            }
        }
        ParticleSystem explosion = Instantiate(_ExplosionParticle, transform.position, transform.rotation);
        Destroy(explosion.gameObject, _ExplosionParticlesLifetime);

        AudioSource explosionAudiosource = Instantiate(_AudioSource, transform.position, transform.rotation);
        explosionAudiosource.PlayOneShot(_explotionSound);
        Destroy(explosionAudiosource.gameObject, _ExplosionSounDuration);

        Destroy(gameObject);
    }
}
