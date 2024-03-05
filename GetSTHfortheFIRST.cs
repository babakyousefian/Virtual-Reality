using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class GetSTHfortheFIRST : MonoBehaviour
{

    public GameObject somethings;
    public bool sthOpen;
    SteamVR_Controller.Device device;
    SteamVR_TrackedObject trackedObject;

    void Start()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObject.index);
        somethings.SetActive(false);
    }

    void Update()
    {
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            sthOpen = !sthOpen;
            somethings.SetActive(sthOpen);
        }
    }

}
