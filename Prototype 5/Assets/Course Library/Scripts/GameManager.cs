using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverMenu;
    public GameObject startMenu;

    public bool isGameActive;

    private float spawnRate = 1.5f;
    private float difficulty = 1f;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        startMenu.SetActive(true);
        gameOverMenu.SetActive(false);
        scoreText.gameObject.SetActive(false);
    }

    private void InitScore()
    {
        score = 0;
        scoreText.gameObject.SetActive(true);
        UpdateScoreDisplay();
    }

    public void StartGame(int gameDifficulty)
    {
        spawnRate /= gameDifficulty;
        startMenu.SetActive(false);
        isGameActive = true;
        InitScore();
        StartCoroutine(SpawnTarget());
    }

    public void SetDifficulty(int newDifficulty)
    {
        difficulty = newDifficulty;
    }
    private void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreDisplay();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        isGameActive = false;
        gameOverMenu.SetActive(true);
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
}
