using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *Ricky Pardo
 * 4 / 1 / 2025
 * projectile based enemy spawner that spawns Bill 
 * 
 */

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletBillPrefab; 
    public float spawnInterval = 3f;

    void Start()
    {
        // Repeatedly spawn Bullet Bills
        InvokeRepeating("SpawnBulletBill", 0f, spawnInterval);
    }

    void SpawnBulletBill()
    {
        Instantiate(bulletBillPrefab, transform.position, Quaternion.identity);
    }

}
