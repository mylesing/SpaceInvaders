using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetALife : MonoBehaviour
{
    public GameObject heart;
    public static float fallRate;
   

    // Start is called before the first frame update
    void Start()
    {
        fallRate = 0.999f;
    }

    // Update is called once per frame
    void Update()
    {
        float sign = 2 * Random.value - 1;
        Vector3 pos = new Vector3(10 * Random.value * sign, 11.0f, 0);
        if (Random.value > fallRate) {
            Instantiate (heart, pos, Quaternion.AngleAxis(0, Vector3.right));
        }

        if (Input.GetKeyDown(KeyCode.H)) {
            Instantiate (heart, pos, Quaternion.AngleAxis(0, Vector3.right));
        }
    }
}
