using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (other.GetComponent<PlayerController>())
        {    
            player.health +=  healthRestore; //might be wrong idk!!!!
            print(player.health);
            Destroy(gameObject);
        }
    }
}
