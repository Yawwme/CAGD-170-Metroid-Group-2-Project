using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public bool goingLeft;

    // Update is called once per frame
    void Update()
    {
        if (goingLeft == true)
        {
            transform.position += speed * Vector3.left * Time.deltaTime;
            StartCoroutine(RegularBullet());
        }
        else
        {
            transform.position += speed * Vector3.right * Time.deltaTime;
            StartCoroutine(RegularBullet());
        }

    }

    IEnumerator RegularBullet()
    {
        //Start the timer to wait
        print("Bullet shot");
        yield return new WaitForSeconds(1f);
        print("Bullet died");

        //Destroy Bullet
        Destroy(gameObject);

    }

    private void OnTriggerEnter(Collider other)
    {
        //Placeholder code that destroys any enemy the bullets collides with.
        if (other.gameObject.GetComponent<EnemyMovement>())
        {
            Destroy(other.gameObject);
        }
        
    }

}
