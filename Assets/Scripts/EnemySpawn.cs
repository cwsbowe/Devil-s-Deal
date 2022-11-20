using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public GameObject EnemyPrefab;
    public GameObject playerCharacter;
    public GameObject enemyHolder;
    float spawnCounter;
    public float spawnRate;
    public bool spawning;

    void Start() {   
        spawnCounter = 0;
    }

    void Update() {
        if(spawning){
            spawnCounter += Time.deltaTime;

            if(spawnCounter > spawnRate ){
                spawnCounter = 0;
                SpawnEnemy();
            }
        }
        
    }
    void SpawnEnemy() {
        //choose a random one of spawnpoints to spawn at
        List<Transform> children = new List<Transform>();
        foreach (Transform child in transform){
            children.Add(child);
        }
        int whichChild = Random.Range(0,children.Count);
        GameObject newEnemy = Instantiate(EnemyPrefab, enemyHolder.transform);
        newEnemy.GetComponent<CrawlerEnemyMovement>().player = playerCharacter;
        newEnemy.transform.position = children[whichChild].position;
    }
}
