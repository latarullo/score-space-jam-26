using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private float jumpSize = 5;
    [SerializeField] private float moveSpeed = 3;
    [SerializeField] private float turnSpeed = 10;

    private GameInput gameInput;
    
    private Rigidbody playerRigidbody;
    private Animator animator;

    private Vector3 moveInput;
    private bool jump;


    private void Awake() {
        
    }

    private void GameInput_OnJumpPressed(object sender, System.EventArgs e) {
        Jump();
    }

    void Start() {
        playerRigidbody = this.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        gameInput = GameInput.Instance;
        gameInput.OnJumpPressed += GameInput_OnJumpPressed;
    }

    private void Update() {
        Vector2 movementVector = gameInput.GetMovementVectorNormalized();
        moveInput = new Vector3(movementVector.x, 0, movementVector.y);

        animator.SetFloat("speed", moveInput.magnitude);

        if (moveInput != Vector3.zero) {
            transform.position += moveInput * Time.deltaTime * moveSpeed;
            transform.forward = Vector3.Slerp(transform.forward, moveInput, Time.deltaTime * turnSpeed);
        }

    }

    private void ReadInput() {
    }

    void FixedUpdate() {
        //Move();
        //Rotate();
    }

    private void Move() {
        playerRigidbody.AddForce(moveInput * moveSpeed);
    }

    private void Rotate() {
        Vector3 h = (this.transform.position + moveInput) - this.transform.position;
        float angle = Mathf.Atan2(h.x, h.z) * Mathf.Rad2Deg;

        transform.forward = h;
        playerRigidbody.MoveRotation(Quaternion.Slerp(playerRigidbody.rotation, Quaternion.Euler(0, angle, 0), Time.fixedDeltaTime));
    }

    void Jump() {
        if (!jump) {
            playerRigidbody.AddForce(Vector3.up * jumpSize, ForceMode.Impulse);
            jump = true;
            animator.SetBool("jump", true);
        }
    }

    private void OnCollisionStay(Collision collision) {
        animator?.SetBool("jump", false);
        jump = false;
    }
}
