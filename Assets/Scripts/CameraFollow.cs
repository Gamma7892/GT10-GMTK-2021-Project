using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followedPlayer;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public CharacterController2D character;

    private Rigidbody2D rigidBody;
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = followedPlayer.GetComponent<Rigidbody2D>().velocity + (Vector2) (followedPlayer.position - transform.position);
        Vector3 smoothedPosition = Vector3.Lerp(rigidBody.velocity, desiredPosition, smoothSpeed);
        rigidBody.velocity = smoothedPosition;
        
        //transform.position = smoothedPosition;
    }
}
