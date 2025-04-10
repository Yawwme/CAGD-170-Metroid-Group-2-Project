using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardHazard : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //check if the player collided with this hazard
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            collision.gameObject.GetComponent<PlayerController>().HardLoseHealth();
        }
    }

    //checks for overlaps with the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            other.gameObject.GetComponent<PlayerController>().HardLoseHealth();
        }
    }
}
