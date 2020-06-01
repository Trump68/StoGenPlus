using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Character attributes")]
    public float BASIC_SPEED = 1.5f;

    [Space]
    [Header("References")]
    public Animator animator;

    Vector3 pos;
    Vector2 MoveDirection = Vector2.down;
    Vector2 CollidedDirection = Vector2.zero;
    int pause = 0;
    int pauseLength = 30;



    void Start()
    {
        pos = transform.position;          // Take the initial position
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollidedDirection = MoveDirection;
    }

    void Update()
    {
        BasicMovement();
    }

    private void BasicMovement()
    {
        Vector3 delta = new Vector3(0, 0, 0);

        if (CollidedDirection == Vector2.down)
        {
            delta = Vector3.up / 2;
            CollidedDirection = Vector2.zero;
        }
        else if (CollidedDirection == Vector2.up)
        {
            delta = Vector3.down / 2;
            CollidedDirection = Vector2.zero;
        }
        else if (CollidedDirection == Vector2.right)
        {
            delta = Vector3.left / 2;
            CollidedDirection = Vector2.zero;
        }
        else if (CollidedDirection == Vector2.left)
        {
            delta = Vector3.right / 2;
            CollidedDirection = Vector2.zero;
        }
        else
        {
            if (pause <= pauseLength) pause++;
            if (transform.position == pos && pause > pauseLength)
            {
                if (Input.GetKey(KeyCode.D) || (Input.GetAxis("Horizontal") > 0))
                {
                    if (MoveDirection == Vector2.right && CollidedDirection != MoveDirection)
                    {
                        delta += Vector3.right / 2;
                        CollidedDirection = Vector2.zero;
                    }
                    else
                    {
                        MoveDirection = Vector2.right;
                        pause = 0;
                    }
                }
                else if (Input.GetKey(KeyCode.A) || (Input.GetAxis("Horizontal") < 0))
                {
                    if (MoveDirection == Vector2.left && CollidedDirection != MoveDirection)
                    {
                        delta += Vector3.left / 2;
                        CollidedDirection = Vector2.zero;
                    }
                    else
                    {
                        MoveDirection = Vector2.left;
                        pause = 0;
                    }
                }
                else if (Input.GetKey(KeyCode.W) || (Input.GetAxis("Vertical") > 0))
                {
                    if (MoveDirection == Vector2.up && CollidedDirection != MoveDirection)
                    {
                        delta += Vector3.up / 2;
                        CollidedDirection = Vector2.zero;
                    }
                    else
                    {
                        MoveDirection = Vector2.up;
                        pause = 0;
                    }
                }
                else if (Input.GetKey(KeyCode.S) || (Input.GetAxis("Vertical") < 0))
                {
                    if (MoveDirection == Vector2.down && CollidedDirection != MoveDirection)
                    {
                        delta += Vector3.down / 2;
                        CollidedDirection = Vector2.zero;
                    }
                    else
                    {
                        MoveDirection = Vector2.down;
                        pause = 0;
                    }
                }
                if (MoveDirection == Vector2.down)
                    animator.SetInteger("FaceDirection", 0);
                else if (MoveDirection == Vector2.up)
                    animator.SetInteger("FaceDirection", 3);
                else if (MoveDirection == Vector2.right)
                    animator.SetInteger("FaceDirection", 1);
                else if (MoveDirection == Vector2.left)
                    animator.SetInteger("FaceDirection", 2);
                animator.SetFloat("Horizontal", delta.x);
                animator.SetFloat("Vertical", delta.y);
                animator.SetFloat("Magnitude", delta.magnitude);
            }
        }
        pos += delta;
        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * BASIC_SPEED);
    }


}
