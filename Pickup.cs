using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Valve.VR;

public class Pickup : MonoBehaviour
{

    SteamVR_Controller.Device device;
    SteamVR_TrackedObject trackedObject;
    public bool pickedUp;
    FixedJoint fixJoint;
    Rigidbody rigid;

    void Start()
    {
        trackedObject = GetComponentInParent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedObject.index);
        rigid = GetComponent<Rigidbody>();
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("pickup") && device.GetPressDown(SteamVR_Controller.ButtonMask.Grip) &&
           col.transform.parent == null)
        {
            col.attachedRigidbody.isKinematic = true;
            col.attachedRigidbody.useGravity = false;
            col.transform.parent = this.transform;
            pickedUp = true;
        }
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip) && col.transform.parent != null)
        {
            col.attachedRigidbody.isKinematic = false;
            col.attachedRigidbody.useGravity = true;
            col.attachedRigidbody.velocity = device.velocity;
            col.attachedRigidbody.angularVelocity = device.angularVelocity;
            col.transform.parent = null;
            pickedUp = false;
        }
    }

    /*
    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("pickup") && device.GetPressDown(SteamVR_Controller.ButtonMask.Grip) &&
            fixJoint == null)
        {
            fixJoint = col.gameObject.AddComponent<FixedJoint>();
            fixJoint.connectedBody = rigid;
            pickedUp = true;
        }
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip) && fixJoint != null)
        {
            Destroy(fixJoint);
            col.attachedRigidbody.velocity = device.velocity;
            col.attachedRigidbody.angularVelocity = device.angularVelocity;
            pickedUp = false;
        }
    }
    */
}