using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
/**
 * This class controls Camera Movement and Panning between Transforms. 
 * It uses two equivalent representations:
 * - Date consists of a Date formatted as "MM/DD/YYYY" or "MM/DD/YY".
 * - Date consists of a Month, Day and Year.
 * 
 * Date stores a value for all data fields, regardless of which constructor was called.
 * 
 * @author arjunjaishankar
 * @version 28/11/2019
 */
public class CameraMovement : MonoBehaviour {
    private PostProcessVolume volume = null;
    private Vignette vignette = null;
    private DepthOfField depthOfField = null;
    public GameObject hinge;

    private Quaternion tempRot;





    // public PostProcessProfile spyGlassProfile;



    private Vector3 cameraPosition;
    private Quaternion cameraRotation;
    public GameObject player;

    public Camera cam;
    private int zoomInFOV = 5;
    private int zoomOutFOV = 60;
    public bool isScouting = false;
    public GameObject demon;

    public int rotationSpeed = -20;
    public BoatController boatController;
    public List<Vector3> positions = new List<Vector3>();
    public List<Vector3> rotations = new List<Vector3>();
    public GameObject ppm;

    public Image zoomImage;

    public bool canDisembark;
    void Start() {
        volume = ppm.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out vignette);
        volume.profile.TryGetSettings(out depthOfField);

        vignette.enabled.value = true;
        vignette.intensity.value = 0f;

        depthOfField.enabled.value = true;
        depthOfField.focusDistance.value = 10f;
        depthOfField.aperture.value = 17.2f;
        depthOfField.focalLength.value = 159f;
    }

    void Update() {
        // if (Input.GetKeyDown(KeyCode.Q)) {
        //     if (canDisembark) { canDisembark = false; } else { canDisembark = true; }
        // }


        //Debugging Tools
        if (canDisembark) {
            if (Input.GetKey(KeyCode.Alpha1)) {
                cameraPosition = positions[0];
                cameraRotation = Quaternion.Euler(rotations[0]);
            } else if (Input.GetKey(KeyCode.Alpha2)) {
                cameraPosition = positions[1];
                cameraRotation = Quaternion.Euler(rotations[1]);
            } else if (Input.GetKey(KeyCode.Alpha3)) {
                cameraPosition = positions[2];
                cameraRotation = Quaternion.Euler(rotations[2]);
            } else if (Input.GetKey(KeyCode.Alpha4)) {
                cameraPosition = positions[3];
                cameraRotation = Quaternion.Euler(rotations[3]);
            } else if (Input.GetKey(KeyCode.Alpha5)) {
                cameraPosition = positions[4];
                cameraRotation = Quaternion.Euler(rotations[4]);
            } else {
                this.cameraPosition = demon.transform.position + demon.transform.forward * 1.5f + demon.transform.right * 3;
                this.cameraRotation = Quaternion.Euler(demon.transform.rotation.x, demon.transform.rotation.y, demon.transform.rotation.z);
            }
            hinge.transform.rotation = Quaternion.Slerp(this.transform.rotation, cameraRotation, 0.8f * Time.deltaTime);
        }
        // IF STATEMENT TILL HERE CAN BE DELETED

        if (!canDisembark) {
            this.cameraPosition = player.transform.position + (player.transform.up * 6) + (player.transform.forward * -20);
            if (!isScouting) {
                this.cameraRotation = player.transform.rotation;
                hinge.transform.rotation = Quaternion.Slerp(hinge.transform.rotation, cameraRotation, 0.8f * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.LeftShift)) {
                cam.fieldOfView = Mathf.Lerp(this.cam.fieldOfView, zoomInFOV, 2f * Time.deltaTime);
                vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0.76f, 0.7f * Time.deltaTime);
                depthOfField.focalLength.value = Mathf.Lerp(depthOfField.focalLength.value, 1f, 0.3f * Time.deltaTime);
                isScouting = true;
            } else {
                cam.fieldOfView = Mathf.Lerp(this.cam.fieldOfView, zoomOutFOV, 2f * Time.deltaTime);
                vignette.intensity.value = Mathf.Lerp(vignette.intensity.value, 0f, 0.7f * Time.deltaTime);
                depthOfField.focalLength.value = Mathf.Lerp(depthOfField.focalLength.value, 159f, 1.8f * Time.deltaTime);
                isScouting = false;
            }

            if(isScouting && Input.GetKey(KeyCode.A)) {
                this.transform.Rotate(new Vector3(0, rotationSpeed*Time.deltaTime, 0));
            }
            if(isScouting && Input.GetKey(KeyCode.D)) {
                this.transform.Rotate(new Vector3(0, -rotationSpeed*Time.deltaTime, 0));
            }
            if(isScouting && Input.GetKey(KeyCode.W)) {
                this.transform.Rotate(new Vector3(rotationSpeed*Time.deltaTime, 0, 0));
            }
            if(isScouting && Input.GetKey(KeyCode.S)) {
                this.transform.Rotate(new Vector3(-rotationSpeed*Time.deltaTime, 0, 0));
            }
        }

        // this.transform.position = Vector3.Lerp(this.transform.position, cameraPosition, 2f * Time.deltaTime);
        hinge.transform.position = Vector3.Lerp(hinge.transform.position, player.transform.position, 2f * Time.deltaTime);

        // this.transform.position =  new Vector3(Mathf.Lerp(this.transform.position.x,
        //         cameraPosition.x, 2f * Time.deltaTime), Mathf.Lerp(this.transform.position.y, cameraPosition.y, 2f * Time.deltaTime), Mathf.Lerp(this.transform.position.z, cameraPosition.z, 2f * Time.deltaTime));

    }
}
            
            

            // this.transform.rotation = Quaternion.Slerp(this.transform.rotation, cameraRotation, 0.8f * Time.deltaTime);
        // }
        

        // if (Input.GetKey(KeyCode.Space) && start == false) {
        //             StartCoroutine(cameraPan());
        //             start = true;
        // }
        
    // }

    // void Turn(float angle) {
    //     // this.transform.Rotate(new Vector3(0,0,angle));


    //     this.transform.Rotate(new Vector3(0,angle,0));
    // }
