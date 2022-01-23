using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CongratScript : MonoBehaviour
{
    public TextMesh text;
    public ParticleSystem sparksParticles;
    
    private List<string> textToDisplay;
    
    private float rotatingSpeed;
    private float timeToNextText;

    private int currentText;
    
    // Start is called before the first frame update
    void Start()
    {
        timeToNextText = 0.0f;
        currentText = 0;
        
        rotatingSpeed = 150;

        textToDisplay = new List<string>();
        
        textToDisplay.Add("Congratulations");
        textToDisplay.Add("All Errors Fixed");

        text.text = textToDisplay[0];
        
        sparksParticles.Play();
    }

    // Update is called once per frame
    void Update()
    {
        text.transform.Rotate(Vector3.back * rotatingSpeed * Time.deltaTime);
        
        timeToNextText += Time.deltaTime;

        if (timeToNextText > 1.5f)
        {
            timeToNextText = 0.0f;
            
            currentText++;
            if (currentText >= textToDisplay.Count)
            {
                currentText = 0;
            }

            text.text = textToDisplay[currentText];
        }
    }
}