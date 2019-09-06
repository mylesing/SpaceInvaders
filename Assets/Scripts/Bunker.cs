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
        if (hp <= 0) {
            Destroy(gameObject);
        }
    }
}
