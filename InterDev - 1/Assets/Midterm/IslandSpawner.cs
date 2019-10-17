using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandSpawner : MonoBehaviour {
    public List<GameObject> islandList = new List<GameObject>();

    int islandElements = 10;
    // public List<


    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < islandElements; i++) {
            int randomIsland = Random.RandomRange
            Instantiate(islandList.RemoveAt());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
