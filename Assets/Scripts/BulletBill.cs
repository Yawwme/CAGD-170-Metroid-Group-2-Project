using UnityEngine;
/*
 *Ricky Pardo
 * 4 / 1 / 2025
 * projectile based enemy bullet 
 * 
 */

public class BulletBill : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Move the Bullet Bill to the left
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }


    void Start()
    {
        // Destroy bill after x seconds
        Destroy(gameObject, 5f);
    }
}