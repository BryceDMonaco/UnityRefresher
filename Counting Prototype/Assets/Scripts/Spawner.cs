using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int ballsToSpawn = 100;
    public float spawnRateS = 0.1f;
    public GameObject ball;
    public GameObject restartButton;

    public float minForce = 10f;
    public float maxForce = 30f;
    
    // Start is called before the first frame update
    void Start()
    {
        restartButton.SetActive(false);
        StartCoroutine(SpawnBall());
    }

    IEnumerator SpawnBall()
    {
        for (int ballCount = 0; ballCount < ballsToSpawn; ballCount++)
        {
            Rigidbody spawnedBall = Instantiate(ball, transform.position, ball.transform.rotation).GetComponent<Rigidbody>();
        
            spawnedBall.AddForce(transform.right * Random.Range(minForce, maxForce), ForceMode.Impulse);
            
            yield return new WaitForSeconds(spawnRateS);
        }
        
        restartButton.SetActive(true);
    }
}
