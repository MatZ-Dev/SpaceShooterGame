using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownSine : MonoBehaviour
{
    [SerializeField, Range(1f, 10f)]
    private float amplitude = 1f;

    [SerializeField, Range(.01f, 2f)]
    private float period = 1f;

    private float speed = .5f;




    private float offset;

    private Vector3 move;
    private Vector3 currentPosition;

    private void Start()
    {
        offset = transform.position.x;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {

        currentPosition = transform.position;


        Vector3 position = transform.localPosition;
        position.x = SineWave(position.y, period, amplitude, offset);
        position.y += (speed * -1f * Time.deltaTime);


        transform.localPosition = position;
    }

    public static float SineWave(float y, float period, float amplitude, float offset)
    {
        return (Mathf.Sin(Mathf.PI * (y + Time.deltaTime) * period) * amplitude) + offset;
    }



}
