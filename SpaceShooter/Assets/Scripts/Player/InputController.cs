using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Vector2 playerInputDirection { get; private set; }
    public bool playerInputShoot { get; private set; }

    private void Update()
    {
        playerInputDirection = GetInputDirection();
        playerInputShoot = GetInputShoot();
    }



    private Vector2 GetInputDirection()
    {
        Vector2 takeInput;

        //takeInput.x = Input.GetAxis("Horizontal");
        //takeInput.y = Input.GetAxis("Vertical");


        takeInput.x = Input.GetAxisRaw("Horizontal");
        takeInput.y = Input.GetAxisRaw("Vertical");

        takeInput = Vector2.ClampMagnitude(takeInput, 1f);

        return takeInput;
    }

    private bool GetInputShoot()
    {
        return Input.GetButtonDown("Fire1");
    }
}
