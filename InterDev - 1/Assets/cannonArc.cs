using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonArc : MonoBehaviour {
    public Vector3 boatPos;
    public Vector3 impact;
    private Vector3 arcPoint;
    private bool arcComplete = false;


    // Start is called before the first frame update
    void Start() {
        arcPoint = new Vector3((boatPos.x), 100f, (boatPos.z));
    }

    // Update is called once per frame
    void Update() {
        if (arcComplete == false) {
            this.transform.position = Vector3.Lerp(this.transform.position, arcPoint, 3f * Time.deltaTime);
            if (this.transform.position == arcPoint) {
                arcComplete = true;
            }
        } else {
            this.transform.position = Vector3.Lerp(this.transform.position, impact, 3f * Time.deltaTime);
            if (this.transform.position == impact) {
                Destroy(gameObject);
            }
        }
    }

    public static float InverseLerp(Vector3 a, Vector3 b, Vector3 value)
     {
         Vector3 AB = b - a;
         Vector3 AV = value - a;
         return Vector3.Dot(AV, AB) / Vector3.Dot(AB, AB);
     }
}
