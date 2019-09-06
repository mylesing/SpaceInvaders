using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform bullet;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform> ();
        speed = 0.5f;
    }

    // 
    void FixedUpdate() {
        bullet.position += Vector3.up * speed;
        if (bullet.position.y >= 10) {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // remove object hit AND bullet if the bullet collides with an alien
    /*
    void OnCollisionEnter(Collision collision) {
        Debug.Log("IMPACT!");
        Collider collider = collision.collider;
        if (collider.CompareTag("Alien")) {
            Destroy(collider.gameObject);
            Destroy(gameObject);

        // otherwise if the bullet hits our protection bunker get rid of that
        } else if (collider.CompareTag("Bunker")) {
            Destroy(gameObject);
        }
    }
    */

    void OnTriggerEnter(Collider collider) {
        Debug.Log("Impact!");
        if (collider.CompareTag("Alien")) {
            Alien alien = collider.gameObject.GetComponent<Alien>();
            alien.Die();
            Destroy(gameObject);
            Score.currScore += 10;
            Debug.Log("IMPACT!");
        } else if (collider.CompareTag("Bunker")) {
            Destroy(gameObject);
            
        } else {
            Debug.Log("NO IMPACT!");
        }
    }
}
