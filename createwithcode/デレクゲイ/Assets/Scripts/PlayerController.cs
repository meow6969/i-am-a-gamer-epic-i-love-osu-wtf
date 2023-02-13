using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15.0f;
    private float horizontalInput;
    private float verticalInput;
    // public GameObject camera;
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
        //transform.Translate(Vector3.x * Time.deltaTime * speed * horizontalInput);
        transform.position = new Vector3(transform.position.x + Time.deltaTime * speed * horizontalInput, transform.position.y, transform.position.z);
        //transform.Translate(Vector3.z * Time.deltaTime * speed * verticalInput);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * speed * verticalInput);

        screenCenterX = Screen.width / 2;
        screenCenterY = Screen.height / 2;
        mousePos = Input.mousePosition;
        // if the mouse is in the window
        if (mousePos.x > 0.0f && mousePos.x < Screen.width && mousePos.y > 0.0f && mousePos.y < Screen.height) {
            widthLength = screenCenterX - mousePos.x;
            heightLength = screenCenterY - mousePos.y;
            float h = Input.mousePosition.x - screenCenterX;
            float v = Input.mousePosition.y - screenCenterY;
            float angle = -Mathf.Atan2(v,h) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler (270, angle, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {

        }
    }
}
