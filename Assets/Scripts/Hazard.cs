using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 *Ricky Pardo
 * 3 / 27 / 2025
 * script that kills the player when colliding with a hazard object
 * 
 */
public class Hazard : MonoBehaviour
{

    //checks for physical collisions with the player
    private void OnCollisionEnter(Collision collision)
    {
        //check if the player collided with this hazard
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            collision.gameObject.GetComponent<PlayerController>().LoseHealth();
        }
    }

    //checks for overlaps with the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            other.gameObject.GetComponent<PlayerController>().LoseHealth();
        }
    }

}
