using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform bullet;
    public float speed;
    public AudioClip deathKnell;
    public float d;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform> ();
        speed = 0.5f;
        d = 0.002f;
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
        if (Input.GetKeyDown(KeyCode.Z)) {
            d = 0.0015f;
        }

        if (Input.GetKeyDown(KeyCode.H)) {
            d = 0.002f;
        }
    }

    // remove object hit AND bullet if the bullet collides with an alien
    
    void OnCollisionEnter(Collision collision) {
        Collider collider = collision.collider;
        if (collider.CompareTag("Alien")) {
            // boom!
            AudioSource.PlayClipAtPoint(deathKnell, new Vector3(0, 3, 0));

            // object gravity is on so it falls. bullet dies though
            collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
            collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            Destroy(gameObject);

            // less aliens? speed up!!
            if (Alien.speed < 0) {
                Alien.speed -= d;
            } else {
                Alien.speed += d;
            }
            
            // don't add more score for hitting something twice u dingus
            if (collider.gameObject.GetComponent<Transform>().parent != null) {
                collider.gameObject.GetComponent<Transform>().parent = null;
                Score.currScore += 10;
            }

        // otherwise if the bullet hits our protection bunker get rid of that
        } else if (collider.CompareTag("Ship")) {
            Ship.numLives -= 1;
            if (Ship.numLives == 0) {
                collider.gameObject.GetComponent<Rigidbody>().useGravity = true;
                collider.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                Destroy(gameObject);
            }
            
            Score.currScore += 30;
        } else if (collider.CompareTag("Bunker")) {
            Destroy(gameObject);
        }
    }
    
}
