using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HapticFeedback : MonoBehaviour
{

    SteamVR_Controller.Device device;
    SteamVR_TrackedObject trackedObject;
    public ushort hapticForce;

    void Start()
    {
        trackedObject= GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObject.index);
    }

    void FixedUpdate()
    {
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        {
            device.TriggerHapticPulse(hapticForce);
        }
    }
}
