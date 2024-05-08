using System.Collections;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    public static int EnemiesAlive = 0;
    public Wave[] waves;
    public Transform spawnPoint;
    public float timeBetweenWaves = 5f;
    public TextMeshProUGUI waveTimer;

    private float countdown = 3f;
    private int waveIndex;

    private void Start() {
    }

    private void Update() {
        if (EnemiesAlive > 0) {
            return;
        }
        
        if (countdown <= 0f) {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveTimer.text = string.Format("{0:00.00}", countdown);
    }

    private IEnumerator SpawnWave() {
        Debug.Log("Wave incoming!");
        PlayerStats.Rounds++;
        
        Wave wave = waves[waveIndex];
        for (var i = 0; i < wave.count; i++) {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;

        if (waveIndex == waves.Length) {
            Debug.Log("Level Won!");
            this.enabled = false;
        }
    }

    private void SpawnEnemy(GameObject enemy) {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}