using System;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 70f;
    public float explosionRadius = 0f;
    public int damage = 50;
    public GameObject impactEffect;
    private Transform target;


    private void Update() {
        if (target == null) {
            Destroy(gameObject);
            return;
        }

        var dir = target.position - transform.position;
        var distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame) {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    public void Seek(Transform _target) {
        target = _target;
    }

    private void HitTarget() {
        var effectIns = Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 5f);

        if (explosionRadius > 0f) {
            Explode();
        }
        else {
            Damage(target);
        }
        
        Destroy(gameObject);
    }

    void Explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders) {
            if (collider.tag == "Enemy")
                Damage(collider.transform);
        }
    }

    void Damage(Transform enemy) {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
            e.TakeDamage(damage);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}