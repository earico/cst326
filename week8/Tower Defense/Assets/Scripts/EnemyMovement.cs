using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {
    private Transform target;
    private int wavepointIndex;

    private Enemy enemy;

    private void Start() {
        enemy = GetComponent<Enemy>();
        target = Waypoints.waypoints[wavepointIndex];
    }
    
    private void Update() {
        var dir = target.position - transform.position;
        transform.Translate(dir.normalized * Time.deltaTime * enemy.speed, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f) GetNextWaypoint();

        enemy.speed = enemy.startSpeed;
    }

    private void GetNextWaypoint() {
        if (wavepointIndex >= Waypoints.waypoints.Length - 1) {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }

    void EndPath() {
        PlayerStats.Lives--;
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
