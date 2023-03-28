using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI healthText;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject pauseScreen;
    public bool isGameActive;
    public bool paused;
    private int score = 0;
    public int lives = 3;
    private float spawnRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        isGameActive = false;
        paused = false;
        
        
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isGameActive) {
            ChangePaused();
        }
    }

    IEnumerator SpawnTarget() {
        while (isGameActive) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            SpawnTarget();
        }
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver() {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty) {
        healthText.text = "Lives: " + lives;
        isGameActive = true;
        lives = 3;
        score = 0;
        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        healthText.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    public void decreaseLives() {
        if (isGameActive) {
            lives -= 1;
        }
        healthText.text = "Lives: " + lives;
        if (lives == 0) {
            GameOver();
        }
    }

    void ChangePaused() {
        if (!paused) {
            paused = true;
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        } else {
            paused = false;
            pauseScreen.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
