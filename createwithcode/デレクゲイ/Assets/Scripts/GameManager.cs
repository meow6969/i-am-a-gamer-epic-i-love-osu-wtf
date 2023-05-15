using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject debugScreen;
    public bool spawnsEnabled = true;
    [SerializeField] GameObject[] spawners;
    public int round = 1;
    public int enemyCount = 0;
    private float enemySpawnTimer = 5.0f;
    private int enemiesToSpawn = 0;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        debugScreen.gameObject.SetActive(true);
#else
        debugScreen.gameObject.SetActive(false);
#endif

    }

    // Update is called once per frame
    void Update()
    {
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

        if (enemies )
        enemySpawnTimer -= Time.deltaTime;
        if (enemySpawnTimer < 0f && spawnsEnabled && enemies > 0) {
            int spawnerIndex = Random.Range(0, spawners.Length);
            Spawner spawnerScript = spawners[spawnerIndex].GetComponent<Spawner>();
            spawnerScript.SpawnEnemy();
            enemySpawnTimer = 0.5f;
        }
    }

    int GetRoundEnemyCount(int r) {
        return (int)(Mathf.Pow(0.000058 * r, 3) + Mathf.Pow(0.074032 * r, 2) + 0.718119 * r + 5.738699);
    }
}
