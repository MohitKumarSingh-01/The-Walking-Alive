using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    private CharacterController controller;
    private Transform lookRoot;

    private Vector3 move_Drirection;
    public float moveSpeed = 8;
    private float sprintSpeed = 10f;
    private float crouchSpeed = 2f;
    private float standHeight = 1.6f;
    private float crouchHeight = 1f;
    private bool isCrouching;

    private float gravity = 20;
    public float jump_Force = 8f;
    private float vertical_Velocity;


    private void Awake()
    {
        Instance = this;
        controller = GetComponent<CharacterController>();
        lookRoot = transform.GetChild(0);
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        MoveThePlayer();
        PlayerSprint();
        PlayerCrouch();
    }
    void MoveThePlayer()
    {
        move_Drirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        move_Drirection = transform.TransformDirection(move_Drirection);
        move_Drirection *= moveSpeed * Time.deltaTime;
        ApplyGravity();

        controller.Move(move_Drirection);

    }

    void ApplyGravity()
    {
        vertical_Velocity -= gravity * Time.deltaTime;

        PlayerJump();

        move_Drirection.y = vertical_Velocity * Time.deltaTime;

    }
    void PlayerJump()
    {
        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            vertical_Velocity = jump_Force;
        }
    }

    void PlayerSprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isCrouching)
        {
            moveSpeed = sprintSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && !isCrouching)
        {
            moveSpeed = 5f;
        }

    }

    void PlayerCrouch()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (isCrouching)
            {
                lookRoot.localPosition = new Vector3(0f, standHeight, 0f);

                moveSpeed = 5f;

                isCrouching = false;

            }
            else
            {
                lookRoot.localPosition = new Vector3(0f, crouchHeight, 0f);

                moveSpeed = crouchSpeed;

                isCrouching = true;
            }

        }

    }
}















































