using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class DetectCollision : MonoBehaviour {
    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            //every time a tank being an enemy or player
            other.GetComponent<Actor>().Damage(0.5f);
        }
    }
}
