using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour {
    private HazardZone hazard = new HazardZone(HazardZone.hazardType.whirlpool, new Vector3(1,1,1), new Vector3(1,1,1));
    public Animator whirlpoolAnim;
    public Animator stormAnim;
    public Animator sharkAnim;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
