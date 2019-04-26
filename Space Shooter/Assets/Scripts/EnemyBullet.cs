using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject bulletSpawn01;
    public GameObject bulletSpawn02;
    public GameObject bulletPre;

    public float spawnBulletRate;
    // Start is called before the first frame update
    void Start()
    {
        SpawnBullet();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        
        if (transform.position.x < max.x) {
            Destroy(gameObject);
        }
    }
    
    void SpawnBullet() {

        GameObject anBullet = (GameObject) Instantiate(bulletPre);
        GameObject anBullet2 = (GameObject) Instantiate(bulletPre);
        anBullet.transform.position = bulletSpawn01.transform.position;
        anBullet2.transform.position = bulletSpawn02.transform.position;

        
        RefreshSpawn();
    }
    
    void RefreshSpawn() {
        Invoke("SpawnBullet", spawnBulletRate);
    }
}
