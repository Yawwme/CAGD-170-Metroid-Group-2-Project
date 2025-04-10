using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SamusController : MonoBehaviour
{
    public bool goingLeft;

    public float speed = 10;
    public float jumpForce = 10; //Not the game
    public float maxFallDistance = -5f;
    public float stunTimer = 2;
    public float timeBetweenShots;
    public float startDelay;

    public int coin;
    public int health = 99;
    
    public GameObject projectilePrefab;

    private bool isInvincible = false; // Tracks invincibility state

    private Renderer playerRenderer; // Player renderer for blinking effect


    private Vector3 respawnPoint;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Set the respawnPoint variable = to the player's starting position
        respawnPoint = transform.position;
        playerRenderer = GetComponent<Renderer>(); // Get the renderer for the blinking effect

    }

    private void Update()
    {
        Jump();

        Shoot();

        //Checks if the player sadly fell into the void to respawn them
        if (transform.position.y <= maxFallDistance)
        {
            LoseHealth();
        }
    }

    // FixedUpdated is called every 0.02 seconds
    void FixedUpdate()
    {
        Move();
        
    }

    /// <summary>
    /// Check for player's left/right input and move left/right
    /// </summary>
    private void Move()
    {
        //Checks for the right input (D/RightArrow)
        if (Input.GetKey(KeyCode.D))
        {
            //Moves the player to the right
            //transform.position += Vector3.right * speed * Time.deltaTime; 
            rb.MovePosition(transform.position + (Vector3.right * speed * Time.deltaTime));
            transform.rotation = Quaternion.Euler(0, 360, 0);
            goingLeft = false;
        }

        //Checks for the left input (A/LeftArrow)
        if (Input.GetKey(KeyCode.A))
        {
            //Moves the player to the left
            //transform.position += Vector3.left * speed * Time.deltaTime;
            rb.MovePosition(transform.position + (Vector3.left * speed * Time.deltaTime));
            transform.rotation = Quaternion.Euler(0, 180, 0);
            goingLeft = true;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && OnGround())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    /// <summary>
    /// Allows Samus to shoot bullets when space is pressed
    /// </summary> 
    private void Shoot()
    {
        //Work on how many bullets you can fire and holding the fire button
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            InvokeRepeating("SpawnProjectile", startDelay, timeBetweenShots);

            
        }

        //If the bullets collide with anything then it gets destroyed

    }

    /// <summary>
    /// jaja
    /// </summary>
    public void SpawnProjectile()
    {
        //Remember to change the GetComponent into the bullet script (once bullets get added)
        GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        if (projectile.GetComponent<Laser>())
        {
            projectile.GetComponent<Laser>().goingLeft = goingLeft;
        }
    }


    /// <summary>
    /// OnGround checks with a raycast if the player is on the ground
    /// and returns true if the raycast hits something
    /// </summary>
    /// <returns></returns>
    private bool OnGround()
    {
        bool onGround = false;

        RaycastHit hit;

        //Draws a ray downward 1.2 units from the player's center
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.2f))
        {
            onGround = true;
        }

        return onGround;
    }

    /// <summary>
    /// Reduces the player's lives by 1. Respawns if lives are remaining
    /// EDIT SCRIPT
    /// </summary>
    public void LoseHealth()
    {
        if (!isInvincible) // Only lose HP if not invincible
        {
            health -= 15; // Deduct 15 HP

            switch (health)
            {
                case > 0:
                    StartCoroutine(InvincibilityCoroutine()); // Start blinking and invincibility
                    break;
                default:
                    //Change scene into game over, you lazy bum!
                    SceneManager.LoadScene(2);
                    print("wah you're dead");
                    break;
            }
        }
        

    }

    /// <summary>
    /// Stuns the player if they touch the laser.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Laser>())
        {
            StartCoroutine(Stun());
        }
    }

    /// <summary>
    /// Gets the player's current speed, reduces it, waits, and then brings it back.
    /// </summary>
    /// <returns></returns>
    IEnumerator Stun()
    {
        float currentPlayerSpeed = speed;
        speed = 0;
        yield return new WaitForSeconds(stunTimer);
        speed = currentPlayerSpeed;

    }
    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;

        //Blinking effect for 5 seconds
        for (float i = 0; i < 5; i += 0.2f)
            {
                playerRenderer.enabled = !playerRenderer.enabled; // Toggle visibility
                yield return new WaitForSeconds(0.2f);
            }

        playerRenderer.enabled = true; // Ensure player is visible after blinking
        isInvincible = false;
    }
}
