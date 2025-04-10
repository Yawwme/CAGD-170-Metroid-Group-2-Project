using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *Ricky Pardo
 * 4 / 1 / 2025
 * projectile based enemy that spawn laser
 * 
 */
public class Spawner : MonoBehaviour
{
    public bool goingLeft;
    public float timeBetweenShots;
    public float startDelay;

    public GameObject projectilePrefab;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnProjectile", startDelay, timeBetweenShots);
    }

    public void SpawnProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        if(projectile.GetComponent<Laser>())
        {
            projectile.GetComponent<Laser>().goingLeft = goingLeft;
        }
    }
}
