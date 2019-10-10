using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatAI : MonoBehaviour {
    public Boat boat;
    private float maxDist = 40f;
    private float maxSpeed = 8f;

    void Awake() {
        boat = new Boat();
    }


    // Start is called before the first frame update
    void Start()
    {
        boat.SetInMotion(true);
    }

    // Update is called once per frame
    void Update() {
        Ray navRay = new Ray(this.transform.position, this.transform.forward);
        Debug.DrawRay(this.transform.position, this.transform.forward, Color.cyan, 10f);

        this.transform.Translate(new Vector3(0, 0, boat.GetCurrentSpeed() * Time.deltaTime));
        boat.SetCurrentRotation(boat.GetCurrentSpeed() * -2f);

        if (boat.GetCurrentSpeed() > 0f) {
            boat.SetCurrentSpeed(boat.GetCurrentSpeed() - 0.1f);
        }

        if (Physics.Raycast(navRay, maxDist)) {
            this.transform.Rotate(new Vector3(0, boat.GetCurrentRotation() * Time.deltaTime, 0));
        } else {
            if (boat.GetCurrentSpeed() < maxSpeed)
                boat.SetCurrentSpeed(boat.GetCurrentSpeed() + 0.2f);
        }
    }
}
