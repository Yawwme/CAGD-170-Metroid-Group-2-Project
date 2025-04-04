using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Name: Jann Morales
 * Date: 3/25/2025
 * Last Updated: 4/2/2025
 * Description: Handles player's movement, jumping, and losing lives/respawning
 */


public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float jumpForce = 10; //Not the game
    public int coin;
    public int lives = 3;
    public float maxFallDistance = -5f;
    public float stunTimer = 2;
    
    private Vector3 respawnPoint;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        //Set the respawnPoint variable = to the player's starting position
        respawnPoint = transform.position;
    }

    private void Update()
    {
        Jump();

        //Checks if the player sadly fell into the void to respawn them
        if (transform.position.y <= maxFallDistance)
        {
            LoseLife();
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
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //Moves the player to the right
            //transform.position += Vector3.right * speed * Time.deltaTime; 
            rigidbody.MovePosition(transform.position + (Vector3.right * speed * Time.deltaTime));
        }

        //Checks for the left input (A/LeftArrow)
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //Moves the player to the left
            //transform.position += Vector3.left * speed * Time.deltaTime;
            rigidbody.MovePosition(transform.position + (Vector3.left * speed * Time.deltaTime));
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && OnGround())
        {
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
    /// Reduces the player's lives by 1. Respawns if lives are reamining
    /// </summary>
    public void LoseLife()
    {
        //Reduces the player's lives (by one)
        lives--;

        //Check if lives > 0
        if (lives > 0)
        {
            //Respawns the player by setting their current position to the position of the respawn point
            transform.position = respawnPoint;
        }
        else //Else game over D:
        {
            //Change scene into game over, you lazy bum!
            SceneManager.LoadScene(2);
            print("wah you're dead");
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

}
