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
    public Boundary boundary;

    private Rigidbody rbody;

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

}
