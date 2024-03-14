using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
  public GameObject bullet;
  public Transform shootingOffset;
  public int speed = 10;
  public GameObject explosionPrefab;
  public GameManager gm;
  private AudioManager am;

  private void Start() {
      am = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
  }

  void Update() {
        float movement = Input.GetAxis("Horizontal");
        Transform playerPos = GetComponent<Transform>();
        Vector3 newPos = playerPos.position + Vector3.right * movement * Time.deltaTime * speed;
        Animator anim = gameObject.GetComponentInChildren<Animator>();
        newPos.x = Mathf.Clamp(newPos.x, -17f, 17f);
        playerPos.position = newPos;
        
        if (Input.GetKeyDown(KeyCode.Space)) {
            anim.SetBool("Spacebar", true);
            am.PlaySFX("pCharge");
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            anim.SetBool("Spacebar", false);
            am.StopSFX();
            GameObject shot = Instantiate(bullet, shootingOffset.position, Quaternion.identity);
            Destroy(shot, 3f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        GameObject explosion = Instantiate(explosionPrefab, other.GetContact(0).point, Quaternion.identity);
        Animator anim = explosion.GetComponent<Animator>();
        
        am.PlaySFX("pExplosion");
        anim.Play("playerExplosion");

        float duration = anim.GetCurrentAnimatorStateInfo(0).length;

        gm.resultsText.text = "GAME OVER";
        
        Destroy(explosion, duration);
        Destroy(other.gameObject);
        Destroy(gameObject);
        
        gm.sm.EndGame();
        gm.sm.RestartGame();
    }
}