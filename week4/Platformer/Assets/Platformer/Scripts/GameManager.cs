using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        int intTime = 400 - (int)Time.realtimeSinceStartup;
        timerText.text = $"TIME\n{intTime}";
    }
}
