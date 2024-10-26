using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float sens = 1;
    [SerializeField] Transform orientation;
    private float xRotation;
    private float yRotation;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //mouse input
        float mouseX = Input.GetAxisRaw("Mouse X")  * sens;
        float mouseY = Input.GetAxisRaw("Mouse Y")  * sens;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -75, 75);
        
        //cam rotate
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.rotation = Quaternion.Euler(0f,yRotation,0f);
    }
}
