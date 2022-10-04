using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [HideInInspector]
    public Vector2 getDirection { private get; set; }

    public Vector3 setBoundaries { private get; set; }

    public Vector3 curretnVelocity {  get; private set; }

    [Header("Movement Settings")]
    [SerializeField]
    private float maxSpeed = 10f;

    [SerializeField]
    private float maxAcceleration = 10f;

    private Vector3 velocity;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();

        curretnVelocity = velocity;
    }

    private void Move()
    {
        Vector3 desiredVelocity = new Vector3(getDirection.x, getDirection.y, 0f) * maxSpeed;
        float maxSpeedChange = maxAcceleration * Time.fixedDeltaTime;

        velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity.x, maxSpeedChange);
        velocity.y = Mathf.MoveTowards(velocity.y, desiredVelocity.y, maxSpeedChange);

        Vector3 displacement = velocity * Time.fixedDeltaTime;

        //Constraints
        Vector3 newPosition = transform.localPosition + displacement;

        // Set limits
        if (newPosition.x < -setBoundaries.x + .5f)
        {
            newPosition.x = -setBoundaries.x + .5f;
            velocity.x = 0f;
        }
        else if (newPosition.x > setBoundaries.x - .5f)
        {
            newPosition.x = setBoundaries.x - .5f;
            velocity.x = 0f;
        }
        if (newPosition.y < -setBoundaries.y + 1f)
        {
            newPosition.y = -setBoundaries.y + 1f;
            velocity.y = 0f;
        }
        else if (newPosition.y > setBoundaries.y)
        {
            newPosition.y = setBoundaries.y;
            velocity.y = 0f;
        }

        transform.localPosition = newPosition;
    }
}
