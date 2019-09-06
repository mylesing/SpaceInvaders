using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alien : MonoBehaviour
{
    private Transform alienMatrix;
    public float speed;

    public GameObject shot;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        alienMatrix = GetComponent<Transform> ();
        //speed = 0.01f; 

        winText.enabled = false;
        //InvokeRepeating("Update", 0.1f, 0.3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        // // shift the alien matrix position
        alienMatrix.position += Vector3.right * speed;

        if (alienMatrix.position.x < -6 || alienMatrix.position.x > 6) {
            speed = -speed;
            Vector3 shift = new Vector3(.0f, .02f, .0f);
            alienMatrix.position += Vector3.down + shift;
        }

        if (alienMatrix.position.y <= -3) {
            GameOver.isPlayerDead = true;
        }

        if (Random.value > 0.9972) {
                Instantiate (shot, alienMatrix.position, alienMatrix.rotation);
        }
    }

    public void Die() {
        Destroy(gameObject);
    }
}
