using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


/*
 *Ricky Pardo
 * 4 / 15 / 2025
 * script that kills the player when colliding with a harder hazard or kills the harder hazard when colliding with the player lazar enough type
 * 
 */
public class HardHazard : MonoBehaviour
{
    public int health = 10; // Set initial health

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player collided with this hazard
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            collision.gameObject.GetComponent<PlayerController>().HardLoseHealth();
        }
    }

    // Checks for overlaps with the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            other.gameObject.GetComponent<PlayerController>().HardLoseHealth();
        }
        else if (other.gameObject.CompareTag("Laser"))
        {
                Debug.Log("Laser hit the hazard!"); // Debugging
            TakeDamage(1);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Heavy"))
        {
            Debug.Log("HEAVY hit the hazard!"); // Debugging
            TakeDamage(3);
            Destroy(other.gameObject);
        }
    }

    private void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Destroy(gameObject); // Destroy hazard when health reaches zero
        }
    }
}