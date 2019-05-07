using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDHealthBar : MonoBehaviour {
    [Tooltip("The target actor for health display.")]
    [SerializeField] private Actor _Target;

    //lock rotation 
    [SerializeField] private bool _LockRotation = false;

    [SerializeField] private float _LerpSpeed = 10f;

    private Image _healthBAr;

    private void Awake()
    {
        _healthBAr = GetComponent<Image>();

    }
    // Update is called once per frame
    private void Update () {
        if (!_Target)
        {
            _healthBAr.fillAmount = 0;
            return;
        }

        //set the fill amoiunt of the image base on target health
        _healthBAr.fillAmount = Mathf.Lerp(_healthBAr.fillAmount,_Target.HealthFill,Time.deltaTime * _LerpSpeed);
        if (_LockRotation) transform.rotation = Quaternion.identity;
    }
}
