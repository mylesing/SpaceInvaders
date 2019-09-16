using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TitleScript : MonoBehaviour
{

    private GUIStyle buttonStyle;
    public GameObject heart;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float sign = 2 * Random.value - 1;
        float sign2 = 2 * Random.value - 1;
        Vector3 pos = new Vector3(15 * Random.value * sign, 15.0f, 15 * Random.value * sign);
        if (Random.value > 0.95f) {
            Instantiate (heart, pos, Quaternion.AngleAxis(0, Vector3.up));
        }
    }

    void OnGUI (){
        GUILayout.BeginArea(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 200, 200));
        
        // Load the main scene
        // The scene needs to be added into build setting to be loaded!
        if (GUILayout.Button("New Game")){
            Application.LoadLevel("Main");
        }
        
        if (GUILayout.Button("Instructions")){
            Application.LoadLevel("Instructions");
        }
        
        if (GUILayout.Button("Exit Game")){
            Application.Quit();
            Debug.Log ("Application.Quit() only works in build, not in editor");
        }
        
        GUILayout.EndArea();  
    }
}
