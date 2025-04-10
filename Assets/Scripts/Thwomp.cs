using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/*
 *Ricky Pardo
 * 4 / 1 / 2025
 * handles thwomp behaivor
 * 
 */
public class Thwomp : MonoBehaviour
{
    public float SpeedUp = 5;
    public float Speeddown = 10;
    public bool movingDown = false;
    public bool movingUp = false;

    public Vector3 movepoint;
    public Vector3 startingpoint;

    // Start is called before the first frame update
    void Start()
    {
        //gets the point in space above the ground for thr thwomp to move to
        movepoint = GetPointToMoveTo();

        //gets where the thwomp is at the start
        startingpoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 leftedge = transform.position + new Vector3(-1.5f, 0, 0);
        Vector3 rightedge = transform.position + new Vector3(1.5f, 0, 0);

        //raycast down from left edge of thwomp to check for player
        if(Physics.Raycast(leftedge, Vector3.down, out hit, Mathf.Infinity) && !movingDown && !movingUp)
        {
            if(hit.transform.GetComponent<PlayerController>())
            {
                print("raycast hit something");
                movingDown = true;
            }
        }
        //raycast down from right edge of thwomp to check for player
        if (Physics.Raycast(rightedge, Vector3.down, out hit, Mathf.Infinity) && !movingDown && !movingUp)
        {
            if (hit.transform.GetComponent<PlayerController>())
            {
                print("raycast hit something");
                movingDown = true;

            }
        }

        if(movingDown)
        {
            MoveDown();
        }

        if (movingUp)
        {
            MoveUp();
        }
    }
    /// <summary>
    /// if moving down, moves downward until the thwomp reaches the ground
    /// calculate this by raycasting downward, and adjusting the hit point 
    /// </summary>
    private void MoveDown()
    {
        transform.position += Vector3.down * Speeddown * Time.deltaTime;

        //check if moced lower than the move point
        if(transform.position.y <= movepoint.y)
        {
            //stop moving
            movingDown = false;

            //wait before moving up
            StartCoroutine(WaitToGoUp());

            
        }
    }
    /// <summary>
    /// returns the point in space above the ground to move to
    /// </summary>
    /// <returns></returns>
    private Vector3 GetPointToMoveTo()
    {
        Vector3 movepoint;

        RaycastHit hit;

       

        //raycast down from the center of thwomp to check for the ground
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            movepoint = hit.point + new Vector3(0, 1.5f, 0);
        }
        else //if no ground is below the thwomp
        {
            movepoint = transform.position - new Vector3(0, 20, 0);
        }

            return movepoint;
    }

    private void MoveUp()
    {
        transform.position += Vector3.up * SpeedUp * Time.deltaTime;

        //check if moced lower than the move point
        if (transform.position.y >= startingpoint.y)
        {
            //stop moving
            movingUp = false;
        }
    }
    //this is a Coroutine - it is a timer
    //code execution within this is frozen while it is waiting 
    private IEnumerator WaitToGoUp()
    {
        //start the timer to wait 
        print("timer start");
        yield return new WaitForSeconds(3);
        print("timer end");
        //execute other code after the timer is completed

        //execute other code after the timer is completed 
        movingUp = true;
    }

}

