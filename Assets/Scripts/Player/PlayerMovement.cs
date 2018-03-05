using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed;

    private Rigidbody rigid;

    private const float MAX_TILT_DEGREES = -15.0f;

    void Start () {
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate () {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;

        rigid.MovePosition(transform.position + movement);
        HandleTilt(horizontal);
    }

    void HandleTilt(float horizontal) {
        rigid.rotation = Quaternion.Euler(0.0f, 0.0f, horizontal * MAX_TILT_DEGREES);
    }
}
