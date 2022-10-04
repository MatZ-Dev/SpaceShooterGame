using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    public static StartUI instance;

    [SerializeField]
    private Text countDown;


    private void Awake()
    {
        instance = this;
    }

    public void EnableUI()
    {
        gameObject.SetActive(true);
    }

    public void DisableUI()
    {
        gameObject.SetActive(false);
    }

    public void CountDownWrite(string text)
    {
        countDown.text = text;
    }
}
