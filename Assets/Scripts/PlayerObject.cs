using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public float thrustSpeed;
    private Transform player;

    public GameObject shot;
    //public Transform shotSpawn;

    // Start is called before the first frame update
    void Start()
    {
        thrustSpeed = 0.03f;   
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // move right
        float h = Input.GetAxis("Horizontal");
        if (h > 0 && player.position.x < 7) {
            gameObject.transform.Translate(thrustSpeed, 0, 0);
        } else if (h < 0 && player.position.x  > -7) {
            gameObject.transform.Translate(-thrustSpeed, 0, 0);
        }

        // if (bullet.position.x > 10 || bullet.position.x < 10) {
        //     Destroy(gameObject);
        // }
    }


    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Vector3 spawnPos = gameObject.transform.position;
            spawnPos.y += 0.6f;
            Instantiate(shot, spawnPos, Quaternion.identity);

        }
    }
}
