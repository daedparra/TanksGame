using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
    //what the camera will follow
    [SerializeField] private Transform target;
    //tunign values
    [Header("Tuning")]
    [SerializeField] private float _LerpSpeed = 10f;
    [SerializeField] private float _Followdistance = 30f;
    [SerializeField] private Vector3 _followDirection;

    private Vector3 _targetPositon;
	
	// Update is called once per frame
	private void FixedUpdate () {
        Vector3 targetPosition = Vector3.zero;
        //check to make sure target is not null
        if (target != null)
        {
            _targetPositon = target.position + _followDirection.normalized * _Followdistance;
        }
        //interpolate camera position to target position
        
        transform.position = Vector3.Lerp(transform.position, _targetPositon, Time.fixedDeltaTime * _LerpSpeed);

	}
}
