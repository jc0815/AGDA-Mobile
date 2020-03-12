using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonobehaviorSingleton<ScoreController>
{
    private float currentScore;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentScore += Time.deltaTime;
        BattleMenuController.Instance.UpdateScore((int)currentScore*GameConstants.SCORE_MULTIPLIER_BY_TIME);
    }

    public int GetCurrentScore()
    {
        return (int)currentScore;
    }
}
