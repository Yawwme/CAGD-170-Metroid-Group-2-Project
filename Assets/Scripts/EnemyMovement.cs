using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Ricky Pardo
 * 3/27/2025
 * handles moving a grounded enemy left and right
 * 
 */
public class EnemyMovement : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 10;
    public Transform leftpoint;
    public Transform rightpoint;

    private Vector3 leftStart;
    private Vector3 rightStart;





    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.right;

        //store the starting position values of the left and right points
        leftStart = leftpoint.position;
        rightStart = rightpoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        //move
        transform.position += direction * speed * Time.deltaTime;

        //check if enmy moved more than the right point on the x axis 
        if(transform.position.x >= rightStart.x)
        {
            direction = Vector3.left;
        }

        //check if enmy moved less than the left point on the x axis 
        if (transform.position.x <= leftStart.x)
        {
            direction = Vector3.right;
        }
    }





}
