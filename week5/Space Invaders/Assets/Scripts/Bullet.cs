using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class Bullet : MonoBehaviour
{
  private Rigidbody2D myRigidbody2D;
  private AudioManager am;
  private AudioSource aSrc;
  public float speed = 5;
    // Start is called before the first frame update
    void Start() {
      am = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
      aSrc = gameObject.AddComponent<AudioSource>();
      aSrc.clip = am.playerShoot;
      aSrc.volume = 0.2f;
      myRigidbody2D = GetComponent<Rigidbody2D>();
      Fire();
    }

    // Update is called once per frame
    private void Fire() {
      aSrc.Play();
      myRigidbody2D.velocity = Vector2.up * speed; 
      //Debug.Log("Wwweeeeee");
    }
}