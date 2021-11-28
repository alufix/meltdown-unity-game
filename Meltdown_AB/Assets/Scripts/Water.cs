using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Rigidbody rb;
    [Range(0, 100)]
    public float Speed = 1f;

    void Start()
    {
        rb.velocity = transform.forward * Speed;
    }
}
