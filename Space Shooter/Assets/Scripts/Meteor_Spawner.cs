using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor_Spawner : MonoBehaviour {
    public GameObject meteorPre;
    public GameObject enemyPre;
    public float spawnRateMeteor;
    public float spawnRateEnemy;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnMeteor", spawnRateMeteor);
        Invoke("SpawnEnemy", spawnRateEnemy);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpawnMeteor() {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0) );
        
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1) );

        GameObject anMeteor = (GameObject) Instantiate(meteorPre);
        anMeteor.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));
        
        RefreshSpawn();
    }
    
    void SpawnEnemy() {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0,0) );
        
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1,1) );

        GameObject anEnemy = (GameObject) Instantiate(enemyPre);
        anEnemy.transform.position = new Vector2(max.x, Random.Range(min.y, max.y));
        
        RefreshEnemy();
    }

    void RefreshSpawn() {
        Invoke("SpawnMeteor", spawnRateMeteor);
    }
    
    void RefreshEnemy() {
        Invoke("SpawnEnemy", spawnRateEnemy);
    }

    
    
}
