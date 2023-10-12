using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float playerSpeed = 20f;  // The speed at which the player will move.
    private CharacterController myCC; // Reference to the CharacterController component attached to the player.

    private Vector3 inputVector; // Stores the raw input from the player.
    private Vector3 movementVector; // The final movement vector for the player.
    private float myGravity = -10f; // The gravitational force applied to the player.

    void Start()
    {
        myCC = GetComponent<CharacterController>(); // Get the CharacterController component from the same GameObject.
    }

    void Update()
    {
        GetInput(); // Call the function to retrieve player input.
        MovePlayer(); // Call the function to move the player.
    }

    void GetInput()
    {
        // Retrieve player input for movement.
  ;

        // Create a vector from raw input values (horizontal and vertical) to represent the desired movement direction.
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        inputVector.Normalize(); // Ensure that the input vector has a magnitude of 1 (unit vector).
        // Transform the input vector to be relative to the player's local coordinate system.
        inputVector = transform.TransformDirection(inputVector);

        // Calculate the final movement vector by combining the input vector (scaled by speed) and the gravitational force.
        movementVector = (inputVector * playerSpeed) + (Vector3.up * myGravity);
    }

    void MovePlayer()
    {
        // Move the player using the CharacterController component, applying the movement vector over time (deltaTime).
        // By multiplying your movement by Time.deltaTime, you ensure that the movement is frame rate-independent.
        myCC.Move(movementVector * Time.deltaTime);
    }
}
