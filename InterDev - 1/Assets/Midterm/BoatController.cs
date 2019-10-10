﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour {

    public KeyCode forward; public KeyCode left; public KeyCode right; public KeyCode back;
    
    // public float moveSpeed = 0;
    // public float rotationSpeed = 0;
    // private bool isInMotion = false;
    // public Rigidbody rb;
    // public TextMesh HintText;
    // private bool whileSailing = true;
    // private bool won = false;
    public GameObject camera;
    public CameraMovement cameraMovement;
    public bool canQ;
    public Boat boat;

    public List<GameObject> IslandList = new List<GameObject>();

    void Awake() {
        boat = new Boat("SS Imperial");
    }

    void Update() {
        this.transform.Translate(new Vector3(0, 0, boat.GetCurrentSpeed() * Time.deltaTime));

        if (boat.GetCurrentSpeed() > 0f) {
            boat.SetCurrentSpeed(boat.GetCurrentSpeed() - 0.1f);
        }

        if (Input.GetKey(forward) && boat.GetCurrentSpeed() < 10f && !cameraMovement.isScouting) {
            boat.SetCurrentSpeed(boat.GetCurrentSpeed() + 0.2f);
            boat.SetInMotion(true);
        } else {
            boat.SetInMotion(false);
        }

        boat.SetCurrentRotation(boat.GetCurrentSpeed() * -2f);

        if (Input.GetKey(left) && boat.GetCurrentSpeed() > 0f && !cameraMovement.isScouting) {
            this.transform.Rotate(new Vector3(0, boat.GetCurrentRotation() * Time.deltaTime, 0));
            camera.SendMessage("Turn", boat.GetCurrentRotation() * Time.deltaTime);
        }
        if (Input.GetKey(right) && boat.GetCurrentSpeed() > 0f && !cameraMovement.isScouting) {
            this.transform.Rotate(new Vector3(0, boat.GetCurrentRotation() * -Time.deltaTime, 0));
            camera.SendMessage("Turn", boat.GetCurrentRotation() * -Time.deltaTime);
        }

        // if (whileSailing) {
        //     if (Vector3.Distance(this.transform.position, IslandList[13].transform.position) < 50 && Input.GetKey(KeyCode.Space)) {
        //         won = true;
        //         whileSailing = false;
        //         // HintText.text = "YOU WON!!!";
        //     // } else if(Input.GetKey(KeyCode.Space)) {
        //     //     whileSailing = false;
        //     //     // HintText.text = "This isn't the right city.";
        //     } else if(Vector3.Distance(this.transform.position, IslandList[0].transform.position) < 50) {
        //         HintText.text = "I have a quest for you. Find my City! \n It is found in a far off country among an invading force.";
        //     } else if(Vector3.Distance(this.transform.position, IslandList[1].transform.position) < 50) {
        //         HintText.text = "This statue marks the Kingdoms of Demons";
        //     } else if(Vector3.Distance(this.transform.position, IslandList[2].transform.position) < 50) {
        //         HintText.text = "The Demon City of Azimir.";
        //     } else if(Vector3.Distance(this.transform.position, IslandList[3].transform.position) < 50) {
        //         HintText.text = "The Port City of Quazir.";
        //     } else if(Vector3.Distance(this.transform.position, IslandList[4].transform.position) < 50) {
        //         canQ = true;
        //         HintText.text = "A great battleground.";
        //     } else if(Vector3.Distance(this.transform.position, IslandList[5].transform.position) < 50) {
        //         HintText.text = "The Infernal Capital of Demons.";
        //     } else if(Vector3.Distance(this.transform.position, IslandList[6].transform.position) < 50) {
        //         HintText.text = "A nearby city is under seige by Knights.";
        //     } else if(Vector3.Distance(this.transform.position, IslandList[7].transform.position) < 50) {
        //         HintText.text = "Two giants battle here.";
        //     } else if(Vector3.Distance(this.transform.position, IslandList[8].transform.position) < 50) {
        //         HintText.text = "A Shipwreck.";
        //     } else if(Vector3.Distance(this.transform.position, IslandList[9].transform.position) < 50) {
        //         HintText.text = "The Shin Villages.";
        //     } else if(Vector3.Distance(this.transform.position, IslandList[10].transform.position) < 50) {
        //         HintText.text = "This statue marks the Kingdoms of the Knights.";
        //     } else if(Vector3.Distance(this.transform.position, IslandList[11].transform.position) < 50) {
        //         HintText.text = "The Knight City of Kholinar.";
        //     } else if(Vector3.Distance(this.transform.position, IslandList[12].transform.position) < 50) {
        //         HintText.text = "A nearby city is under seige by Demons.";
        //     } else if(Vector3.Distance(this.transform.position, IslandList[13].transform.position) < 50) {
        //         HintText.text = "The Holy City of Urithru. \n Press Space to Dock into the City of Treasures";
        //     } else {
        //         HintText.text = "";
        //         canQ = false;
        //     }
        // } else {
        //     if (won) {
        //         HintText.text = "!!!YOU WON!!!";
        //     } else {
        //         // HintText.text = "THIS ISN'T THE RIGHT CITY";
        //         // System.Threading.Thread.Sleep(5000);
        //         // waitTimer(3);
        //         // StartCoroutine(wait());
        //         whileSailing = true;
                
        //     }
        // }
        
    }

    void waitTimer(float time) {
        float timer = 0;
        while (timer < time) {
            timer += Time.deltaTime;
        }
    }
    // IEnumerator wait() {
    //     yield return new WaitForSeconds(3);
    // }

}





// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class BoatController : MonoBehaviour {
//     public float moveSpeed = 0;
//     public float rotationSpeed = 0;
//     private bool isInMotion = false;
//     public Rigidbody rb;
//     public TextMesh HintText;
//     private bool whileSailing = true;
//     private bool won = false;
//     public GameObject camera;
//     public CameraMovement cameraMovement;
//     public bool canQ;

//     public List<GameObject> IslandList = new List<GameObject>();

//     // Start is called before the first frame update
//     void Start() {
        
//     }

//     // Update is called once per frame
//     void Update() {
//         this.transform.Translate(new Vector3(0,moveSpeed*Time.deltaTime,0));
//         if (moveSpeed > 0f)
//             moveSpeed -= 0.1f;

//         if(Input.GetKey(KeyCode.W) && moveSpeed < 10f && !cameraMovement.isScouting) {
//             moveSpeed += 0.2f;
//             // this.transform.Translate(new Vector3(0,moveSpeed*Time.deltaTime,0));
//             isInMotion = true;
//         } else {
//             isInMotion = false;
//         }

//         rotationSpeed = moveSpeed * -2f;


//         // if(Input.GetKey(KeyCode.S)) {
//         //     this.transform.Translate(new Vector3(0,-moveSpeed*Time.deltaTime,0));
//         // }
//         if(Input.GetKey(KeyCode.A) && moveSpeed > 0 && !cameraMovement.isScouting) {
//             this.transform.Rotate(new Vector3(0,0,rotationSpeed*Time.deltaTime));
//             camera.SendMessage("Turn", rotationSpeed*Time.deltaTime);
//         }
//         if(Input.GetKey(KeyCode.D) && moveSpeed > 0 && !cameraMovement.isScouting) {
//             this.transform.Rotate(new Vector3(0,0,-rotationSpeed*Time.deltaTime));
//             camera.SendMessage("Turn", -rotationSpeed*Time.deltaTime);
//         }
//         if (whileSailing) {
//             if(Vector3.Distance(this.transform.position, IslandList[13].transform.position) < 50 && Input.GetKey(KeyCode.Space)) {
//                 won = true;
//                 whileSailing = false;
//                 // HintText.text = "YOU WON!!!";
//             // } else if(Input.GetKey(KeyCode.Space)) {
//             //     whileSailing = false;
//             //     // HintText.text = "This isn't the right city.";
//             } else if(Vector3.Distance(this.transform.position, IslandList[0].transform.position) < 50) {
//                 HintText.text = "I have a quest for you. Find my City! \n It is found in a far off country among an invading force.";
//             } else if(Vector3.Distance(this.transform.position, IslandList[1].transform.position) < 50) {
//                 HintText.text = "This statue marks the Kingdoms of Demons";
//             } else if(Vector3.Distance(this.transform.position, IslandList[2].transform.position) < 50) {
//                 HintText.text = "The Demon City of Azimir.";
//             } else if(Vector3.Distance(this.transform.position, IslandList[3].transform.position) < 50) {
//                 HintText.text = "The Port City of Quazir.";
//             } else if(Vector3.Distance(this.transform.position, IslandList[4].transform.position) < 50) {
//                 canQ = true;
//                 HintText.text = "A great battleground.";
//             } else if(Vector3.Distance(this.transform.position, IslandList[5].transform.position) < 50) {
//                 HintText.text = "The Infernal Capital of Demons.";
//             } else if(Vector3.Distance(this.transform.position, IslandList[6].transform.position) < 50) {
//                 HintText.text = "A nearby city is under seige by Knights.";
//             } else if(Vector3.Distance(this.transform.position, IslandList[7].transform.position) < 50) {
//                 HintText.text = "Two giants battle here.";
//             } else if(Vector3.Distance(this.transform.position, IslandList[8].transform.position) < 50) {
//                 HintText.text = "A Shipwreck.";
//             } else if(Vector3.Distance(this.transform.position, IslandList[9].transform.position) < 50) {
//                 HintText.text = "The Shin Villages.";
//             } else if(Vector3.Distance(this.transform.position, IslandList[10].transform.position) < 50) {
//                 HintText.text = "This statue marks the Kingdoms of the Knights.";
//             } else if(Vector3.Distance(this.transform.position, IslandList[11].transform.position) < 50) {
//                 HintText.text = "The Knight City of Kholinar.";
//             } else if(Vector3.Distance(this.transform.position, IslandList[12].transform.position) < 50) {
//                 HintText.text = "A nearby city is under seige by Demons.";
//             } else if(Vector3.Distance(this.transform.position, IslandList[13].transform.position) < 50) {
//                 HintText.text = "The Holy City of Urithru. \n Press Space to Dock into the City of Treasures";
//             } else {
//                 HintText.text = "";
//                 canQ = false;
//             }
//         } else {
//             if (won) {
//                 HintText.text = "!!!YOU WON!!!";
//             } else {
//                 // HintText.text = "THIS ISN'T THE RIGHT CITY";
//                 // System.Threading.Thread.Sleep(5000);
//                 // waitTimer(3);
//                 // StartCoroutine(wait());
//                 whileSailing = true;
                
//             }
//         }
        
//     }

//     void waitTimer(float time) {
//         float timer = 0;
//         while (timer < time) {
//             timer += Time.deltaTime;
//         }
//     }
//     // IEnumerator wait() {
//     //     yield return new WaitForSeconds(3);
//     // }

// }
