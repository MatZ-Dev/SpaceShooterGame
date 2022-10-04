using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public static World instance; 

    public Vector3 boundaries { get; private set; }

    private void Awake()
    {
        instance = this;
        boundaries = GetScreenBounds();
    }

    private Vector3 GetScreenBounds()
    {
        Camera mainCamera = Camera.main;
        Vector3 screenVector = new Vector3(Screen.width, Screen.height, 0f);

        return mainCamera.ScreenToWorldPoint(screenVector);
    }

}
