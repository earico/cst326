using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnTransform;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = spawnTransform.position;
        Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        int rand = Random.Range(-4, 4);
        if (Input.GetKeyDown(KeyCode.Space)) {
            Vector3 spawnPosition = spawnTransform.position + new Vector3(0, 0, rand);
            Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
