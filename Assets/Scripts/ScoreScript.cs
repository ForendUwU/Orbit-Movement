using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreScript : MonoBehaviour
{
    private static int score;

    public Text scoreText;

    public static RectTransform panelWithScore;

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
                scoreText.text = score.ToString();
                panelWithScore.DOScale(Vector3.one, 0.5f);
            }
        }
    }

    public static void ChangeScore(RectTransform panel)
    {
        ScoreScript.panelWithScore = panel;
        panel.DOScale(Vector3.zero, 0.5f);
        score++;
    }
}
