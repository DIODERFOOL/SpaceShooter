using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public GameObject bulletS;
    public GameObject bulletPre;
    public float speed;

    public float health;

    public float duration = 1;


    private SpriteRenderer m_SpriteRenderer;

    private Color originalColor;
    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

        originalColor = m_SpriteRenderer.material.color;


    }

    // Update is called once per frame
    void Update() {
        Move();
        Shoot();

        if (health <= 0) {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    private void Move() {
        float horizontal = Input.GetAxis ("Vertical"); // to move object sideward
        if (horizontal != 0f)
            if (horizontal > 0f)
                transform.Translate (speed * Time.deltaTime, 0f, 0f);
            else
                transform.Translate (-speed * Time.deltaTime, 0f, 0f);
 
        float vertical = Input.GetAxis ("Horizontal"); // to move object upward
        if (vertical != 0f)
            if (vertical > 0f)
                transform.Translate (0f, -speed * Time.deltaTime, 0f);
            else
                transform.Translate (0f, speed * Time.deltaTime, 0f);
    }

    private void Shoot() {
        if (Input.GetKeyDown("space")) {
            GameObject bullet = (GameObject) Instantiate(bulletPre);
            bullet.transform.position = bulletS.transform.position;
        }
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "enemyBullet") {
            health--;
            Destroy(other.gameObject);
            
            StartCoroutine(ChangeColor());
              

        } else if (other.gameObject.tag == "enemy") {
            health--;
        }
    }
    
    IEnumerator ChangeColor()
    {
 
            m_SpriteRenderer.material.color = Color.red;
            yield return new WaitForSeconds(1);
            m_SpriteRenderer.material.color = originalColor;
     
    }
}
