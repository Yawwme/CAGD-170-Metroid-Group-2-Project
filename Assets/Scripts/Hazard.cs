using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 *Name: Jann Morales
 * Date: 3 / 27 / 2025
 * Last Updated: 4 / 1 / 2025
 * Description: Detects if the player collided with a hazard AND deals damage to the player
 */

public class Hazard : MonoBehaviour
{

    //Checks for physical collisions with the player
    private void OnCollisionEnter(Collision collision)
    {
        //Checks if the player collided with a hazard
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            collision.gameObject.GetComponent<PlayerController>().LoseLife();
            print("you lost a life haha");
        }
        
    }

    //Checks for overlaps with the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            other.gameObject.GetComponent<PlayerController>().LoseLife();
            print("you lost a life again jaja");
        }
    }

}
