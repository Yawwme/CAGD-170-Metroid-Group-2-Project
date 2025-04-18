using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

/*
 * Author:
 * 
 * 
 */

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float jumpforce = 10;
    public float killHeight = -5;
    public float stunTimer = 0;
    
    public float timeBetweenShots;
    public float startDelay;
    public float bulletDelay;
    
    public int coins = 0;
    public int currentHealth; //the current health of the character
    public int health; // Starting HP
    public int maxHealth = 99; // Max HP
    
    private Vector3 respawnPoint;
    private Rigidbody rb;

    public bool goingLeft = false;
    public TMP_Text livesText;
    public TMP_Text coinText;

    private bool isInvincible = false; // Tracks invincibility state
    private bool isShooting = false;

    private Renderer playerRenderer; // Player renderer for blinking effect
    
    public GameObject projectilePrefab; //normal
    public GameObject heavyBulletPrefab; //heavy
    public bool isNormalBullet = true;
    public bool isHeavyBullet = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        respawnPoint = transform.position;
        playerRenderer = GetComponent<Renderer>(); // Get the renderer for the blinking effect

       
        print(currentHealth);
        health = currentHealth; //techincally should set health to the currentHealth

        UpdateCoinUI();
        UpdateLivesUI();
    }

    private void Update()
    {
        Jump();
        Shoot();
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
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }

    /// <summary>
    /// Allows Samus to shoot bullets when space is pressed
    /// </summary> 
    private void Shoot()
    {
        //Work on how many bullets you can fire and holding the fire button
        if (Input.GetKey(KeyCode.Space) && Time.time >= bulletDelay)
        {
            bulletDelay = Time.time + 0.5f;

            if (isNormalBullet == true)
            {
                SpawnProjectile();
            }

            else if (isHeavyBullet == true)
            {
                SpawnHeavy();
            }
        }
            

        //If the bullets collide with anything then it gets destroyed

    }

    /// <summary>
    /// used to be SpawnProjectile
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

    public void SpawnHeavy()
    {
        GameObject heavyBullet = Instantiate(heavyBulletPrefab, transform.position, heavyBulletPrefab.transform.rotation);
        if (heavyBullet.GetComponent<HeavyBullet>())
        {
            heavyBullet.GetComponent<HeavyBullet>().goingLeft = goingLeft;
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

    public void HardLoseHealth() //lose health from regular enemy
    {
        if (!isInvincible) // Only lose HP if not invincible
        {
            health -= 35; // Deduct 15 HP
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
        if (other.CompareTag("HeavyHazard"))
        {
            HardLoseHealth();
        }
    }
   

 
    private IEnumerator InvincibilityCoroutine()
    {
        isInvincible = true;

        // Blinking effect for 5 seconds
        for (float i = 0; i < 5; i += 0.2f)
        {
            ToggleVisibility(playerRenderer.gameObject, !playerRenderer.enabled); // Toggle visibility of player and children
            yield return new WaitForSeconds(0.2f);
        }

        ToggleVisibility(playerRenderer.gameObject, true); // Ensure player and children are visible after blinking
        isInvincible = false;
    }

    private IEnumerator BulletDelay()
    {
        if (isShooting == true && isNormalBullet == true)
        {
            yield return new WaitForSeconds(0.5f);
            InvokeRepeating("SpawnProjectile", startDelay, timeBetweenShots); //this somehow keeps it from breaking
            yield return new WaitForSeconds(0.5f);
        }
        else if (isShooting == true && isHeavyBullet == true)
        {
            yield return new WaitForSeconds(0.5f);
            InvokeRepeating("SpawnHeavy", startDelay, timeBetweenShots); //this somehow keeps it from breaking
            yield return new WaitForSeconds(0.5f);
        }
    }

    // Function to toggle visibility of a GameObject and all its children
    private void ToggleVisibility(GameObject obj, bool visibility)
    {
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            renderer.enabled = visibility;
        }
    }
}
