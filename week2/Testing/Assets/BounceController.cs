using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BounceController : MonoBehaviour {
    public float impactForce = 1f;

    public new AudioSource audio;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }
    
    void OnCollisionEnter (Collision other) {
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
        rb.AddForce((transform.up * impactForce), ForceMode.Impulse);
        audio.Play();
    }
}
