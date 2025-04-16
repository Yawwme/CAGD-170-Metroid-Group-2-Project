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
    

        if (other.GetComponent<PlayerController>() && player.maxHealth <= 99)
        {    
            player.health +=  healthRestore; //might be wrong idk!!!!
            print(player.health);
            player.UpdateLivesUI();
            Destroy(gameObject);
        }
        else if (other.GetComponent<PlayerController>() && player.maxHealth >= 99)
        {
            player.health += 0;
            print("haha no heal");
            player.UpdateLivesUI();
            Destroy(gameObject);
        }
    }
}
