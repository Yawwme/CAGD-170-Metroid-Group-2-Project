using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author(s): Jann Morales
 * Date Created: 4 / 10 / 2025
 * Description: This is for the JumpPack power up. Makes the player jump higher.
 */

public class JumpPack : MonoBehaviour
{
    public float rotSpeed = 1;
    public int jumpPower;

    void Update()
    {
        transform.Rotate(0, rotSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (other.GetComponent<PlayerController>())
        {
            player.jumpforce += jumpPower;
            print(player.jumpforce);
            Destroy(gameObject);
        }
    }
}
