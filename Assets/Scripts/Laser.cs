using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author(s): Ricky Pardo
 * Date Created: 4 / 1 / 2025
 * Description: Projectile based laser. Yes, the laser got reused for the project. 
 */
 
public class Laser : MonoBehaviour
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
