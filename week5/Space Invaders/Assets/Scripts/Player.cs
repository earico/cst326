using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  public GameObject bullet;
  public Transform shootingOffset;
  public int speed = 10;
    // Update is called once per frame
    void Update() {
        float movement = Input.GetAxis("Horizontal");
        Transform playerPos = GetComponent<Transform>();
        Vector3 newPos = playerPos.position + Vector3.right * movement * Time.deltaTime * speed;
        newPos.x = Mathf.Clamp(newPos.x, -17f, 17f);
        playerPos.position = newPos;
        
        if (Input.GetKeyDown(KeyCode.Space)) { 
            GameObject shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);
            Debug.Log("Bang!");
            Destroy(shot, 3f);
            Debug.Log(playerPos.position);
        }
    }
}