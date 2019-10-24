using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour {
    public GameObject boat;
    public GameObject bird;
    public GameObject shark;
    public Vector2 bounds = new Vector2(300f, 300f);
    public int instances;


    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < instances; i++) {
            GameObject newboat = Instantiate(boat, new Vector3(Random.Range(-bounds.x, bounds.x), 2f, 
                Random.Range(-bounds.y, bounds.y)), Quaternion.identity);
            newboat.transform.Rotate(new Vector3(0f, Random.Range(0f, -360f), 0f));
            GameObject newBird = Instantiate(bird, new Vector3(Random.Range(-bounds.x, bounds.x), 2f, 
                Random.Range(-bounds.y, bounds.y)), Quaternion.identity);
            newBird.transform.Rotate(new Vector3(0f, Random.Range(0f, -360f), 0f));
            GameObject newShark = Instantiate(shark, new Vector3(Random.Range(-bounds.x, bounds.x), 2f, 
                Random.Range(-bounds.y, bounds.y)), Quaternion.identity);
            newShark.transform.Rotate(new Vector3(0f, Random.Range(0f, -360f), 0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
