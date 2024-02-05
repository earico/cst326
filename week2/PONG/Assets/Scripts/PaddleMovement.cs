using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour {
    public float unitsPerSecond = 3f;
    // Start is called before the first frame update
    void Start() {
        
    }

    private void FixedUpdate() {
        float horizontalValue = Input.GetAxis("Horizontal");
        Vector3 force = Vector3.right * horizontalValue;// * unitsPerSecond * Time.deltaTime;

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(force, ForceMode.Force);
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

            Debug.Log($"maxX = {maxX}, maxY = {maxY}");

            Quaternion bounceRotation = Quaternion.Euler(0f, 0f, 60f);
            Vector3 bounceDirection = bounceRotation * Vector3.up;

            Rigidbody rb = collision.rigidbody;
            rb.AddForce(bounceDirection * 300f, ForceMode.Force);
        }
    }
}
