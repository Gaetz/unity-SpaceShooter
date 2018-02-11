using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public float tilt;
    public float fireRate;
    public Boundary boundary;
    public GameObject shot;
    public Transform shotSpawn;

    private Rigidbody rbody;
    private float nextFire;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        rbody.velocity = movement * speed;
        rbody.position = new Vector3(
            Mathf.Clamp(rbody.position.x, boundary.xMin, boundary.xMax),
            0f,
            Mathf.Clamp(rbody.position.z, boundary.zMin, boundary.zMax)
        );

        rbody.rotation = Quaternion.Euler(0f, 0f, rbody.velocity.x * -tilt);
    }

    private void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)  {
            nextFire = Time.time + fireRate;
            GameObject clone = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
        }
    }
}