// }





//     void Start() {
//         // this.cameraPosition = player.transform.position + (player.transform.up * -25) + (player.transform.forward * 5) ;
//         zoomImage.CrossFadeAlpha(0, 0f, false);
//         // this.cameraRotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y + 90f, this.transform.rotation.z);
//     }

//     void Update() {


//         if (Input.GetKeyDown(KeyCode.Q) && boatController.canQ) {
//             Debug.Log(landMode);
//             if (landMode) {
//                 landMode = false;
//             } else {
//                 landMode = true;
//             }
            
//             // cameraPosition = new Vector3(this.transform.position.x - 100, this.transform.position.y, this.transform.position.z);
//         }

//         if (landMode) {
//             if (Input.GetKey(KeyCode.Alpha1)) {
//                 cameraPosition = positions[0];
//                 cameraRotation = Quaternion.Euler(rotations[0]);
//             } else if (Input.GetKey(KeyCode.Alpha2)) {
//                 cameraPosition = positions[1];
//                 cameraRotation = Quaternion.Euler(rotations[1]);
//             } else if (Input.GetKey(KeyCode.Alpha3)) {
//                 cameraPosition = positions[2];
//                 cameraRotation = Quaternion.Euler(rotations[2]);
//             } else if (Input.GetKey(KeyCode.Alpha4)) {
//                 cameraPosition = positions[3];
//                 cameraRotation = Quaternion.Euler(rotations[3]);
//             } else if (Input.GetKey(KeyCode.Alpha5)) {
//                 cameraPosition = positions[4];
//                 cameraRotation = Quaternion.Euler(rotations[4]);
//             } else {
//                 this.cameraPosition = demon.transform.position + demon.transform.forward * 1.5f + demon.transform.right * 3;
//                 this.cameraRotation = Quaternion.Euler(demon.transform.rotation.x, demon.transform.rotation.y, demon.transform.rotation.z);
//             }
            
            
            
//             this.transform.rotation = Quaternion.Slerp(this.transform.rotation, cameraRotation, 0.8f * Time.deltaTime);

//         }

