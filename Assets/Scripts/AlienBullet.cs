using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour
{
    private Transform bullet;
    public float speed;
    public GameObject explosion;
    public AudioClip deathKnell;

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();  
        speed = 0.5f; 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bullet.position += Vector3.up * -speed;
        if (bullet.position.y <= -10) {
            Destroy(bullet.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision) {
        Collider collider = collision.collider;
        if (collider.CompareTag("Player")) {
            AudioSource.PlayClipAtPoint(deathKnell, new Vector3(0, 3,0));
            Instantiate(explosion, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
            PlayerObject.lives--;
            Debug.Log(PlayerObject.lives);

            if (PlayerObject.lives == 0) {
                collider.gameObject.SetActive(false);
                Destroy(gameObject);
                Alien.speed = 0.0f;
                Alien.fallRate = 1.0f;
                GameOver.isPlayerDead = true;
            }
        } else if (collider.CompareTag("Bunker")) {
            GameObject bunker = collider.gameObject;
            Bunker b = bunker.GetComponent<Bunker>();
            b.hp -= 1;
            Destroy(gameObject);
        }
    }

    // void OnTriggerEnter(Collider collider) {
    //     //Debug.Log("IMPACT!");
    //     if (collider.CompareTag("Player")) {
    //         //Destroy(collider.gameObject);
    //         collider.gameObject.SetActive(false);
    //         Destroy(gameObject);
    //         Alien.speed = 0.0f;
    //         Alien.fallRate = 1.0f;
    //         GameOver.isPlayerDead = true;
    //     } else if (collider.CompareTag("Bunker")) {
    //         GameObject bunker = collider.gameObject;
    //         Bunker b = bunker.GetComponent<Bunker>();
    //         b.hp -= 1;
    //         Destroy(gameObject);
    //     }
    // }
}
