using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ButtonInputs : MonoBehaviour
{

    SteamVR_TrackedObject trackedObject;
    SteamVR_Controller.Device device;
    private float h;
    private float v;
    private float Z;
    private float speed;

    void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObject.index);
    }

    public void Initialization(float _speed)
    {
        speed = _speed;
    }

    public void MoveUp()
    {
        v = 1;
        CheckVirtualRealityOutOfBounds();
    }
    public void MoveDown()
    {
        v = -1;
        CheckVirtualRealityOutOfBounds();
    }
    public void MoveLeft()
    {
        h = -1;
        CheckVirtualRealityOutOfBounds();
    }
    public void MoveRight()
    {
        h = 1;
        CheckVirtualRealityOutOfBounds();
    }
    public void StopMoving()
    {
        v = 0;
        h = 0;
        Z = 0;
        CheckVirtualRealityOutOfBounds();
    }

    private void CheckVirtualRealityOutOfBounds()
    {
        //z == (-2.66 _ 2.66) , y == (-1.2 _ 1.2) , x == (-3.6 _ 4.18)
        if (transform.position.x < -3.60f)
        {
            Vector3 pos = transform.position;
            pos.x = -3.60f;
            transform.position = pos;
        }
        if (transform.position.x > 4.18f)
        {
            Vector3 pos = transform.position;
            pos.x = 4.18f;
            transform.position = pos;
        }
        if (transform.position.y > 1.20f)
        {
            Vector3 pos = transform.position;
            pos.y = 1.20f;
            transform.position = pos;
        }
        if(transform.position.y < -1.20f)
        {
            Vector3 pos = transform.position;
            pos.y = -1.20f;
            transform.position = pos;
        }
        if(transform.position.z < -2.66f)
        {
            Vector3 pos = transform.position;
            pos.z = -2.66f;
            transform.position = pos;
        }
        if(transform.position.z > 2.66f)
        {
            Vector3 pos = transform.position;
            pos.z = 2.66f;
            transform.position = pos;
        }
    }

    void FixedUpdate()
    {
        if ((SteamVR_Controller.Input((int)trackedObject.index) != null))
        {
            virtualRealityController();
        }
        else
        {
            Checkkeyboard_PUSH_VirtualRealityController();
        }
        Vector3 moving = new Vector3(speed * h * Time.deltaTime , speed * v * Time.deltaTime , 
            speed * Z * Time.deltaTime);
        transform.position += moving;
        CheckVirtualRealityOutOfBounds();
    }

    private void virtualRealityController()
    {
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger) == true)
        {
            Debug.Log("Trigger Touch...!!!");
        }
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) == true)
        {
            Debug.Log("Trigger touch down...!!!");
        }
        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger) == true)
        {
            Debug.Log("Trigger touch up...!!!");
        }
    }

    private void Checkkeyboard_PUSH_VirtualRealityController()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            MoveDown();
        }else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            MoveUp();
        }
        CheckKeyboard_PULL_VirtualRealityController();
    }

    private void CheckKeyboard_PULL_VirtualRealityController()
    {

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A)
            || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D)
              || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)
                || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            StopMoving();
        }
    }
}