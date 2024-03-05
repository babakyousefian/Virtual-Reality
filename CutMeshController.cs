using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Valve.VR;

public class CutMeshController : MonoBehaviour
{
    #region default Variables
    SteamVR_Controller.Device device;
    SteamVR_TrackedObject trackedObject;
    public bool pickedUp;
    #endregion

    #region public Variables
    public static CutMeshController instance;
    public Transform _body;
    #endregion

    #region private Variables
    #endregion

    #region public Methods
    //constructor method
    public CutMeshController()
    {
        instance = this;
    }
    public void Cut(GameObject target)
    {
        //var sliceable = target.GetComponent<GameObject>();
        //if(sliceable == null)
        //{
            //return;
        //}
        //Plane plane = new Plane(Vector3.right, 0f);
    }
    public void Start()
    {

        try
        {
            trackedObject = GetComponentInParent<SteamVR_TrackedObject>();
            device = SteamVR_Controller.Input((int)trackedObject.index);
        }
        catch(System.Exception e) {
            Debug.Log("can not cutMeshController class now please wait "+e.Message+" ...!!!");
        }
        finally
        {
            //none
        }

    }
    public void OnTriggerStay(Collider col)
    {
        Get_Katana(col);
        if(Get_Katana(col) == true)
        {
            Move_Down_Katana();
        }
    }
    #endregion

    #region private Methods
    private bool Get_Katana(Collider col)
    {
        bool flag = false;
        if (col.CompareTag("pickup") && device.GetPressDown(SteamVR_Controller.ButtonMask.Grip) &&
          col.transform.parent == null)
        {
            col.attachedRigidbody.isKinematic = true;
            col.attachedRigidbody.useGravity = false;
            col.transform.parent = this.transform;
            pickedUp = true;
            flag = true;
            return flag;
        }
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip) && col.transform.parent != null)
        {
            col.attachedRigidbody.isKinematic = false;
            col.attachedRigidbody.useGravity = true;
            col.attachedRigidbody.velocity = device.velocity;
            col.attachedRigidbody.angularVelocity = device.angularVelocity;
            col.transform.parent = null;
            pickedUp = false;
            flag = true;
            return flag;
        }
        else return flag;
    }
    private void Move_Down_Katana()
    {
        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger) == true)
        {
            Debug.Log("Trigger touch down...!!!");
            //Create method...
        }
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && device.GetAxis(Valve.VR.EVRButtonId
           .k_EButton_Axis0).y < -0.8f)
        {
            Debug.Log("Dpad Down...!!!");
            //Create method...
        }
    }
    #endregion
}
