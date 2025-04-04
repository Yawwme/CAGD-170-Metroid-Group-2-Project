using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *Name: Jann Morales
 * Date: 4 / 2 / 2025
 * Last Updated: 4 / 2 / 2025
 * Description: Spawns projectiles (lasers and bullet bills)
 */

public class Spawner : MonoBehaviour
{
    public bool goingLeft;

    public GameObject projectilePrefab;

    public float timeBetweenShots;
    public float startDelay;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnProjectile", startDelay, timeBetweenShots);
    }

    public void SpawnProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        if (projectile.GetComponent<Laser>())
        {
            projectile.GetComponent<Laser>().goingLeft = goingLeft;
        }
    }
}
