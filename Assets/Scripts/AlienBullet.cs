using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBullet : MonoBehaviour
{
    private Transform bullet;
    public float speed;

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

    void OnTriggerEnter(Collider collider) {
        //Debug.Log("IMPACT!");
        if (collider.CompareTag("Player")) {
            Destroy(collider.gameObject);
            Destroy(gameObject);
            Debug.Log("IMPACT!");
            
            GameOver.isPlayerDead = true;
        } else if (collider.CompareTag("Bunker")) {
            GameObject bunker = collider.gameObject;
            Bunker b = bunker.GetComponent<Bunker>();
            b.hp -= 1;
            Destroy(gameObject);
        }
    }
}
