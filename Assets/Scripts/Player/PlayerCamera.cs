using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] float sens = 5;
    [SerializeField] Transform orientation;
    private float xRotation;
    private float yRotation;

    public bool control;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        control = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if(control)
        {
            //mouse input
            float mouseX = Input.GetAxisRaw("Mouse X")  * (100 * sens) * Time.fixedDeltaTime;
            float mouseY = Input.GetAxisRaw("Mouse Y")  * (100 * sens) * Time.fixedDeltaTime;
        
            yRotation += mouseX;
            xRotation -= mouseY;

            xRotation = Mathf.Clamp(xRotation, -85, 85);
        
            //cam rotate
            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
            orientation.rotation = Quaternion.Euler(0f,yRotation,0f);
        }
        
    }

    public void SetSens(float value)
    {
        sens = value;
    }
}