//         if (!landMode) {
//         Quaternion tempRotation = new Quaternion(0,0,0,0);

//         this.cameraPosition = player.transform.position + (player.transform.up * -20) + (player.transform.forward * 6) ;

//         if (this.transform.rotation.z != 0 && !isScouting) {
//             this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y + 90, 0);
//             // Debug.Log("Reset");
//          }

//         // if (this.transform.rotation.y > (player.transform.rotation.z + 90) && !isScouting) {
//         //     this.transform.Rotate(new Vector3(0,0.1f,0));
//         // } else if (this.transform.rotation.y < (player.transform.rotation.z + 90) && !isScouting) {
//         //     this.transform.Rotate(new Vector3(0,-0.1f,0));
//         // }

//             // Debug.Log("Angle should be: " + ((player.transform.rotation.z) * Mathf.Rad2Deg) );
//             // this.transform.Rotate(new Vector3(0,angle,0));

//             // this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, player.transform.rotation.z + 90, this.transform.rotation.z);
//             // Debug.Log("Reset");
//         // }

//         if (Input.GetKeyDown(KeyCode.LeftShift)) {
            
//         }

//         bool lockCamera = false;
//         if (Input.GetKey(KeyCode.LeftShift)) {
//             // if (lockCamera == false) {
//             //     tempRotation = this.transform.rotation;
//             //     lockCamera = true;
//             // }
//             cam.fieldOfView = Mathf.Lerp(this.cam.fieldOfView, zoomInFOV, 2f * Time.deltaTime);
//             zoomImage.CrossFadeAlpha(1, 0.2f, false);
//             isScouting = true;
//         } else {
//             // if (lockCamera == true) {
//             //     this.transform.rotation = tempRotation;
//             //     lockCamera = false;
//             // }
//             cam.fieldOfView = Mathf.Lerp(this.cam.fieldOfView, zoomOutFOV, 2f * Time.deltaTime);
//             zoomImage.CrossFadeAlpha(0, 0.2f, false);
//             isScouting = false;
//         }

//         if(isScouting && Input.GetKey(KeyCode.A)) {
//             this.transform.Rotate(new Vector3(0, rotationSpeed*Time.deltaTime, 0));
//         }
//         if(isScouting && Input.GetKey(KeyCode.D)) {
//             this.transform.Rotate(new Vector3(0, -rotationSpeed*Time.deltaTime, 0));
//         }
//         if(isScouting && Input.GetKey(KeyCode.W)) {
//             this.transform.Rotate(new Vector3(rotationSpeed*Time.deltaTime, 0, 0));
//         }
//         if(isScouting && Input.GetKey(KeyCode.S)) {
//             this.transform.Rotate(new Vector3(-rotationSpeed*Time.deltaTime, 0, 0));
//         }

        



//         // this.cameraRotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y + 90f, this.transform.rotation.z);
//             // player.transform.rotation.y + 90f, player.transform.rotation.z);



//         // this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z);
//         //     player.transform.rotation.y + 90f, player.transform.rotation.z);
        
        
//           /*new Vector3(-20f,6f,0)*/
//         // this.cameraRotation = Quaternion.Euler(player.transform.rotation.x,
//         //     player.transform.rotation.y + 90f, player.transform.rotation.z);
//         }
//         // if (Input.GetKey(KeyCode.Q)) {
//             this.transform.position = new Vector3(Mathf.Lerp(this.transform.position.x,
//                 cameraPosition.x, 2f * Time.deltaTime), Mathf.Lerp(this.transform.position.y, cameraPosition.y, 2f * Time.deltaTime), Mathf.Lerp(this.transform.position.z, cameraPosition.z, 2f * Time.deltaTime));
//             // this.transform.rotation = Quaternion.Slerp(this.transform.rotation, cameraRotation, 0.8f * Time.deltaTime);
//         // }
        

//         // if (Input.GetKey(KeyCode.Space) && start == false) {
//         //             StartCoroutine(cameraPan());
//         //             start = true;
//         // }
        
//     }

//     void Turn(float angle) {
//         // this.transform.Rotate(new Vector3(0,0,angle));


//         this.transform.Rotate(new Vector3(0,angle,0));
//     }
// }
