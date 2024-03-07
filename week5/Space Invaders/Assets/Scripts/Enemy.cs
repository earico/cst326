using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {
    public GameManager gm;
    private int count = 0;
    private String dir = "right";
    
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision) {
      Debug.Log("Ouch!");
      if (gameObject.name == "Red(Clone)") {
          gm.score += 100;
          gm.enemyCount--;
          Destroy(gameObject);
          Destroy(collision.gameObject);
      }
      
      if (gameObject.name == "Yellow(Clone)") {
          gm.score += 75;
          gm.enemyCount--;
          Destroy(gameObject);
          Destroy(collision.gameObject);
      }
      
      if (gameObject.name == "Blue(Clone)") {
          gm.score += 50;
          gm.enemyCount--;
          Destroy(gameObject);
          Destroy(collision.gameObject);
      }
      
      if (gameObject.name == "Green(Clone)") {
          gm.score += 25;
          gm.enemyCount--;
          Destroy(gameObject);
          Destroy(collision.gameObject);
      }
    }

    private void FixedUpdate() {
        Transform enemyPos = GetComponent<Transform>();
        float startX = enemyPos.position.x;
        float startY = enemyPos.position.y;
        float multiplier = 1f;

        if (gm.enemyCount < 18) {
            multiplier = 2f;
        }

        if (gm.enemyCount < 9) {
            multiplier = 3f;
        }
        
        if (dir == "right" && count < 320) {
            Vector3 newPos = new Vector3(1, 0, 0);
            enemyPos.position += newPos * Time.deltaTime * multiplier;
            count++;
        }

        if (dir == "left" && count > -320) {
            Vector3 newPos = new Vector3(-1, 0, 0);
            enemyPos.position += newPos * Time.deltaTime * multiplier;
            count--;
        }

        if (count == 320) {
            Vector3 newPos = new Vector3(0, -0.5f, 0);
            enemyPos.position += newPos;
            dir = "left";
        }

        if (count == -320) {
            Vector3 newPos = new Vector3(0, -0.5f, 0);
            enemyPos.position += newPos;
            dir = "right";
        }
        new WaitForSeconds(1f);
    }
}
