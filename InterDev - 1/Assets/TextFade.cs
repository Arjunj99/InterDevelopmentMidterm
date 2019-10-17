using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFade : MonoBehaviour {
    public bool cinematicMode = false; 

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            gameObject.GetComponent<TextMesh>().color = Color.white;
        } else {
            gameObject.GetComponent<TextMesh>().color = new Color32(255,255,255,0);
        }

        
    }
}
