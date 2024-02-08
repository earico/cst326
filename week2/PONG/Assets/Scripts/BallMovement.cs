using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    public float unitsPerSec;
    // Start is called before the first frame update
    void Start() {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-6, 0, 0);
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void FixedUpdate() {
        Rigidbody rb = GetComponent<Rigidbody>();

    }
}
