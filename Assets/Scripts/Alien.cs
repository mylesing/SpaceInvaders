using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alien : MonoBehaviour
{
    private Transform alienMatrix;
    public static float speed;
    public static float fallRate;

    public GameObject shot;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        alienMatrix = GetComponent<Transform> ();
        speed = 0.01f; 
        fallRate = 0.98f;

        winText.enabled = false;

        foreach (Transform a in alienMatrix) {
            
        }

        //InvokeRepeating("Update", 0.1f, 0.3f);
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(alienMatrix.childCount);
        // // shift the alien matrix position
        alienMatrix.position += Vector3.right * speed;

        foreach (Transform a in alienMatrix) {

            if (a.position.x < -10 || a.position.x > 10) {
                // reverse the speed
                Debug.Log(a.gameObject.name);
                speed = -speed;
                Vector3 shift = new Vector3(.0f, .02f, .0f);
                alienMatrix.position += Vector3.down + shift;

                return;
            }

            if (Random.value > fallRate) {
                Instantiate (shot, a.position, a.rotation);
            }
        }

        Debug.Log(alienMatrix.position.x);
        if (alienMatrix.position.y <= -8) {
                GameOver.isPlayerDead = true;
                speed = 0.0f;
        }

        if (alienMatrix.childCount == 0) {
            winText.enabled = true;
        }
    }
    

    public void Die() {
        Destroy(gameObject);
    }
}
