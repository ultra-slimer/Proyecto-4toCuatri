using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public TileBoard board;
    public CanvasGroup gameOver;
    public CanvasGroup victory;
    public float gameOverFadeDelay;

    private void Start()
    {
        NewGame();
    }

    public void NewGame()
    {
        gameOver.alpha = 0;
        gameOver.interactable = false;
        gameOver.blocksRaycasts = false;
        victory.alpha = 0;
        victory.interactable = false;
        victory.blocksRaycasts = false;
        board.reachedObjective = false;
        board.ClearBoard();
        board.CreateTile();
        board.CreateTile();
        board.enabled = true;
    }

    public void GameOver()
    {
        board.enabled = false;
        gameOver.interactable = true;
        gameOver.blocksRaycasts = true;
        StartCoroutine(Fade(gameOver, 1f, gameOverFadeDelay));
    }
    private IEnumerator Fade(CanvasGroup canvasGroup, float to, float delay)
    {
        yield return new WaitForSeconds(delay);

        float elapsed = 0f;
        float duration = 0.5f;
        float from = canvasGroup.alpha;

        while (elapsed < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
    }

    public void Victory()
    {
        board.enabled = false;
        victory.interactable = true;
        victory.blocksRaycasts = true;
        StartCoroutine(Fade(victory, 1f, gameOverFadeDelay));
    }
}
