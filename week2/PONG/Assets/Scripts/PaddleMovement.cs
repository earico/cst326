 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {
    public float unitsPerSecond = 3f;
    // Start is called before the first frame update
    void Start() {
        
    }

    private void FixedUpdate() {
        float leftPad = Input.GetAxis("LeftPaddle");
        float rightPad = Input.GetAxis("RightPaddle");
        //float VerticalValueY = Input.GetAxis("");
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 force;

        if (rb.name == "Left Paddle") {
            force = Vector3.up * leftPad;
            rb.velocity = new Vector3(0, 10, 0) * leftPad;
            //rb.AddForce(force, ForceMode.Acceleration);
        }

        if (rb.name == "Right Paddle") {
            force = Vector3.up * rightPad;
            rb.velocity = new Vector3(0, 10, 0) * rightPad;
            //rb.AddForce(force, ForceMode.Acceleration);
        }
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Ball") {
            Debug.Log($"we  hit {collision.gameObject.name}");

            // get reference to paddle collider
            BoxCollider bc = GetComponent<BoxCollider>();
            Bounds bounds = bc.bounds;
            float maxX = bounds.max.x;
            float maxY = bounds.max.y;
            float minX = bounds.min.x;
            float minY = bounds.min.y;
            Debug.Log($"maxX = {maxX}, maxY = {maxY}, minX = {minX}, minY = {minY}");

            Quaternion bounceRotation = Quaternion.Euler(0f, 0f, 60f);
            Vector3 bounceDirection = bounceRotation * Vector3.up;

            Rigidbody rb = collision.rigidbody;
            //rb.AddForce(bounceDirection * 1f, ForceMode.VelocityChange);
            rb.velocity = -rb.velocity * unitsPerSecond;
            bounceRotation = Quaternion.Euler(0f, 0f, 0f);
            unitsPerSecond += 0.5f;
        }
    }
}
