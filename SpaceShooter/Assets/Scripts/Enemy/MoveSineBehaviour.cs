using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSineBehaviour : MonoBehaviour
{

    [SerializeField,Range(1f, 10f)]
    private float amplitude = 1f;

    [SerializeField, Range(.01f, 2f)]
    private float period = 1f;

    [SerializeField, Range(1f, 10f)]
    private float speed = 10f;

    [SerializeField, Range(0f, 4f)]
    private float offset = 1f;


    private Vector3 move;
    private Vector3 currentPosition;
    private float direction;


    private void Start()
    {
        direction = 1f;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
      
        currentPosition = transform.position;
     

        Vector3 position = transform.localPosition;
        position.y = SineWave(position.x, period, amplitude, offset);
        position.x += (speed * direction * Time.deltaTime) ;

        if (currentPosition.x > World.instance.boundaries.x) 
        {
            direction = -1f;
        }
        if (currentPosition.x < -World.instance.boundaries.x)
        {
            direction = 1f;
        }


        transform.localPosition = position;



    }

    public static float SineWave(float x,float period, float amplitude, float offset)
    {
        return (Mathf.Sin(Mathf.PI * (x + Time.deltaTime) * period) * amplitude) + offset;
    }
}
