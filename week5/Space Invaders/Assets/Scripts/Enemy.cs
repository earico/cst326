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
    private AudioManager am;
    private AudioSource aSrc;

    void Start() {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        am = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        aSrc = gameObject.AddComponent<AudioSource>();
        aSrc.clip = am.enemyExpl;
        aSrc.volume = 0.2f;
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
            am.PlaySFX("eShoot");
            GameObject shot = Instantiate(eBullet, shootingOffset.position, Quaternion.Euler(0, 0, -180));
            Destroy(shot, 3f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        GameObject explosion = Instantiate(explosionPrefab, collision.GetContact(0).point, Quaternion.identity);
        Animator anim = explosion.GetComponent<Animator>();
        float duration = anim.GetCurrentAnimatorStateInfo(0).length;
        BoxCollider2D col2D = GetComponent<BoxCollider2D>();
        
        if (gameObject.name == "Red") {
            Transform childObj = gameObject.transform.Find("RedEnemyIdle_0");
            SpriteRenderer sprite = childObj.GetComponent<SpriteRenderer>();
            gm.score += 100;
            gm.enemyCount--;
            
            aSrc.Play();
            anim.Play("enemyExplosion");
            col2D.enabled = false;
            sprite.enabled = false;
            
            Destroy(explosion, duration);
            Destroy(gameObject, duration);
            Destroy(collision.gameObject);
        }
          
        if (gameObject.name == "Yellow") {
            Transform childObj = gameObject.transform.Find("YellowEnemyIdle_0");
            SpriteRenderer sprite = childObj.GetComponent<SpriteRenderer>();
            gm.score += 75;
            gm.enemyCount--;
            
            aSrc.Play();
            anim.Play("enemyExplosion");
            col2D.enabled = false;
            sprite.enabled = false;
            
            Destroy(explosion, duration);
            Destroy(gameObject, duration);
            Destroy(collision.gameObject);
        }
          
        if (gameObject.name == "Blue") {
            Transform childObj = gameObject.transform.Find("BlueEnemyIdle_0");
            SpriteRenderer sprite = childObj.GetComponent<SpriteRenderer>();
            gm.score += 50;
            gm.enemyCount--;
            
            aSrc.Play();
            anim.Play("enemyExplosion");
            col2D.enabled = false;
            sprite.enabled = false;
            
            Destroy(explosion, duration);
            Destroy(gameObject, duration);
            Destroy(collision.gameObject);
        }
          
        if (gameObject.name == "Green") {
            Transform childObj = gameObject.transform.Find("GreenEnemyIdle_0");
            SpriteRenderer sprite = childObj.GetComponent<SpriteRenderer>();
            gm.score += 25;
            gm.enemyCount--;
            
            aSrc.Play();
            anim.Play("enemyExplosion");
            col2D.enabled = false;
            sprite.enabled = false;
            
            Destroy(explosion, duration);
            Destroy(gameObject, duration);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.name == "Player") {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
