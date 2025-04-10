using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float jumpforce = 10;
    public int coins = 0;
    public int health = 99; // Starting HP
    public float killHeight = -5;
    public float stunTimer = 5;

    private Vector3 respawnPoint;
    private Rigidbody rigidbody;

    public bool goingLeft = false;
    public TMP_Text livesText;
    public TMP_Text coinText;

    private bool isInvincible = false; // Tracks invincibility state

    private Renderer playerRenderer; // Player renderer for blinking effect

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        respawnPoint = transform.position;
        playerRenderer = GetComponent<Renderer>(); // Get the renderer for the blinking effect

        UpdateCoinUI();
        UpdateLivesUI();
    }

    private void Update()
    {
        Jump();
        if (transform.position.y < killHeight)
            LoseHealth();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.D))
        {
            //Moves the player to the right
            //transform.position += Vector3.right * speed * Time.deltaTime; 
            rigidbody.MovePosition(transform.position + (Vector3.right * speed * Time.deltaTime));
            transform.rotation = Quaternion.Euler(0, 360, 0);
            goingLeft = false;
        }

        //Checks for the left input (A/LeftArrow)
        if (Input.GetKey(KeyCode.A))
        {
            //Moves the player to the left
            //transform.position += Vector3.left * speed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + (Vector3.left * speed * Time.deltaTime));
            transform.rotation = Quaternion.Euler(0, 180, 0);
            goingLeft = true;
        }

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnGround())
        {
            rigidbody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }

    private bool OnGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.2f))
        {
            return true;
        }
        return false;
    }

    public void UpdateCoinUI()
    {
        coinText.text = "Coins: " + coins;
    }

    public void UpdateLivesUI()
    {
        livesText.text = "health: " + health;
    }

    public void LoseHealth() //lose health from regular enemy
    {
        if (!isInvincible) // Only lose HP if not invincible
        {
            health -= 15; // Deduct 15 HP
            UpdateLivesUI();

            if (health > 0)
            {
                StartCoroutine(InvincibilityCoroutine()); // Start blinking and invincibility
            }
            else
            {
                SceneManager.LoadScene("Game Over");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hazard"))
        {
            LoseHealth();
        }
        if (other.tag == "Laser")
        {
            StartCoroutine(Stun());
        }
    }
   

    IEnumerator Stun()
    {
        int currentPlayerSpeed = (int)speed;
        speed = 0;
        yield return new WaitForSeconds(stunTimer);
        speed = currentPlayerSpeed;
    }
    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;

        // Blinking effect for 5 seconds
        for (float i = 0; i < 5; i += 0.2f)
        {
            playerRenderer.enabled = !playerRenderer.enabled; // Toggle visibility
            yield return new WaitForSeconds(0.2f);
        }

        playerRenderer.enabled = true; // Ensure player is visible after blinking
        isInvincible = false;
    }
}
