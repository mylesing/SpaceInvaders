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
    public Text playAgain;

    // Start is called before the first frame update
    void Start()
    {
        alienMatrix = GetComponent<Transform> ();
        speed = 0.01f; 
        fallRate = 0.9997f;

        winText.enabled = false;
        playAgain.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // shift the alien matrix position
        alienMatrix.position += Vector3.right * speed;

        foreach (Transform a in alienMatrix) {

            if (a.position.x < -12 || a.position.x > 12) {
                // reverse the speed
                speed = -speed;
                Vector3 shift = new Vector3(.0f, .02f, .0f);
                alienMatrix.position += Vector3.down + shift;

                return;
            }

            if (Random.value > fallRate) {
                Instantiate (shot, a.position, a.rotation);
            }

            if (a.position.y <= -5) {
                GameOver.isPlayerDead = true;
                speed = 0.0f;
                Ship.speed = 0.0f;
                Ship.fallRate = 1.0f;
                GetALife.fallRate = 1.0f;
            }
        }

        

        if (alienMatrix.childCount == 0) {
            winText.enabled = true;
            playAgain.enabled = true;
            speed = 0.0f;
            fallRate = 1.0f;
            Ship.speed = 0;
            Ship.fallRate = 1.0f;
            GetALife.fallRate = 1.0f;
        }
    }
    

    public void Die() {
        Destroy(gameObject);
    }
}
