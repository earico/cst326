using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
