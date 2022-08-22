using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : Entity
{
    public Transform cameraPosition;
    [HideInInspector]public new Camera camera;

    float rotX = 0;
    float rotY = 0;

    protected override void Start()
    {
        CameraSet();
    }

    void CameraSet()
    {
        if (!isLocalPlayer) return;

        camera = Camera.main;
        camera.transform.SetParent(cameraPosition);
        camera.transform.position = cameraPosition.position;
        camera.transform.rotation = cameraPosition.rotation;
    }

    void CameraLook()
    {
        //camera.transform.LookAt(transform);
        rotX += Input.GetAxis("Mouse X");
        rotY += Input.GetAxis("Mouse Y");

        rotY = Mathf.Clamp(rotY, -90f, 90f);

        camera.transform.rotation = Quaternion.Euler(-rotY, rotX, 0f);
        transform.rotation = Quaternion.Euler(0,  rotX, 0f);
    }

    protected override void Update()
    {
        if (!isLocalPlayer) return;
        MoveControl();
        CameraLook();
    }

    protected override void LateUpdate()
    {
        
    }

    public override void MoveControl()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        float speed = 0;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }

        Move(horizontal, vertical, speed);
    }

    public override void OnTriggerEnter(Collider other)
    {
    }

}
