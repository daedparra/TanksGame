using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timesDesctruction : MonoBehaviour {


    [SerializeField] private float _Duration = 2f;
    private float _timer;

	// Update is called once per frame
	private void Update () {
        _timer += Time.deltaTime;
        if (_timer >= _Duration) Destroy(gameObject);
	}
}
