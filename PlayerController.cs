using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Variables
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI targetText;

    private Animator animator;
    private AudioSource playerAudio;
    private AudioSource engineAudio;
    private AudioSource musicAudio;

    public AudioClip scoreSound;
    public AudioClip crashSound;

    private GameManager gameManager;

    private float horizontalInput;
    private float verticalInput;
    private float sideInput;
    private float upperInput;

    public float speed;
    private float maxSpeed = 10f;
    private float rotationSpeed = 10f;

    private int score;
    private int targetNum = 20;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        engineAudio = GameObject.Find("Engine").GetComponent<AudioSource>();
        musicAudio = GameObject.Find("Music").GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        UpdateUI();
        LandingGear();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            Destroy(other.gameObject);
            score++;
            playerAudio.PlayOneShot(scoreSound);
        }

        if (other.CompareTag("Last Target"))
        {
            gameManager.EndGame();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Crash"))
        {
            gameManager.GameOver();
            playerAudio.PlayOneShot(crashSound);
            engineAudio.Stop();
            musicAudio.Stop();     
        }
    }

    void Move()
    {
        // Move the plane foward depending on its speed
        transform.Translate(speed * Time.deltaTime * Vector3.forward);

        // W & S to change the x rotation and A & D to change the z rotation
        if (transform.position.y > 1 || speed > 5)
        {
            verticalInput = Input.GetAxis("Vertical");
            transform.Rotate(verticalInput * rotationSpeed * Time.deltaTime * Vector3.right);

            horizontalInput = Input.GetAxis("Horizontal");
            transform.Rotate(horizontalInput * rotationSpeed * Time.deltaTime * Vector3.back);
        }

        // Q & E to change the y rotation
        sideInput = Input.GetAxis("LR");
        transform.Rotate(sideInput * rotationSpeed * Time.deltaTime * Vector3.up);

        // Left Shift & Left Control to accelerate and decelerate
        upperInput = Input.GetAxis("UD");
        speed += upperInput * Time.deltaTime;
        speed = Mathf.Clamp(speed, 0, maxSpeed);
    }

    void UpdateUI()
    {
        speedText.text = "Speed: " + speed;
        targetText.text = "Score: " + score + "/" + targetNum;
        engineAudio.volume = speed/10;

        if (transform.position.y > 1 || speed > 5)
        {
            if (!musicAudio.isPlaying || !gameManager.isGameActive)
            {
                musicAudio.Play();
            }

            gameManager.tiltsUI.SetActive(true);
        }

        else
        {
            gameManager.tiltsUI.SetActive(false);
        }
    }

    void LandingGear()
    {
        if (transform.position.y > 5)
        {
            animator.SetBool("isInTheAir", true);
        }

        else
        {
            animator.SetBool("isInTheAir", false);
        }
    }
}
