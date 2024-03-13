using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Enemy : MonoBehaviour {
    public GameManager gm;
    public GameObject eBullet;
    public int speed = 10;
    public GameObject explosionPrefab;

    private int minInterval = 1;
    private int maxInterval = 1000;
    [SerializeField] private Transform shootingOffset;

    void Start() {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if (gameObject.name == "Red") {
            GameObject bOffset = new GameObject("Enemy Bullet Offset");
            bOffset.transform.parent = gameObject.transform;
            bOffset.transform.position = gameObject.transform.position + new Vector3(0, -1.001f, 0);
            shootingOffset = bOffset.GetComponent<Transform>();
        }
        else {
            shootingOffset = transform;
        }
    }

    private void Update() {
        float ePosX = shootingOffset.transform.position.x;
        float ePosY = shootingOffset.transform.position.y;
        shootingOffset.position = new Vector3(ePosX, ePosY, 0);
    }

    private void FixedUpdate() {
        int RandomInterval = Random.Range(minInterval, maxInterval);

        if (gameObject.name == "Red" && RandomInterval == 500) {
            GameObject shot = Instantiate(eBullet, shootingOffset.position, Quaternion.Euler(0, 0, -180));
            Destroy(shot, 3f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        GameObject explosion = Instantiate(explosionPrefab, collision.GetContact(0).point, Quaternion.identity);
        Animator anim = explosion.GetComponent<Animator>();
        float duration = anim.GetCurrentAnimatorStateInfo(0).length;
        
        if (gameObject.name == "Red") {
            gm.score += 100;
            gm.enemyCount--;
            
            anim.Play("enemyExplosion");
            
            Destroy(explosion, duration);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
          
        if (gameObject.name == "Yellow") {
            gm.score += 75;
            gm.enemyCount--;
            
            anim.Play("enemyExplosion");
            
            Destroy(explosion, duration);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
          
        if (gameObject.name == "Blue") {
            gm.score += 50;
            gm.enemyCount--;
            
            anim.Play("enemyExplosion");
            
            Destroy(explosion, duration);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
          
        if (gameObject.name == "Green") {
            gm.score += 25;
            gm.enemyCount--;
            
            anim.Play("enemyExplosion");
            
            Destroy(explosion, duration);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "Player") {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
