using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private const float MAX_TILT_DEGREES = -15.0f;

    [SerializeField]
    private const float TURN_SPEED_SCALER = 1.75f;

    public float speed;

    private Rigidbody rigid;

    void Start () {
        rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate () {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontal / TURN_SPEED_SCALER, 0, 1) * speed * Time.deltaTime;

        rigid.MovePosition(transform.position + movement);
        HandleTilt(horizontal);
    }

    void HandleTilt(float horizontal) {
        rigid.rotation = Quaternion.Euler(0.0f, 0.0f, horizontal * MAX_TILT_DEGREES);
    }

    private void OnCollisionExit(Collision other)
    {
        rigid.velocity = new Vector3(0.0f, 0.0f, 0.0f);    // Stop drifting after collision
    }
}
