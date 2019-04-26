using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHleath : MonoBehaviour {
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
           Destroy(gameObject); 
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "bullet") {
            Destroy(other.gameObject);
            health--;
            Debug.Log("FFunciono");
        }
    }
}
