using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBottomDestory : MonoBehaviour
{
    private float bottom;
    
    private void Start()
    {
        bottom = -World.instance.boundaries.y;
    }


    void Update()
    {
        if (transform.position.y > bottom) return;
        Destroy(gameObject);
    }
}
