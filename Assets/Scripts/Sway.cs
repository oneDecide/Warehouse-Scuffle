using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    [SerializeField] public float intensity;
    public float smooth;

    private Quaternion origin_rotation;


    private void Start()
    {
        origin_rotation = transform.localRotation;
    }

    private void Update()
    {
        UpdateSway();
    }

    private void UpdateSway()
    {
        float t_x_mous = Input.GetAxis("Mouse X");
        float t_y_mous = Input.GetAxis("Mouse Y");

        Quaternion x_adj = Quaternion.AngleAxis(-intensity * t_x_mous, Vector3.up);
        Quaternion y_adj = Quaternion.AngleAxis(intensity * t_y_mous, Vector3.right);
        Quaternion tgt_rotation = origin_rotation * x_adj * y_adj;
        
        transform.localRotation = Quaternion.Lerp(transform.localRotation, tgt_rotation, Time.deltaTime * smooth);
    }
}
