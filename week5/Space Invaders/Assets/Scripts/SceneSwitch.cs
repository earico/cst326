using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {
    void Awake() {
        DontDestroyOnLoad(gameObject);
    }
    
    public void ConsoleTest() {
        Debug.Log($"Console test invoked.");
    }
    
    public void StartGame() {
        StartCoroutine(FindPlayer());
    }

    public void EndGame() {
        StartCoroutine(Credits());
    }

    public void RestartGame() {
        StartCoroutine(Menu());
    }
    
    private void Start() {
            
    }

    private void Update() {
        if (SceneManager.GetActiveScene().name == "Credits") {
            RestartGame();
        }
    }

    IEnumerator Menu() {
        yield return new WaitForSeconds(7f);

        AsyncOperation asyncOp = SceneManager.LoadSceneAsync("Menu");
        while (!asyncOp.isDone)
            yield return null;
    }

    IEnumerator Credits() {
        yield return new WaitForSeconds(3f);
        
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync("Credits");
        while (!asyncOp.isDone)
            yield return null;
    }

    IEnumerator FindPlayer() {
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync("Game");
        while (!asyncOp.isDone)
            yield return null;
        
        GameObject playerObj = GameObject.Find("Player");
        Debug.Log(playerObj);
    }
}
