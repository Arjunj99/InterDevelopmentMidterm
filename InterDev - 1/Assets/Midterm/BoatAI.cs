using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatAI : MonoBehaviour {
    public Boat boat;
    private float maxDist = 70f;
    private float maxSpeed = 8f;
    private float bombSpread = 60f;
    public GameObject bombObject;

    private float timer = 0f;
    private float timerLimit = 2f;

    private Queue<Vector3> bombs = new Queue<Vector3>();

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

        if (timer < timerLimit) {
            timer += Time.deltaTime;
            // Debug.Log(timer);
        } else {
            Debug.Log("BOMBS SENT");
            bombs.Enqueue(new Vector3(this.transform.position.x + Random.Range(-bombSpread, bombSpread), this.transform.position.y, 
                this.transform.position.z + Random.Range(-bombSpread, bombSpread)));
            timer = 0f;
        }


        // if (boat.GetCurrentSpeed() > 0f) {
        //     boat.SetCurrentSpeed(boat.GetCurrentSpeed() - 0.1f);
        // }

        if (Physics.SphereCast(navRay, 4f, maxDist)) {
            this.transform.Rotate(new Vector3(0, boat.GetCurrentRotation() * Time.deltaTime, 0));
        } else {
            if (boat.GetCurrentSpeed() < maxSpeed)
                boat.SetCurrentSpeed(boat.GetCurrentSpeed() + 0.2f);
        }


        if(bombs.Count != 0) {
            GameObject newBomb = Instantiate(bombObject, this.transform.position, Quaternion.identity);
            newBomb.GetComponent<cannonArc>().impact = bombs.Dequeue();
            newBomb.GetComponent<cannonArc>().boatPos = this.transform.position;
        }
    }
}
