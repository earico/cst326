using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    private Rigidbody2D myRigidbody2D;
    private AudioManager am;
    private AudioSource aSrc;
    public float speed = 5;
    
    void Start() {
        am = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        aSrc = gameObject.AddComponent<AudioSource>();
        aSrc.clip = am.enemyShoot;
        aSrc.volume = 0.2f;
        myRigidbody2D = GetComponent<Rigidbody2D>();
        Fire();
    }
    
    private void Fire() {
        aSrc.Play();
        myRigidbody2D.velocity = Vector2.down * speed;
    }
}
