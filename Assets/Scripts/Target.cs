using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : Actor {
    [SerializeField] private GameObject _DestroyedArt;
    [SerializeField] private int _Score = 100;
    protected override void Death()
    {
        base.Death();
        Destroy(gameObject);

        Instantiate(_DestroyedArt, transform.position, transform.rotation);

        ScoreManager.Instace.AddScore(_Score);
    }
}
