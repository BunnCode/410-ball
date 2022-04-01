using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balljump : MonoBehaviour {
    public float ForceOfJump = 5f;
    public float ForceOfMovement = 0.01f;

    bool canJump = false;

    private bool hasAirJumped = false;

    private Rigidbody rigidBody;
    // Start is called before the first frame update
    void Start() {
        rigidBody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision) {
        canJump = true;
        hasAirJumped = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (!canJump)
                return;
            if (!hasAirJumped) {
                hasAirJumped = true;
            }
            else {
                canJump = false;
            }
            rigidBody.AddForce(new Vector3(0, ForceOfJump, 0), ForceMode.Impulse);
        }

        Vector3 offsetDir = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical"));

        rigidBody.AddForce(offsetDir * ForceOfMovement, ForceMode.Force);
    }
}
