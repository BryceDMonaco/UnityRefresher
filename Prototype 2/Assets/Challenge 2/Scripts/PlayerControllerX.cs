using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    private bool waitingToSpawnAgain = false;

    private int spawnDelay = 1;
    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && !waitingToSpawnAgain)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            waitingToSpawnAgain = true;
            Invoke("EnableSpawn", spawnDelay);
        }
    }

    void EnableSpawn()
    {
        waitingToSpawnAgain = false;
    }
}
