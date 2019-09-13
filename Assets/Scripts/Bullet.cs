using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform bullet;
    public float speed;
    public AudioClip deathKnell;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform> ();
        //deathKnell = GetComponent<AudioSource>();
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
    
    void OnCollisionEnter(Collision collision) {
        Collider collider = collision.collider;
        if (collider.CompareTag("Alien")) {
            collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
            collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            collider.gameObject.GetComponent<Transform>().parent = null;
            Destroy(gameObject);
            if (Alien.speed < 0) {
                Alien.speed -= 0.002f;
            } else {
                Alien.speed += 0.002f;
            }
            Score.currScore += 10;

        // otherwise if the bullet hits our protection bunker get rid of that
        } else if (collider.CompareTag("Bunker")) {
            Destroy(gameObject);
        }
    }
    

    /*void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Alien")) {
            // Alien alien = collider.gameObject.GetComponent<Alien>();
            // alien.Die();
            //Destroy(collider.gameObject);
            //Alien a = collider.gameObject.GetComponent<Alien>();
            collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
            //Debug.Log(collider.gameObject.GetComponent<Rigidbody>().
            Destroy(gameObject);
            //gameObject.GetComponent<Rigidbody>().useGravity = true;
            //AudioSource.PlayClipAtPoint(deathKnell, gameObject.transform.position);
            if (Alien.speed < 0) {
                Alien.speed -= 0.005f;
            } else {
                Alien.speed += 0.005f;
            }
            
            Score.currScore += 10;
            //Debug.Log("SCORE: " + Score.currScore);
        } else if (collider.CompareTag("Bunker")) {
            Destroy(gameObject);
            
        } else {
            Debug.Log("NO IMPACT!");
        }
    }*/
}
