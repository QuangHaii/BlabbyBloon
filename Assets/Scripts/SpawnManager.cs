using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private Vector3 spawnPos;
    private float startDelay = 1;
    private PlayerController playerControllerScript;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPos = transform.position;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        Invoke("SpawnRandomObstacles", startDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRandomObstacles()
    {
        if (!playerControllerScript.gameOver)
        {
            int randomIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[randomIndex], spawnPos, obstaclePrefabs[randomIndex].transform.rotation);
            float randomInterval = Random.Range(0.7f, 1.5f);
            Invoke("SpawnRandomObstacles", randomInterval);
        }
    }
}
