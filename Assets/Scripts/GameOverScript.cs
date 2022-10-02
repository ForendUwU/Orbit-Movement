using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public RectTransform GameOverPanel;
    public RectTransform ScorePanel;
    public GameObject Player;
    public static void GameOver(RectTransform GameOverPanel)
    {
        CanvasGroup gameOverPanelCanvasGroup = GameOverPanel.GetComponent<CanvasGroup>();
        Sequence gameOverSequence = DOTween.Sequence();
        gameOverSequence.Append(GameOverPanel.DOLocalMoveX(0, 1f));
        gameOverSequence.Join(gameOverPanelCanvasGroup.DOFade(1, 1.5f))
            .OnComplete(() => gameOverSequence.Kill());
    }

    public void Restart()
    {
        CanvasGroup gameOverPanelCanvasGroup = GameOverPanel.GetComponent<CanvasGroup>();
        Sequence gameOverSequence = DOTween.Sequence();
        gameOverSequence.Append(GameOverPanel.DOLocalMoveX(-Screen.width, 1f));
        gameOverSequence.Join(gameOverPanelCanvasGroup.DOFade(0, 1.5f))
            .OnComplete(() =>
            {
                ScoreScript.GameOverScoreRestart = true;
                gameOverSequence.Kill();
            });
        ScoreScript.InGameScoreRestart = true;
        PlayerControl.IsGameOver = true;
        Player.SetActive(true);
    }
}
