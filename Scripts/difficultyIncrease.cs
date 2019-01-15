using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficultyIncrease : MonoBehaviour
{
    public EnemyAI enemyAI;
    public float updateRateIncrease;
    public int speedIncrease;

    int currentScore;

    private void Update()
    {
        currentScore = PlayerPrefs.GetInt("Score", 0);
        if (currentScore > 0 && currentScore % 5 == 0) {
            enemyAI.updateRate += updateRateIncrease;
            enemyAI.speed += speedIncrease;
            return;
        }
    }

}
