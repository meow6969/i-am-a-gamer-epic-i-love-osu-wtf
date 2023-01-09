using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15.0f;
    private float horizontalInput;
    private float verticalInput;
    public GameObject camera;
    public float angle = 0.0f;
    private Vector3 mousePos;
    private float screenCenterX;
    private float screenCenterY;
    private float widthLength;
    private float heightLength;
    private float hypotenuseLength;

    // Start is called before the first frame update
    void Start()
    {
        screenCenterX = Screen.width / 2;
        screenCenterY = Screen.height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = -Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        screenCenterX = Screen.width / 2;
        screenCenterY = Screen.height / 2;
        mousePos = new Vector3 Input.mousePosition;
        // if the mouse is in the window
        if (mousePos.x > 0.0f && mousePos.x < Screen.width && mousePos.y > 0.0f && mousePos.y < Screen.height) {
            widthLength = screenCenterX - mousePos.x;
            heightLength = screenCenterY - mousePos.y;
            hypotenuseLength = Mathf.Sqrt(Mathf.Pow(widthLength, 2.0f) + Mathf.Pow(heightLength, 2.0f));
            if (mousePos.x > screenCenterX && mousePos.y > screenCenterY) {
                
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {

        }

        if (transform.position.x > 30) {
            transform.position = new Vector3(30, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -30) {
            transform.position = new Vector3(-30, transform.position.y, transform.position.z);
        }
        if (transform.position.z > 30) {
            transform.position = new Vector3(transform.position.x, transform.position.y, 30);
        }
        else if (transform.position.z < -30) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -30);
        }
    }
}
