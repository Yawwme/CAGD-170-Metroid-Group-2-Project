using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            player.maxHealth = 199;
            player.health = 199; //should restore to max
            print(player.health);
            player.UpdateLivesUI();
            Destroy(gameObject);
        }
    }
}
