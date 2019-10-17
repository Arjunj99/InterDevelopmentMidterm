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

    private bool dir;

    private Queue<Vector3> bombs = new Queue<Vector3>();

    void Awake() {
        boat = new Boat();
        int dirint = Random.Range(0,1);
        if (dirint == 0)
            dir = false;
        else
            dir = true;
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
        // Gizmos.DrawWireSphere(this.transform.position, 4f);

        this.transform.Translate(new Vector3(0, 0, boat.GetCurrentSpeed() * Time.deltaTime));
        boat.SetCurrentRotation(boat.GetCurrentSpeed() * -2f);

        if (timer < timerLimit) {
            timer += Time.deltaTime;
        } else {
            Debug.Log("BOMBS SENT");
            bombs.Enqueue(new Vector3(this.transform.position.x + Random.Range(-bombSpread, bombSpread), this.transform.position.y, 
                this.transform.position.z + Random.Range(-bombSpread, bombSpread)));
            timer = 0f;
        }

        if (Physics.SphereCast(navRay, 4f, maxDist)) {
            if (dir)
                this.transform.Rotate(new Vector3(0, boat.GetCurrentRotation() * Time.deltaTime, 0));
            else
                this.transform.Rotate(new Vector3(0, boat.GetCurrentRotation() * -Time.deltaTime, 0));
        } else {
            if (boat.GetCurrentSpeed() < maxSpeed)
                boat.SetCurrentSpeed(boat.GetCurrentSpeed() + 0.2f);
        }


        // if(bombs.Count != 0) {
        //     GameObject newBomb = Instantiate(bombObject, this.transform.position + new Vector3(0,30,0), Quaternion.identity);
        //     newBomb.GetComponent<cannonArc>().impact = bombs.Dequeue();
        //     newBomb.GetComponent<cannonArc>().boatPos = this.transform.position;
        // }
    }

    // void OnCollisionEnter(Collision collision) {
    //     if (collision.gameObject.tag == "Bomb") {
    //         Destroy(gameObject);
    //     }
    // }
}
