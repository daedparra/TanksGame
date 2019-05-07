using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour {
    public float UpdatedPeriod = 0.1f;
    private IEnumerator _shootRoutine;
    private void Start()
    {
        //InvokeRepeating("Log",2f,0.25f);
        StartCoroutine(MyFirstCoroutine());
        IEnumerator secondUpdate = SecondUpdate(UpdatedPeriod);
        StartCoroutine(secondUpdate);
    }
    private IEnumerator MyFirstCoroutine()
    {
        Debug.Log("Initial Log");
        yield return new WaitForSeconds(2f);
        Debug.Log("Final Log");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _shootRoutine = Shoot(UpdatedPeriod);
            StartCoroutine(_shootRoutine);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (_shootRoutine != null) StopCoroutine(_shootRoutine);
        }
    }
    private IEnumerator Shoot(float period)
    {
        while (true)
        {
            Debug.Log("Shoot");
            yield return StartCoroutine(TripleShot());
            yield return new WaitForSeconds(period);
        }
    }
    private IEnumerator TripleShot()
    {
       for(int i = 0; i < 3; i++)
        {
            Debug.Log("TripleShot " + i);
            yield return new WaitForSeconds(0.5f);
        }

    }
    private IEnumerator SecondUpdate(float period)
    {
        while (true)
        {
            Debug.Log("Second Update");
            yield return new WaitForSeconds(period);
        }
    }
    private void Log()
    {
        Debug.Log("Log Called");
    }
}
