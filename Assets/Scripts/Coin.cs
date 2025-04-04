using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

/*
 *Name: Jann Morales
 * Date: 3 / 25 / 2025
 * Last Updated: 3 / 25 / 2025
 * Description: Handles coin collection and rotation (woo)
 */

public class Coin : MonoBehaviour
{
    public float rotationSpeed = 1;

    // Update is called once per frame
    void Update()
    {
        //Rotate the coin each frame
        transform.Rotate(0, rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if the touched object has the PlayerController script
        //This is the player
        if (other.GetComponent<PlayerController>())
        {
            //Add coin to the player
            other.GetComponent<PlayerController>().coin++; //or += 1

            //Remove the collected coin
            gameObject.SetActive(false); //or Destroy(gameObject);
        }
    }

}
