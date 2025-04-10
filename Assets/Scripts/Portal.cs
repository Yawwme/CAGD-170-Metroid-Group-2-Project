using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *Ricky Pardo
 * 3 / 27 / 2025
 * teleports obejcts to a new point in the world
 * 
 */
public class Portal : MonoBehaviour
{
    public Transform teleportPoint;

    private void OnTriggerEnter(Collider other)
    {
        //set position of touched object to the teleport point
        other.transform.position = teleportPoint.position;
    }
}
