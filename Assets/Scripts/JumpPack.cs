using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            player.jumpforce += jumpPower; //might be wrong idk!!!!
            print(player.jumpforce);
            Destroy(gameObject);
        }
    }
}
