using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
 * Author(s): Jann Morales
 * Date Created: 4 / 15 / 25
 * Description: This is for the Extra Health Pickup power up. Increases the player's maxHealth by 100 and fully heals them
 */


public class ExtraHealthPickUp : MonoBehaviour
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

        if (other.GetComponent<PlayerController>())
        {
            if (player.maxHealth == 99)
            {
                player.maxHealth = 199;
                player.health = 199;
                player.UpdateLivesUI();
            }

            Destroy(gameObject);
        }
    }
}
