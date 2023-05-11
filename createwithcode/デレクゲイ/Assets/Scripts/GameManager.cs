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
    }
}
