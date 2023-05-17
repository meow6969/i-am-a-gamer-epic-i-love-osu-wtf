using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScale : MonoBehaviour
{
    private Renderer rend;
    public float scaleX = 4f;
    public float scaleY = 4f;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Animates main texture scale in a funky way!
        // float scaleX = Mathf.Cos(Time.time) * 0.5f + 1;
        // float scaleY = Mathf.Sin(Time.time) * 0.5f + 1;
        rend.material.SetTextureScale("_MainTex", new Vector2(scaleX, scaleY));
    }
}
