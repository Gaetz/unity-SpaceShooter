using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed;

    private Rigidbody rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        rbody.velocity = speed * rbody.transform.forward;
    }
}
