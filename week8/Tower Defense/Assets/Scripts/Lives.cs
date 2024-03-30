using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Lives : MonoBehaviour {
    public TextMeshProUGUI livesText;
    
    void Update() {
        livesText.text = PlayerStats.Lives + " LIVES";
    }
}
