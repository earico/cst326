using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {
    public ScoreMan scores;
    // Start is called before the first frame update
    void Start() {
        Rigidbody rb = GetComponent<Rigidbody>();

        if (scores.lastScorer == "P1") {
            rb.velocity = new Vector3(-10, 0, 0);
        }

        if (scores.lastScorer == "P2") {
            rb.velocity = new Vector3(10, 0, 0);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void FixedUpdate() {
        Rigidbody rb = GetComponent<Rigidbody>();

    }
}
