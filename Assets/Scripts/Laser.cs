using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *Name: Jann Morales
 * Date: 4 / 2 / 2025
 * Last Updated: 4 / 2 / 2025
 * Description: Handles laser behavior
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
            StartCoroutine(LaserLifeSpan());
        }
        else
        {
            transform.position += speed * Vector3.right * Time.deltaTime;
            StartCoroutine(LaserLifeSpan());
        }
        
    }

    IEnumerator LaserLifeSpan()
    {
        //Start the timer to wait
        print("Laser shot");
        yield return new WaitForSeconds(1f);
        print("Laser died");

        //Destroy laser
        Destroy(gameObject);
    }

    //get rid of later, this goes to the bullet script
    private void OnTriggerEnter(Collider other)
    {
        //Placeholder code that destroys any enemy the bullets collides with.
        if (other.gameObject.GetComponent<EnemyMovement>())
        {
            Destroy(other.gameObject);
        }

    }
}
