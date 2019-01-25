using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private const float MAX_TILT_DEGREES = -15.0f;

    [SerializeField]
    private const float TURN_SPEED_SCALER = 1.75f;

    public float speed;

    private const float HoverHeight = 1.5f;

    private Rigidbody _rigid;

    void Start () {
        _rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate () {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

//        var movement = new Vector3(horizontal / TURN_SPEED_SCALER, transform.position.y, 1) * speed * Time.deltaTime;
//        _rigid.MovePosition(transform.position + movement);
        
        _rigid.AddRelativeForce(0, 0, 50);    // TODO: create constant
        
        HandleTilt(horizontal);
        HandleJump();
    }

    private void HandleJump()
    {
        var hoverDistanceVector = transform.TransformDirection(Vector3.down);
        if (Physics.Raycast(transform.position, hoverDistanceVector, HoverHeight))
        {
            Debug.Log("Something below");
        }

        //var raycastStart = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(transform.position, hoverDistanceVector, HoverHeight))
        {
            Debug.Log("space");
            _rigid.constraints &= ~RigidbodyConstraints.FreezePositionY;
            _rigid.AddForce(new Vector3(0, 7.5f, 0), ForceMode.Impulse);
        }
        else if (Physics.Raycast(transform.position, hoverDistanceVector, HoverHeight - 0.1f))    // epsilon
        {
            Debug.Log("reset y");
            _rigid.MovePosition(new Vector3(transform.position.x, 2.0f, transform.position.z));    // temp
            _rigid.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }

    private void HandleTilt(float horizontal)
    {
//        var movement = new Vector3(horizontal / TURN_SPEED_SCALER, transform.position.y, 1) * speed * Time.deltaTime;
//        _rigid.MovePosition(transform.position + movement);
        _rigid.AddForce(10 * horizontal, 0, 0, ForceMode.Impulse);
        _rigid.rotation = Quaternion.Euler(0.0f, 0.0f, horizontal * MAX_TILT_DEGREES);
    }

    private void OnCollisionExit(Collision other)
    {
        _rigid.velocity = new Vector3(0.0f, 0.0f, 0.0f);    // Stop drifting after collision
    }
}
