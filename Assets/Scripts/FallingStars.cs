using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStars : MonoBehaviour
{
    private Transform star;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.value * 0.3f + 0.02f;
        star = GetComponent<Transform>();
        float s = Random.value * 2.0f;
        star.transform.localScale = new Vector3(s, s, s);
        
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
       star.position += Vector3.down * speed;
        if (star.position.y < -10.0f) {
            Destroy(gameObject);
        }
    }
}
