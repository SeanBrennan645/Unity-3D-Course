using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with " + collision.gameObject.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by " + other.gameObject.name);
    }
}
