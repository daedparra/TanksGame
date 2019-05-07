using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank : Actor{
    
    private Rigidbody _Rigidbody;
    private CapsuleCollider _collider;

    [SerializeField] private Vector2 _Moveinput;
    [Header("Cannon")]
    public Weapon CurrentWeapon;
    private Weapon[] _weapons;
    private int _weaponindex;

    [Header("Player Death")]
    [SerializeField] private GameObject DeadPlayerPrefab;
    [SerializeField] private GameOver GameOver;

    [Header("Movement turning")]
    [SerializeField] private float MoveSpeed = 5f;
    [SerializeField] private float TurnSpeed = 180f;
    protected override void Start()
    {
        //call the start function in parent class, Actor()
        base.Start();
        _Rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
        _weapons = GetComponentsInChildren<Weapon>();
    }

    private void NextWeapon()
    {
        _weaponindex++;
        CurrentWeapon = _weapons[_weaponindex % _weapons.Length];
    }

    private void Update()
    {
        //read move input from horizontal and vetical axes
        _Moveinput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetButtonDown("Fire1"))
        {
            CurrentWeapon.StartFireing();
            

        }
        if (Input.GetButtonUp("Fire1"))
        {
            CurrentWeapon.StopFiring();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            NextWeapon();
        }
    }
    private void FixedUpdate()
    {
        //amount moving forward each tick
        float moveDelta = MoveSpeed * Time.fixedDeltaTime * _Moveinput.y;
        //move forward by delta amount
        _Rigidbody.MovePosition(transform.position + moveDelta * transform.forward);


        //amount to rotate each tick
        float rotateDelta = TurnSpeed * Time.fixedDeltaTime * _Moveinput.x;
        //quaternion rotation based on delta
        Quaternion rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 
            transform.rotation.eulerAngles.y + rotateDelta, 
            transform.rotation.eulerAngles.z);
        //rotate the rigid body
        _Rigidbody.MoveRotation(rotation);
    }

    protected override void Death()
    {
        Instantiate(DeadPlayerPrefab, transform.position, transform.rotation);
        GameOver.StartGameOver();
        Destroy(gameObject);
        
    }
}
