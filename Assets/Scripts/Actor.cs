using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

    [Header("Health")]
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _CurrentHealth;
    public float CurrentHealth { get { return _CurrentHealth; } protected set { _CurrentHealth = Mathf.Clamp(value,0f,_maxHealth); } }

    [SerializeField] private GameObject _ExplosionFX;

    /// <summary>
    /// Returns the health percentage of the actor
    /// </summary>
    public float HealthFill
    {
        get
        {
            return Mathf.Clamp(_CurrentHealth / _maxHealth, 0f, 1f);
        }
    }
    protected virtual void Start()
    {
        CurrentHealth = _maxHealth;
    }
    public virtual void Damage(float amout)
    {
        if (CurrentHealth <= 0f) return;

        CurrentHealth -= amout;

        //call the death function if the actor hits 0 health
        if (CurrentHealth <= 0f) Death();
    }

    protected virtual void Death()
    {

        Instantiate(_ExplosionFX, transform.position, Quaternion.identity);
    }

    [ContextMenu("Damage Test:10")]
    private void DamageTest()
    {
        Damage(10f);
    }
}
