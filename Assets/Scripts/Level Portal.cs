using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 *Ricky Pardo
 * 4 / 15 / 2025
 * Portal that sends you a different level
 * 
 */

public class LevelPortal : MonoBehaviour
{
    public int buildIndex;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (other.GetComponent<PlayerController>())
        {
            print(player.health + "a");
            player.currentHealth = player.health;
            print(player.health);
            player.UpdateLivesUI(); 
        }
            SceneManager.LoadScene(buildIndex);
    }
}
