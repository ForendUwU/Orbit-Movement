using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreScript : MonoBehaviour
{
    public static int score;

    public Text scoreText;
    public Text GameOverScoreText;

    public static RectTransform panelWithScore;

    public static bool InGameScoreRestart;
    public static bool GameOverScoreRestart;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        if (panelWithScore != null)
        {
            if (panelWithScore.localScale == Vector3.zero)
            {
                GameOverScoreText.text = score.ToString();
                scoreText.text = score.ToString();
                panelWithScore.DOScale(Vector3.one, 0.5f);
            }
        }

        if (InGameScoreRestart)
        {
            scoreText.text = "0";
            score = 0;
            InGameScoreRestart = false;
        }

        if (GameOverScoreRestart)
        {
            GameOverScoreText.text = "0";
            GameOverScoreRestart = false;
        }
    }

    public static void ChangeScore(RectTransform panel)
    {
        ScoreScript.panelWithScore = panel;
        panel.DOScale(Vector3.zero, 0.5f);
        score++;
    }
}
