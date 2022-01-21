using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    public float movementMultiplier = 5f;
    public float scaleMultiplier = 2f;
    
    public Color[] colors = new Color[]
        {Color.red, Color.red + Color.yellow, Color.yellow, Color.green, Color.cyan, Color.blue, Color.magenta};
    
    private int colorIndex = 0;
    
    void Start()
    {
        transform.position = new Vector3(3, 4, 1);
        transform.localScale = Vector3.one * 1.3f;
        
        InvokeRepeating("ChangeColor", 0, .5f);
    }
    
    void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);

        transform.position = new Vector3((float) Math.Cos(Time.time), (float) Math.Sin(Time.time), (float) Math.Sin(Time.time)) * movementMultiplier;
        
        transform.localScale = new Vector3((float) Math.Sin(Time.time), (float) Math.Cos(Time.time), (float) Math.Tan(Time.time)) * scaleMultiplier;
    }

    void ChangeColor()
    {
        Renderer.material.color = colors[colorIndex];
        colorIndex++;
        if (colorIndex == colors.Length)
        {
            colorIndex = 0;
        }
    }
}
