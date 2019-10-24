using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {
    public Vector3 cameraPosition;
    public Vector3 cameraRotation;
    public GameObject mainCamera;
    public GameObject anchorObject;
    public GameObject beacons;
    public float focalLength;
    public float focusDistance;
    public float aperture;
    public bool isLit;


    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            mainCamera.GetComponent<CameraMovement>().cameraPosition = anchorObject.transform.position + cameraPosition;
            mainCamera.GetComponent<CameraMovement>().cameraRotationEuler = cameraRotation;
            mainCamera.GetComponent<CameraMovement>().cinematicMode = true;
            mainCamera.GetComponent<CameraMovement>().focalLength = focalLength;
            mainCamera.GetComponent<CameraMovement>().focusDistance = focusDistance;
            mainCamera.GetComponent<CameraMovement>().aperture = aperture;
            beacons.SetActive(true);
            isLit = true;
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            mainCamera.GetComponent<CameraMovement>().cinematicMode = false;
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
