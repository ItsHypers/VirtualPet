using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove: MonoBehaviour
{
    Rigidbody rb;
    float speed = 3;
    void Awake()
    {
        Vector3 direction = new Vector3(Random.Range(-1f, 1f),
                                Random.Range(-1f, 1f),
                                Random.Range(-1f, 1f)); 
        rb = gameObject.GetComponent<Rigidbody>();
        direction.Normalize();
        Vector3 newVelocity = speed * direction;
        rb.velocity = newVelocity;
    }

}
