using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class SlotTrigger : MonoBehaviour
{
    public int slotNumber;

    public int points;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log($"Entered slot {slotNumber} and got {points}");
        Destroy(other.GameObject());
    }
}
