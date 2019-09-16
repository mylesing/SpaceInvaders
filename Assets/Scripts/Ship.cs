using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private Transform ship;
    public static float speed;
    public static float numLives;
    public GameObject shot;
    public static float fallRate;

    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<Transform> ();
        speed = 0.03f;
        numLives = 4.0f;
        fallRate = 0.997f;
    }

    // Update is called once per frame
    void Update()
    {
        ship.position += Vector3.right * speed;
        if (ship.position.x < -10 || ship.position.x > 10) {
            // reverse the speed
            speed = -speed;
        }

        if (Random.value > fallRate) {
            Instantiate (shot, ship.position, ship.rotation);
        }
    }
}
