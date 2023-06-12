using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    private int score = 0;
    public bool isGameOver;
    public Text scoreText;
    public Text gameOverText;
    public Button restartButton;
    public GameObject titleScreen;

    
    public void StartGame(int difficulty) {
        Debug.Log("IN start game");

        spawnRate /= difficulty;
        isGameOver = false;
        titleScreen.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
    }
    IEnumerator SpawnTarget() {
        while (!isGameOver) {
            Debug.Log("In spawning");

            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }
    public void UpdateScore(int scoretoAdd) {
        score += scoretoAdd;
        if (score < 0)
            score = 0;
        scoreText.text = "Score: " + score;
    }
    public void GameOver() {
        restartButton.gameObject.SetActive(true);
        isGameOver = true;
        gameOverText.gameObject.SetActive(true);
    }
    public void RestartButton() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
