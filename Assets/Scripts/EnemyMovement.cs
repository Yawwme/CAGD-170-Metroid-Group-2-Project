using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *Name: Jann Morales
 * Date: 3 / 27 / 2025
 * Last Updated: 3 / 27 / 2025
 * Description: Handles moving a GROUNDED enemy left and right
 */

public class EnemyMovement : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 6;
    public Transform leftPoint;
    public Transform rightPoint;

    private Vector3 leftStart;
    private Vector3 rightStart;


    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.right;

        //Stores the starting position value of the left/right points
        leftStart = leftPoint.position;
        rightStart = rightPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    /// <summary>
    /// Moves the enemy left or right until it reaches the left/right point
    /// Then it changes directions 
    /// </summary>
    
    private void EnemyMove()
    {
        //Moves the enemy
        transform.position += direction * speed * Time.deltaTime;

        //Checks if the enemy reaches the rightStart
        if (transform.position.x >= rightStart.x)
        {
            direction = Vector3.left;
        }
        //Checks if the enemy reaches the leftStart
        else if (transform.position.x <= leftStart.x)
        {
            direction = Vector3.right;
        }

    }
}
