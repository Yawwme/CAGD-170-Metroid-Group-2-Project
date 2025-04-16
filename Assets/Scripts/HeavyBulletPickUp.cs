using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
