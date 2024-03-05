using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Touchpad : MonoBehaviour
{

    SteamVR_Controller.Device device;
    SteamVR_TrackedObject trackedObject;
    public Slider sliderX, sliderY;

    void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObject.index);
    }

    void FixedUpdate()
    {
        Debug.Log("X Axis " + device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x);
        Debug.Log("Y Axis " + device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y);

        sliderX.value = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x;
        sliderY.value = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y;

        if(device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && device.GetAxis(Valve.VR.EVRButtonId
            .k_EButton_Axis0).y > 0.8f)
        {
            Debug.Log("Dpad Up...!!!");
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && device.GetAxis(Valve.VR.EVRButtonId
           .k_EButton_Axis0).y < -0.8f)
        {
            Debug.Log("Dpad Down...!!!");
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && device.GetAxis(Valve.VR.EVRButtonId
           .k_EButton_Axis0).x < -0.8f)
        {
            Debug.Log("Dpad Left...!!!");
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && device.GetAxis(Valve.VR.EVRButtonId
           .k_EButton_Axis0).x > 0.8f)
        {
            Debug.Log("Dpad Right...!!!");
        }
    }
}