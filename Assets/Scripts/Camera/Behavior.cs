using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour {
    public Transform target;

    [SerializeField]
    private Vector3 offsetPosition = new Vector3(0.0f, 3.0f, -5.0f);

    private Space offsetPostionSpace = Space.Self;

    private void Start() {
        transform.position = target.TransformPoint(offsetPosition);
    }

    private void Update() {
        Refresh ();
    }

    public void Refresh() {
        if (target == null) {
            return;
        }

        transform.position = target.position + offsetPosition;
        transform.LookAt(target);
    }

}
