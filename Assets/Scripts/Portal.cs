using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *Name: Jann Morales
 * Date: 3 / 27 / 2025
 * Last Updated: 3 / 27 / 2025
 * Description: Teleports objects to a new point in the level
 */

public class Portal : MonoBehaviour
{
    public Transform teleportPoint;

    private void OnTriggerEnter(Collider other)
    {
        //Sets the position of the touched object to the teleportPoint
        other.transform.position = teleportPoint.position;
      
    }

}
