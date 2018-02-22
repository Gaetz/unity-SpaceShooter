using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

    public float tumble;
    Rigidbody rbody;

	// Use this for initialization
	void Start () {
        rbody = GetComponent<Rigidbody>();
        rbody.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
