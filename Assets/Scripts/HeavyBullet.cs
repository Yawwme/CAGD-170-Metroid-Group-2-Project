using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//literally just copied and paste the laser script lol

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
