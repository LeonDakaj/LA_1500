using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public static bool cursorlocked = true;
    [SerializeField] private Transform player;
    [SerializeField] private Transform cams;

    [SerializeField] private float xSensitivity;
    [SerializeField] private float ySensitivity;
    [SerializeField] private float maxLookAngle;

    private Quaternion camCenter; // set rotation origin for cameras to camCenter

    void Start()
    {
        
    }

    void Update()
    {
        SetY();
        SetX();
        UpdateCursorLock(); 
    }

    void SetY() { 
    
        float p_input = Input.GetAxis("Mouse Y") * ySensitivity * Time.deltaTime;
        Quaternion p_adj = Quaternion.AngleAxis(p_input, -Vector3.right);
        Quaternion p_delta = cams.localRotation * p_adj;

        if (Quaternion.Angle(camCenter, p_delta) > maxLookAngle)
        {
            cams.localRotation = p_delta;
        }
    }
    void SetX()
    {

        float p_input = Input.GetAxis("Mouse X") * xSensitivity * Time.deltaTime;
        Quaternion p_adj = Quaternion.AngleAxis(p_input, Vector3.up);
        Quaternion p_delta = player.localRotation * p_adj;
        player.localRotation = p_delta;

    }

    void UpdateCursorLock() {

        if (cursorlocked)
        {

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorlocked = false;
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorlocked = true;
            }
        }
    
    }
}
