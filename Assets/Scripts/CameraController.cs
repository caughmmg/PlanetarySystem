using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();

    }

    private void PlayerInput()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("q"))
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("e"))
        {
            pos.y += panSpeed * Time.deltaTime;
        }

        if (pos.y >= 401) pos.y = 400;
        if (pos.y <= 149) pos.y = 150;

        if (pos.z >= 351) pos.z = 350;
        if (pos.z <= -401) pos.z = -400;

        if (pos.x >= 351) pos.x = 350;
        if (pos.x <= -351) pos.x = -350;

        transform.position = pos;

       
    }
}
