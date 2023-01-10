using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public GameObject[] objects;      
    [SerializeField] GameObject enemy;     
    [SerializeField] GameObject player;
     
    [SerializeField] float spawnTime = 6f;   
    [SerializeField] Vector2 spawnArea;
    float timer;
 
    
    private void Start() 
    {  
        InvokeRepeating ("Spawn", spawnTime, spawnTime);
    }

    private void Update() 
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            SpawnEnemy();
            timer = spawnTime;
        }
    } 
 
    
    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();
        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        
        if(UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {
            position.y = UnityEngine.Random.Range(-spawnArea.y, spawnArea.x);
            position.x = spawnArea.x * f; 
        }
        
        position.z = 0;
        return position;
    }
    
    
    private void SpawnEnemy()
    {

        Vector3 position = GenerateRandomPosition();

        position += player.transform.position;
 
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().SetTarget(player);
        newEnemy.transform.parent = transform;
    }
}
