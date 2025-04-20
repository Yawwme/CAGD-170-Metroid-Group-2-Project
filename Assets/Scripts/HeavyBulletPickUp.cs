using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*Author(s): Jann Morales
 * Date Created: 4 / 10 / 2025
 * Description: This is for the HeavyBullet powerup. Once collected, allows the player to only fire heavy bullets. Replaces normal bullets (which are just lasers).
 */

public class HeavyBulletPickUp : MonoBehaviour
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
           other.GetComponent<PlayerController>().isNormalBullet = false;
           other.GetComponent<PlayerController>().isHeavyBullet = true;
            print("have fun");
        }
    }
}
