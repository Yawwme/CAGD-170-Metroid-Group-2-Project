using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Ricky Pardo
 * 3/26/2025
 * coin rotation and pick up 
 * 
 */

public class Coin : MonoBehaviour
{
    public float rotSpeed = 1;

    void Update()
    {
        transform.Rotate(0, rotSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            PlayerController player = other.GetComponent<PlayerController>();
            player.coins++;
            player.UpdateCoinUI(); // Update the UI when a coin is collected
            Destroy(gameObject);
        }
    }
}