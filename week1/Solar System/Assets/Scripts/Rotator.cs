using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 1;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        // Transform refers to the transform component for a game object
        // Transform objects contain multiple methods for object manipulation.
        Transform rotation = GetComponent<Transform>();
        rotation.Rotate(new Vector3(0f, 45f * (Time.deltaTime * speed), 0f), Space.World);
    }
}
