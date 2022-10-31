using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private float timer;
    private float spawnLimit = 1.0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        // On spacebar press, send dog
        //Debug.Log(timer);
        if (Input.GetKeyDown(KeyCode.Space) && timer > spawnLimit)
        {
            timer = 0;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
