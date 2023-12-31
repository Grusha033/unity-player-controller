using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    [SerializeField] private float mouseSensetivity = 70f; 
    [SerializeField] private Transform playerBody;
    private float xRotation = 0f;
    
    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update() {
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;     

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);       

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX); 

    }
}
