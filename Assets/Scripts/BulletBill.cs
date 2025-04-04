using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *Name: Jann Morales
 * Date: 4 / 2 / 2025
 * Last Updated: 4 / 2 / 2025
 * Description: Handles Bullet Bill enemy behavior
 */

public class BulletBill : MonoBehaviour
{
    public float speed;
    public bool goingLeft;

    // Update is called once per frame
    void Update()
    {
        if (goingLeft == true)
        {
            transform.position += speed * Vector3.left * Time.deltaTime;
            StartCoroutine(BulletLifeSpan());
        }
        else
        {
            transform.position += speed * Vector3.right * Time.deltaTime;
            StartCoroutine(BulletLifeSpan());
        }

    }

    IEnumerator BulletLifeSpan()
    {
        //Start the timer to wait
        print("Bullet shot");
        yield return new WaitForSeconds(5f);
        print("Bullet died");

        //Destroy the Bullet Bill
        Destroy(gameObject);
    }
}
