using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour {
    public int score, hiScore = 0;
    public int enemyCount = 36;
    public TextMeshProUGUI scoreText, hiScoreText;
    public GameObject red, yellow, blue, green, barricade;
    public GameObject enemyStart;
    public GameObject barricadeStart;
    
    // Start is called before the first frame update
    void Start() {
        SetScoreText();
        Setup();
    }

    void Setup() {
        float eMatrixY = enemyStart.transform.position.y;
        float eMatrixX = enemyStart.transform.position.x;
        Vector3 bStart = barricadeStart.gameObject.transform.position;
        for (int i = 8; i > 0; i-=2) {
            for (int j = 0; j < 18; j+=2) {
                Vector3 spawnPos = new Vector3(eMatrixX, eMatrixY, 0);
                if (i == 8) {
                    GameObject newEnemy = Instantiate(red, spawnPos, Quaternion.identity);
                    Enemy eComp = newEnemy.GetComponent<Enemy>();
                    eComp.gm = FindObjectOfType<GameManager>();
                }
                
                else if (i == 6) {
                    GameObject newEnemy = Instantiate(yellow, spawnPos, Quaternion.identity);
                    Enemy eComp = newEnemy.GetComponent<Enemy>();
                    eComp.gm = FindObjectOfType<GameManager>();
                }
                
                else if (i == 4) {
                    GameObject newEnemy = Instantiate(blue, spawnPos, Quaternion.identity);
                    Enemy eComp = newEnemy.GetComponent<Enemy>();
                    eComp.gm = FindObjectOfType<GameManager>();
                }
                
                else if (i == 2) {
                    GameObject newEnemy = Instantiate(green, spawnPos, Quaternion.identity);
                    Enemy eComp = newEnemy.GetComponent<Enemy>();
                    eComp.gm = FindObjectOfType<GameManager>();
                }
                
                eMatrixX += 2;
            }
            eMatrixY -= 2;
            eMatrixX -= 18;
        }

        for (int i = 0; i < 4; i++) {
            Instantiate(barricade, bStart, Quaternion.identity);
            bStart += new Vector3(8, 0, 0);
        }
    }
    
    public void SetScoreText() {
        if (score > hiScore) {
            hiScore = score;
        }
        scoreText.text = $"SCORE\n{score:0000}";
        hiScoreText.text = $"HI-SCORE\n{hiScore:0000}";
    }
    
    // Update is called once per frame
    void Update() {
        SetScoreText();
    }
}
