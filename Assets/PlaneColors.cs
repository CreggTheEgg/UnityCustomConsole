using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneColors : MonoBehaviour
{
    private Renderer thisRenderer;

    // Start is called before the first frame update
    void Start()
    {
        thisRenderer = GetComponent<Renderer>();
        StartCoroutine(ChangeColor());
    }

    IEnumerator ChangeColor()
    {
        while (true)
        {
            thisRenderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            Debug.Log(thisRenderer.material.color.ToString());
            Debug.LogWarning("Test Warning");
            Debug.LogError("Test Error");

            yield return new WaitForSeconds(1f);
        }
    }

}
