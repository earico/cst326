using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour {
    [FormerlySerializedAs("speed")]
    public float acceleration = 10f;
    public float maxSpeed = 10f;
    public float jumpImpulse = 50f;
    public float jumpBoost = 3f;
    public bool isGrounded;
    public Camera playerCam;
    public GameManager gm;
    // Start is called before the first frame update
    void Start() {
        
    }

    void FixedUpdate() {
        
    }
    
    // Update is called once per frame
    void Update() {
        float horizontalMovement = Input.GetAxis("Horizontal");
        Rigidbody rbody = GetComponent<Rigidbody>();
        rbody.velocity += Vector3.right * horizontalMovement * Time.deltaTime * acceleration;
        Transform playerPos = GetComponent<Transform>();
        playerCam.GetComponent<Transform>().position = new Vector3(playerPos.position.x, 7.5f, -10f);
        
        Vector3 startPoint = transform.position;
        Vector3 endPoint = startPoint + Vector3.down * 2f;

        Collider col = GetComponent<Collider>();
        float halfHeight = col.bounds.extents.y + 0.03f;
        
        isGrounded = (Physics.Raycast(startPoint, Vector3.down, halfHeight));
        
        // Debugs
        Color lineColor = (isGrounded) ? Color.red : Color.blue;
        //Debug.DrawLine(startPoint, endPoint, lineColor, 0f, false);
        //Debug.Log(rbody.velocity);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            rbody.AddForce(Vector3.up * jumpImpulse, ForceMode.Impulse);
        }
        
        else if (!isGrounded && Input.GetKey(KeyCode.Space)) {
            if (rbody.velocity.y > 0)
                rbody.AddForce(Vector3.up * jumpBoost, ForceMode.Force);
        }
        
        if (Math.Abs(rbody.velocity.x) > maxSpeed) {
            Vector3 newVel = rbody.velocity;
            newVel.x = Math.Clamp(newVel.x, -maxSpeed, maxSpeed);
            rbody.velocity = newVel;
        }

        if (isGrounded && Math.Abs(horizontalMovement) < 0.5f) {
            Vector3 newVel = rbody.velocity;
            newVel.x *= 1f - Time.deltaTime;
            rbody.velocity = newVel;
        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            maxSpeed = 15f;
        }

        else {
            maxSpeed = 10f;
        }

        float yaw = (rbody.velocity.x > 0) ? 90 : -90;
        transform.rotation = Quaternion.Euler(0f, yaw, 0f);

        float speed = rbody.velocity.x;
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("Speed", Math.Abs(speed));
        anim.SetBool("In Air", !isGrounded);
    }
    
    private void OnCollisionEnter(Collision other) {
        CapsuleCollider col = GetComponent<CapsuleCollider>();
        float colMax = col.bounds.max.y;
        float blkMin = other.collider.bounds.min.y;
        
        //Debug.Log($"{colMax} : boxCol Top --- {blkMin} : brickCol bot");
        
        if (other.gameObject.name == "Brick(Clone)" && colMax == blkMin) {
            gm.brickBreak.Play();
            gm.score += 100;
            gm.SetTextUpdate();
            Destroy(other.gameObject);
            Debug.Log("hit a brick !!!");
        }

        if (other.gameObject.name == "Question(Clone)" && colMax == blkMin) {
            gm.coinGet.Play();
            gm.coins++;
            gm.score += 100;
            gm.SetTextUpdate();
            Debug.Log("hit questions!!");
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "Goal(Clone)") {
            Debug.Log("You Win!!!! YESS!!!!");
        }

        if (other.gameObject.name == "Domo(Clone)") {
            Destroy(gameObject);
        }
    }
}
