using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float friction;
    public float jumpForce;
    public float jumpInterval;
    public float drag;
    bool readyToJump;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;

    [Header("Ground Check")]
    public float height;
    public LayerMask ground;
    bool grounded;

    public Transform orientation;

    float hInput;
    float vInput;

    public AudioSource footsteps;
    bool playing = false;
    bool moving = false;

    Vector3 direction;

    Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        ResetJump();
        footsteps.volume = 0.1f;
    }

    private void Update() {
        grounded = Physics.Raycast(new Vector3 (transform.position.x, transform.position.y +0.1f, transform.position.z), Vector3.down, height + 0.1f, ground);

        MyInput();
        LimitSpeed();
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) {
            moving = true;
        } else {
            moving = false;
        }
        if (!playing && grounded && moving) {
            footsteps.Play();
            playing = true;
        } else if (playing && (!moving || !grounded)) {
            footsteps.Stop();
            playing = false;
        }
        if (grounded)
            rb.drag = friction;
        else
            rb.drag = 0;
    }

    private void FixedUpdate() {
        MovePlayer();
    }

    private void MyInput() {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKey(jumpKey) && readyToJump && grounded) {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpInterval);
        }
        // if (Input.GetKey(jumpKey) && rb.velocity.y == 0) {
        //     Jump();
        //     Invoke(nameof(ResetJump), jumpInterval);
        // }
    }

    private void MovePlayer() {
        direction = orientation.forward * vInput + orientation.right * hInput;
        if (grounded)
            rb.AddForce(direction.normalized * moveSpeed * 10f, ForceMode.Force);
        else
            rb.AddForce(direction.normalized * moveSpeed * 10f / drag, ForceMode.Force);

    }

    private void LimitSpeed() {
        Vector3 groundVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (groundVelocity.magnitude > moveSpeed) {
            Vector3 limitedVelocity = groundVelocity.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    private void Jump() {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump() {
        readyToJump = true;
    }
}
