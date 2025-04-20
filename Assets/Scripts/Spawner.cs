using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: Ricky Pardo
 * Date Created: 4/20/2025
 * Description: While cleaning up old unused scripts, I accidentally deleted the script that even let the player fired. I restored it, but that was nearly a grade A mess up - Jann Morales
 * Spawns laser, pew pew. 
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
