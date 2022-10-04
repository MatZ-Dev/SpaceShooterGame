using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInDirectionBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;


    private void Update() => transform.localPosition += Vector3.down * speed * Time.deltaTime;
}
