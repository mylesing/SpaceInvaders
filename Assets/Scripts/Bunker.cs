using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bunker : MonoBehaviour
{
    public float hp;

    // Start is called before the first frame update
    void Start()
    {
        hp = 4;
    }

    // Update is called once per frame
    void Update()
    {
        float currScale = hp / 4.0f;
        transform.localScale = new Vector3(transform.localScale.x, currScale, transform.localScale.z);
        if (hp <= 0) {
            Destroy(gameObject);
        }
    }
}
