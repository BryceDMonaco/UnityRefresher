using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public int value = 5;

    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType <GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameManager.UpdateScore(value);
    }
}
