using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private PlayerContoller playerContollerScript;

    public GameObject obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25,0,0);

    private float startDelay = 2;
    private float repeatRate = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle),startDelay,repeatRate);
        playerContollerScript = GameObject.Find("Player").GetComponent<PlayerContoller>();
    }

    void SpawnObstacle()
    {
        if (playerContollerScript.gameOver == false)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        } 
    
    }
}
