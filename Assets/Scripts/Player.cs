using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    [SerializeField] private float speed;
    [SerializeField] private float sprintModifier;
    [SerializeField] private Camera normalCam;

    private Rigidbody rb;

    private float baseFOV;
    private float sprintFOVModifier = 1.25f;

    void Start()
    {
        baseFOV = normalCam.fieldOfView;
        Camera.main.enabled = false;
        rb = GetComponent<Rigidbody>(); 
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //Axies
       float xMove = Input.GetAxisRaw("Horizontal"); // d key changes value to 1, a key changes value to -1
        float zMove = Input.GetAxisRaw("Vertical"); // w key changes value to 1, s key changes value to -1

        //States
        bool sprint = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
        bool isSprinting = sprint && xMove < 0 || sprint && xMove > 0;

        //Movement
        Vector3 direction = new Vector3(xMove, 0, zMove);
        direction.Normalize();

        float p_adjSpeed = speed;
        if (isSprinting)
        {
            p_adjSpeed *= sprintModifier;
        }
        rb.velocity = transform.TransformDirection(direction) * p_adjSpeed * Time.deltaTime;
         
        //FielOfView
        if (isSprinting ) { normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV * sprintFOVModifier, Time.deltaTime * 8f); }
        else
        {
            normalCam.fieldOfView = Mathf.Lerp(normalCam.fieldOfView, baseFOV, Time.deltaTime * 8f);
        }
    }
}

