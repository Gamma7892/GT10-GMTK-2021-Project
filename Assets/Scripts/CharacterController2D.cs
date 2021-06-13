using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 60f;

    [Header("Controls")]
    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;
    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;

    private Rigidbody2D rigidBody;
    private Vector3 moveDir;
    public Vector3 lastMoveDir;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0f, moveY = 0f;

        if (PauseHandling.isPaused) { return; }

        if (Input.GetKey(up))
        {
            moveY = +1f;
        }
        if (Input.GetKey(down))
        {
            moveY = -1f;
        }
        if (Input.GetKey(left))
        {
            moveX = -1f;
        }
        if (Input.GetKey(right))
        {
            moveX = +1f;
        }

        moveDir = new Vector3(moveX, moveY).normalized;
        Vector3 zeroVector = new Vector3(0, 0, 0);
        if (moveDir != zeroVector ) {
            lastMoveDir = moveDir;
        }
    }

    void FixedUpdate()
    {
        rigidBody.velocity = moveDir * moveSpeed;
    }
}
