using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public TextMeshProUGUI waveTimer;

    private float countdown = 3f;
    private int waveIndex = 0;

    void Start() {
        
    }

    void Update() {
        if (countdown <= 0f) {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        waveTimer.text = $"Next Wave : {Mathf.Round(countdown)}";
    }

    IEnumerator SpawnWave() {
        Debug.Log($"Wave incoming!");
        waveIndex++;
        for (int i = 0; i < waveIndex; i++) {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemy() {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
