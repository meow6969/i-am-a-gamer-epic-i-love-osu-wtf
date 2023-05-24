using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    public GameObject debugScreen;
    public GameObject titleScreen;
    public GameObject gameUI;
    public GameObject GameOverScreen;
    public GameObject player;
    public GameObject playerBarrel;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI enemyText;
    public bool gameActive = false;

    public bool spawnsEnabled = false;
    public bool lockControls = true;
    [SerializeField] GameObject[] spawners;
    public int round = 1;
    public int enemyCount = 0;
    private float enemySpawnTimer = 5.0f;
    [SerializeField] private int enemiesToSpawn = 0;
    public int enemies = 0;
    private int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        debugScreen.gameObject.SetActive(true);
#else
        debugScreen.gameObject.SetActive(false);
#endif
        enemiesToSpawn = GetRoundEnemyCount(round);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(titleRectTransform.rect)
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (spawnsEnabled) {
                spawnsEnabled = false;
            } else {
                spawnsEnabled = true;
            }
            debugScreen.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Spawns: " + spawnsEnabled;
        }
#endif

        if (enemies == 0 && enemiesToSpawn == 0) {
            round ++;
            roundText.text = "Round: " + round;
            enemiesToSpawn = GetRoundEnemyCount(round);
        }
        enemySpawnTimer -= Time.deltaTime;
        if (enemySpawnTimer < 0f && spawnsEnabled && enemiesToSpawn > 0) {
            int spawnerIndex = Random.Range(0, spawners.Length);
            Spawner spawnerScript = spawners[spawnerIndex].GetComponent<Spawner>();
            spawnerScript.SpawnEnemy();
            enemies ++;
            enemiesToSpawn --;
            
            enemySpawnTimer = 0.5f;
        }

        int enemiesLeft = enemies + enemiesToSpawn;
        enemyText.text = "Enemies: " + enemiesLeft;
    }

    int GetRoundEnemyCount(int r) {
        return (int)(Mathf.Pow(0.000058f * r, 3) + Mathf.Pow(0.074032f * r, 2) + 0.718119f * r + 5.738699f);
    }

    public void StartGame() {
        spawnsEnabled = true;
        lockControls = false;
        gameActive = true;
        titleScreen.SetActive(false);
        gameUI.SetActive(true);
        player.GetComponent<MeshRenderer>().enabled = true;
        playerBarrel.GetComponent<MeshRenderer>().enabled = true;
    }

    public void EndGame(int score) {
        gameActive = false;
        spawnsEnabled = false;
        lockControls = true;
        gameUI.SetActive(false);
        GameOverScreen.SetActive(true);
        GameOverScreen.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = "Score: " + score;
        LoadFile();
        if (highScore < score) {
            GameOverScreen.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "You got a new highscore!";
            SaveFile(score);
        } else {
            GameOverScreen.transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = "Highscore: " + highScore;
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SaveFile(int score) {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) {
            file = File.OpenWrite(destination);
        } else {
            file = File.Create(destination);
        }

        GameData data = new GameData(score);
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadFile() {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) {
            file = File.OpenRead(destination);
            BinaryFormatter bf = new BinaryFormatter();
            GameData data = (GameData) bf.Deserialize(file);
            file.Close();

            highScore = data.score;

            Debug.Log(data.score);
        } else {
            highScore = 0;
        }
    }
}

[System.Serializable] public class GameData {
    public int score;

    public GameData(int scoreInt) {
        score = scoreInt;
    }
}
