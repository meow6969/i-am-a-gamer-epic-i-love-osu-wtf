using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject debugScreen;
    public GameObject titleScreen;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI enemyText;
    public bool gameActive = false;

    public bool spawnsEnabled = true;
    [SerializeField] GameObject[] spawners;
    public int round = 1;
    public int enemyCount = 0;
    private float enemySpawnTimer = 5.0f;
    [SerializeField] private int enemiesToSpawn = 0;
    public int enemies = 0;

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
}
