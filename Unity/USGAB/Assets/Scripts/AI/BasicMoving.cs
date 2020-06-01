using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BasicMoving : MonoBehaviour
{
    [Header("Character attributes")]
    public float BASIC_SPEED = 1.5f;
    Vector3 pos;
    Vector2 MoveDirection = Vector2.down;
    //Vector2 CollidedDirection = Vector2.zero;
    int currentPathIndex;
    public Animator animator;
    private List<Vector3> pathVectorList;

    Vector2 move = new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;          // Take the initial position
        animator.SetInteger("Action", 1);
    }

    bool stop = false;
    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    if (collision.gameObject.tag == "Bed")
    //    {
    //        stop = true;

    //        animator.Play("Sex Missionare 01");
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        if (pathVectorList != null && pathVectorList.Any())
        {
            BasicMovement();
           
        }
    }


    private void BasicMovement()
    {

        if (transform.position == pathVectorList[currentPathIndex])
        {            
            currentPathIndex++;
            if (currentPathIndex >= pathVectorList.Count)
            {
                StopMoving();
            }
            else
            {
                SetMoveDirection();
            }
        }
        if (pathVectorList != null)
            transform.position = Vector3.MoveTowards(transform.position, pathVectorList[currentPathIndex], Time.deltaTime * BASIC_SPEED);
    }
    
    private void StopMoving()
    {
        pathVectorList = null;
        animator.SetInteger("Magnitude", 0);
    }
    public List<Vector3> SetTargetPosition(Vector3 targetPosition)
    {
        currentPathIndex = 0;
        pathVectorList = AbPath.FindPath(transform.position, targetPosition);

        if (pathVectorList != null && pathVectorList.Count > 1)
        {
            pathVectorList.RemoveAt(0);
        }

        pos = transform.position;
        SetMoveDirection();
        return pathVectorList;
    }
    public List<Vector3> SetTargetPosition(Vector2Int targetPosition)
    {
        currentPathIndex = 0;
        pathVectorList = AbPath.FindPath(transform.position, targetPosition);

        if (pathVectorList != null && pathVectorList.Count > 1)
        {
            pathVectorList.RemoveAt(0);
        }

        pos = transform.position;
        SetMoveDirection();
        return pathVectorList;
    }
    private void SetMoveDirection()
    {
        if (pathVectorList == null) return;
        Vector3 curr = transform.position;
        Vector3 rez = pathVectorList[currentPathIndex] - curr;
        if (Math.Abs(rez.x) > Math.Abs(rez.y))
        {
            if (rez.x > 0) move = Vector2.right;
            else if (rez.x < 0) move = Vector2.left;
            else move = Vector2.zero;
        }
        else
        {
            if (rez.y > 0) move = Vector2.up;
            else if(rez.y < 0) move = Vector2.down;
            else move = Vector2.zero;
        }


        if (move == Vector2.right)
        {
            MoveDirection = Vector2.right;
            animator.SetInteger("FaceDirection", 1);
            animator.SetInteger("Horizontal", 1);
            animator.SetInteger("Vertical", 0);
        }
        else if (move == Vector2.left)
        {
            MoveDirection = Vector2.left;
            animator.SetInteger("FaceDirection", 2);
            animator.SetInteger("Horizontal", -1);
            animator.SetInteger("Vertical", 0);
        }
        else if (move == Vector2.up)
        {
            MoveDirection = Vector2.up;
            animator.SetInteger("FaceDirection", 3);
            animator.SetInteger("Vertical", 1);
            animator.SetInteger("Horizontal", 0);
        }
        else if (move == Vector2.down)
        {
            MoveDirection = Vector2.down;
            animator.SetInteger("FaceDirection", 0);
            animator.SetInteger("Vertical", -1);
            animator.SetInteger("Horizontal", 0);
        }
        animator.SetInteger("Magnitude", 1);
    }
}
