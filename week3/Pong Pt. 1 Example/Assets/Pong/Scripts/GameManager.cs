using System;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Transform ball;
    public float startSpeed = 3f;
    public GoalTrigger leftGoalTrigger;
    public GoalTrigger rightGoalTrigger;
    public AudioSource audio;
    public float audPitch = 1;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOver;
    private String colorState1 = "#ffffff";
    private String colorState2 = "#ffffff";
    

    int leftPlayerScore = 0;
    int rightPlayerScore = 0;
    Vector3 ballStartPos;

    const int scoreToWin = 11;

    //---------------------------------------------------------------------------
    void Start() {
        scoreText.text = $"{leftPlayerScore} - {rightPlayerScore}";
        gameOver.text = "";
        ballStartPos = ball.position;
        Rigidbody ballBody = ball.GetComponent<Rigidbody>();
        ballBody.velocity = new Vector3(1f, 0f, 0f) * startSpeed;
    }

    //---------------------------------------------------------------------------
    public void OnGoalTrigger(GoalTrigger trigger)
    {
        // If the ball entered a goal area, increment the score, check for win, and reset the ball

        if (trigger == leftGoalTrigger) {
            rightPlayerScore++;
            Debug.Log($"Right player scored: {rightPlayerScore}");

            if (rightPlayerScore == scoreToWin) {
                rightPlayerScore++;
                Debug.Log("Right player wins!");
                gameOver.text = $"PLAYER 2 WINS!";
            }
            else {
                if (leftPlayerScore < 4) {
                    colorState2 = "#008000";
                }
                else if (leftPlayerScore >= 4 && leftPlayerScore <= 7) {
                    colorState2 = "#FFFF00";
                }
                else {
                    colorState2 = "#FF0000";
                }
                scoreText.text = 
                    $"<color={colorState1}>{leftPlayerScore}</color> - <color={colorState2}>{rightPlayerScore}</color>";
                ResetBall(-1f);
                audPitch = 1;
            }
        }
        else if (trigger == rightGoalTrigger) {
            leftPlayerScore++;
            Debug.Log($"Left player scored: {leftPlayerScore}");

            if (leftPlayerScore == scoreToWin) {
                leftPlayerScore++;
                Debug.Log("Left player wins!");
                gameOver.text = $"PLAYER 1 WINS!";
            }

            else {
                if (rightPlayerScore < 4) {
                    colorState1 = "#008000";
                }
                else if (rightPlayerScore >= 4 && rightPlayerScore <= 7) {
                    colorState1 = "#FFFF00";
                }
                else {
                    colorState1 = "#FF0000";
                }
                scoreText.text = 
                    $"<color={colorState1}>{leftPlayerScore}</color> - <color={colorState2}>{rightPlayerScore}</color>";
                ResetBall(1f);
                audPitch = 1;
            }
                
        }
    }

    //---------------------------------------------------------------------------
    void ResetBall(float directionSign)
    {
        ball.position = ballStartPos;

        // Start the ball within 20 degrees off-center toward direction indicated by directionSign
        directionSign = Mathf.Sign(directionSign);
        Vector3 newDirection = new Vector3(directionSign, 0f, 0f) * startSpeed;
        newDirection = Quaternion.Euler(0f, Random.Range(-20f, 20f), 0f) * newDirection;

        var rbody = ball.GetComponent<Rigidbody>();
        rbody.velocity = newDirection;
        rbody.angularVelocity = new Vector3();

        // We are warping the ball to a new location, start the trail over
        ball.GetComponent<TrailRenderer>().Clear();
    }
}
