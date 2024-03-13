using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {
    public TMPro.TextMeshProUGUI titleText;

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
    
    public void ConsoleTest() {
        Debug.Log($"Console test invoked.");
    }
    
    public void StartGame() {
        StartCoroutine(FindPlayer());
    }

    IEnumerator FindPlayer() {
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync("Game");
        while (!asyncOp.isDone)
            yield return null;
        
        GameObject playerObj = GameObject.Find("Player");
        Debug.Log(playerObj);
    }
}
