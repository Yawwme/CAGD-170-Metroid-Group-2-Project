using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Author(s): Jann Morales
 * Date Created: 4 / 10 / 2025
 * Description: This is for the HealthPack pick up. Restores Health up to the maxHealth
 */


public class HealthPack : MonoBehaviour
{
    public float rotSpeed = 1;
    public int healthRestore;

    void Update()
    {
        transform.Rotate(0, rotSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
    

        if (other.GetComponent<PlayerController>() && player.maxHealth == 99)
        {
            player.health = Mathf.Min(player.health + healthRestore, player.maxHealth); //Returns the minimum of the healthRestore in case the player's current HP is close to the max.
                                                                                        //That way you don't just overheal or don't heal. I love Unity Documentation
            player.UpdateLivesUI();
            Destroy(gameObject);
        }
        else if (other.GetComponent<PlayerController>() && player.maxHealth == 199)
        {
            player.health = Mathf.Min(player.health + healthRestore, player.maxHealth); 
            player.UpdateLivesUI();
            Destroy(gameObject);
        }

    }
}
