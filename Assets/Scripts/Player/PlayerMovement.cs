using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public bool canMove = true;
    [SerializeField] private float speed = 10;

    [Header("Animation & Graphics")]
    [SerializeField] private Transform graphics;
    [SerializeField] private float tilt = 15;
    [SerializeField] private float tiltSmoothing = 0.1f;

    private Vector2 inputDirection;
    private float targetRotation;

    Rigidbody2D playerBody;

    void Start() {
        playerBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (canMove)
        {
            playerBody.velocity = inputDirection * speed;
            targetRotation = -inputDirection.x * tilt;
            graphics.rotation = Quaternion.Lerp(graphics.rotation, Quaternion.Euler(0, 0, targetRotation), tiltSmoothing);
        }
    }

    void OnMovement(InputValue value) {
        inputDirection = value.Get<Vector2>();
    }

}
