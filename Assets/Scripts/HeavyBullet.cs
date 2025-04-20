using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/*
*Author(s): Jann Morales and Ricky Pardo
 * Date Created: 4 / 10 / 2025
 * Description: This is the laser script but for the HeavyBullet. 
 */

public class HeavyBullet : MonoBehaviour
{
    public float speed;
    public bool goingLeft;

    // Update is called once per frame
    void Update()
    {
        if (goingLeft == true)
        {
            transform.position += speed * Vector3.left * Time.deltaTime;
        }
        else
        {
            transform.position += speed * Vector3.right * Time.deltaTime;

        }
    }
}
