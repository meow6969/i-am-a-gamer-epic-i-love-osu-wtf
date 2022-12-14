using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10;
    public float gravityModifier = 1;
    public int score = 0;
    public float walkSpeed = 5.0f;
    public bool isOnGround = true;
    public bool gameOver = false;
    public bool doubleJump = false;
    public bool gameReady = false;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameReady) {
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) { 
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                playerAnim.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpSound, 1.0f);
            } else if (Input.GetKeyDown(KeyCode.Space) && doubleJump && !gameOver) {
                playerRb.velocity = new Vector3(playerRb.velocity.x, 0f, playerRb.velocity.z);
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                // playerAnim.SetTrigger("Jump_trig");
                // dirtParticle.Stop();
                playerAudio.PlayOneShot(jumpSound, 1.0f);
                doubleJump = false;
            }

            if(Input.GetKey("left shift") && isOnGround && !gameOver) {
                playerAnim.speed = 2.0f;
            }
            else {
                playerAnim.speed = 1.0f;
            }
        } else {
            //playerAnim.SetTrigger("Walk");
            dirtParticle.Stop();
            if (transform.position.x > 1) {
                gameReady = true;
                playerAnim.SetFloat("Speed_f", 5.0f);
            } else {
                transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground") && gameReady) {
            isOnGround = true;
            dirtParticle.Play();
            doubleJump = true;
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        } else if (collision.gameObject.CompareTag("ScoreCounter")) {
            score += 1;
            Destroy(collision.gameObject);
        }
    }

    void OnGUI() {
        GUI.Label(new Rect(10, 10, 200, 40), $"Score: {score}" );
    }
}
