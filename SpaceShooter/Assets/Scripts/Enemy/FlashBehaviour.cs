using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashBehaviour : MonoBehaviour
{  
    // Skin Color
    private Material skinMaterial;
    private Color originalColor;

    private WaitForSeconds delay;


    private void Awake()
    {
        skinMaterial = GetComponentInChildren<Renderer>().material;        
        originalColor = skinMaterial.color;

        delay = new WaitForSeconds(.2f);
    }


    public void Flash()
    {
        StartCoroutine("CO_Flash");
    }

    private IEnumerator CO_Flash()
    {
        skinMaterial.color = Color.white;
        yield return delay;
        skinMaterial.color = originalColor;
    }


}
