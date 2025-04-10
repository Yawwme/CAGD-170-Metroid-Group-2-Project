using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *Ricky Pardo
 * 4 / 1 / 2025
 * allows you to kill koopa via koopa kill box parented to koopa
 * 
 */
public class KillKoopa : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {

        // Check if the object overlapping is the player
        if (other.GetComponent<PlayerController>())
            {
                // Destroy the enemy 
                Destroy(transform.parent.gameObject);
            }
    }
    

}
