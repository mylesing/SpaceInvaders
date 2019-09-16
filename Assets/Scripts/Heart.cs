using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{

    private Transform heart;
    public float speed;
    public GameObject particle;
    public AudioClip pickup;
    
    // Start is called before the first frame update
    void Start()
    {
        heart = GetComponent<Transform>();
        speed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        heart.position += Vector3.down * speed;
        if (heart.position.y < -7.0f) {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    void OnCollisionEnter(Collision collision) {
        Collider collider = collision.collider;
        if (collider.CompareTag("Player")) {
            AudioSource.PlayClipAtPoint(pickup, gameObject.transform.position);
            Instantiate(particle, gameObject.transform.position, Quaternion.AngleAxis(-90, Vector3.right));
            PlayerObject.lives++;
            Destroy(gameObject);
        } else if (collider.CompareTag("Ground")) {
            Destroy(gameObject);
        }
    }
}
