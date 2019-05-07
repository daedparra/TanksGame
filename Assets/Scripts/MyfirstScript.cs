using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyfirstScript : MonoBehaviour {

    //called once, before start
    private void Awake()
    {
        Debug.Log("Awake");
    }

    //called on each enable
    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    // Use this for initialization
    void Start () {
        Debug.Log("Start");
    }

	//called once per physics tick
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate");
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //down
        }
        if (Input.GetKey(KeyCode.Space))
        {
            //held
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //up
        }
	}

    //called on each disable
    private void OnDisable()
    {
        Debug.Log("Ondisable");
    }
    //called on destruction 
    private void OnDestroy()
    {
        Debug.Log("OnDestroy");
    }
}
