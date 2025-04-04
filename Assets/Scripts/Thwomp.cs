using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
 *Name: Jann Morales
 * Date: 4 / 1 / 2025
 * Last Updated: 4 / 1 / 2025
 * Description: Handles Thwomp enemy behavior
 */

public class Thwomp : MonoBehaviour
{
    public float speedUp = 5;
    public float speedDown = 10;

    public bool isMovingDown = false;
    public bool isMovingUp = false;

    public Vector3 movePoint;
    public Vector3 startingPoint;


    // Start is called before the first frame update
    void Start()
    {
        //Gets the point in space above the ground for the thwomp to move to
        movePoint = GetPointToMoveTo();
        
        //Gets where the thwomp is at the start
        startingPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 leftEdge = transform.position + new Vector3(-1.5f, 0, 0);
        Vector3 rightEdge = transform.position + new Vector3(1.5f, 0, 0);

        //Visualize the raycast, I love this
        Debug.DrawLine(leftEdge, Vector3.down * 10, Color.red);
        Debug.DrawLine(rightEdge, Vector3.down * 10, Color.red);

        //Casts a raycast down from the leftEdge of the thwomp to check for player
        if (Physics.Raycast(leftEdge, Vector3.down, out hit, Mathf.Infinity) && !isMovingDown && !isMovingUp) //Draws an infinte distance
        {
            if (hit.transform.GetComponent<PlayerController>()) //Raycast hit player
            {
                print("Left raycast hit player youch");
                isMovingDown = true;

            }
        }

        //Casts a raycast down from the rightEdge of the thwomp to check for player
        if (Physics.Raycast(rightEdge, Vector3.down, out hit, Mathf.Infinity) && !isMovingDown && !isMovingUp) //Draws an infinte distance
        {
            if (hit.transform.GetComponent<PlayerController>()) //Raycast hit player
            {
                print("Right raycast hit player youch");
                isMovingDown = true;
            }
        }

        //If the bool isMovingDown is true, move the thwomp downward
        if (isMovingDown)
        {
            MoveDown();
        }

        //If the bool isMovingUp is true, move the thwomp upwards
        if (isMovingUp)
        {
            MoveUp();
        }

    }

    /// <summary>
    /// If moving down, moves downwards until the thwomp reaches the ground 
    /// </summary>
    private void MoveDown()
    {
        transform.position += Vector3.down * speedDown * Time.deltaTime;

        //Check if the thwomp moved less than or equal to the movePoint
        if (transform.position.y <= movePoint.y)
        {
            //STOP moving
            isMovingDown = false;
        
            //Start moving up
            StartCoroutine(WaitToGoUp());
        }
    }

    /// <summary>
    /// If moving up, moves ypwards until the thwomp reaches the starting point 
    /// </summary>
    private void MoveUp()
    {
        transform.position += Vector3.up * speedUp * Time.deltaTime;

        //Check if the thwomp moved less than or equal to the movePoint
        if (transform.position.y >= startingPoint.y)
        {
            //STOP moving
            isMovingUp = false;
        }
    }

    /// <summary>
    /// Returns the point in space above the ground to move to
    /// Calculates by casting the raycast downwards and adjusts the hit point
    /// </summary>
    /// <returns></returns>
    private Vector3 GetPointToMoveTo()
    {
        Vector3 movePoint;

        RaycastHit hit;

        Debug.DrawLine(transform.position, Vector3.down * 10, Color.yellow);

        //Casts a raycast down from the leftEdge of the thwomp to check for ground
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity)) //Draws an infinte distance
        {
            movePoint = hit.point + new Vector3(0, 2, 0);
        }
        else //Checks if there is no ground is below the thwomp
        {
            movePoint = transform.position - new Vector3(0, 20, 0);
        }

        return movePoint;
    }

    
    //This is a Coroutine - it's a timer
    //Code execution within this function is frozen while is is waiting
    IEnumerator WaitToGoUp()
    {
        //Start the timer to wait
        print("Timer started");
        yield return new WaitForSeconds(3);
        print("Timer ended");

        //Execute other code after the timer is completed

        //Start moving up
        isMovingUp = true;
    }

}
