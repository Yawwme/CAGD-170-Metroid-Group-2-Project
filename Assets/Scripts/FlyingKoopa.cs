using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *Ricky Pardo
 * 4 / 1 / 2025
 * koopa movement system 
 * 
 */
public class FlyingKoopa : MonoBehaviour
{
    

    public float moveDistance = 5f; // Distance to move up and down
    public float moveSpeed = 2f;   // Movement speed
    private Vector3 startPos;
    private bool movingUp = true;

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        MoveUpDown();
    }

    private void MoveUpDown()
    {
        if (movingUp)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            if (transform.position.y >= startPos.y + moveDistance)
            {
                movingUp = false;
            }
        }
        else
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            if (transform.position.y <= startPos.y - moveDistance)
            {
                movingUp = true;
            }
        }
    }

}