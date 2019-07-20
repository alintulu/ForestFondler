using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMovement : MonoBehaviour
{
    CharacterController characterController;

    public float speed = 6.0f;
    public string inputh;
    public string inputv;


    private Vector2 moveDirection = Vector2.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveDirection = new Vector2(Input.GetAxis(inputh), -Input.GetAxis(inputv));
        moveDirection *= speed;

        characterController.Move(moveDirection * Time.deltaTime);
    }
}

