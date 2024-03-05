using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEditor.UI;

public class animationCode : MonoBehaviour
{

    #region default Variables
    SteamVR_TrackedObject trackedObject;
    SteamVR_Controller.Device device;
    #endregion

    #region public Variables
    #endregion

    #region private Variables
    [SerializeField]
    private Animator Animator;
    #endregion

    #region default Methods
    #endregion

    #region public Methods
    #endregion

    #region private Methods
    private void Start()
    {
        try
        {
            trackedObject = GetComponent<SteamVR_TrackedObject>();
            device = SteamVR_Controller.Input((int)trackedObject.index);

            if (Checker() == true)
            {
                //Animator = GetComponent<Animator>();
                StartCoroutine(Renderer());
                Debug.Log("Run the animation now ...!!!");
            }
            else
            {
                Animator = GetComponent<Animator>();
                Do_Nothing();
            }
        }
        catch(System.Exception e) {
            Debug.Log("can not run this animation now please wait "+e.Message+" ...!!!");
        }
        finally
        {
            //none
        }
    }
    private void FixedUpdate()
    {
        if (Checker() == true)
        {
            //Animator = GetComponent<Animator>();
            StartCoroutine(Renderer());
            Debug.Log("Run the animation now ...!!!");
        }
        else
        {
            Animator = GetComponent<Animator>();
            Do_Nothing();
        }
    }
    private IEnumerator Renderer()
    {
        yield return new WaitForSeconds(Animator.GetCurrentAnimatorStateInfo(0).length);
    }
    private bool Checker()
    {
        int i = 1;
        try
        {
            try
            {
                if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && device.GetAxis(Valve.VR.EVRButtonId
               .k_EButton_Axis0).y > 0.8f)
                {
                    Debug.Log("Dpad Up...!!!");
                    return true;
                }
            }
            catch (System.Exception e1)
            {
                Debug.Log("can not find Dpad up now please wait " + e1.Message + " ...!!!");
            }
            finally
            {
                //none
            }
            try
            {
                if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && device.GetAxis(Valve.VR.EVRButtonId
              .k_EButton_Axis0).y < -0.8f)
                {
                    Debug.Log("Dpad Down...!!!");
                    return true;
                }
            }
            catch (System.Exception e2)
            {
                Debug.Log("can not find Dpad down now please wait " + e2.Message + " ...!!!");
            }
            finally
            {
                //none
            }
            try
            {
                if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && device.GetAxis(Valve.VR.EVRButtonId
              .k_EButton_Axis0).x < -0.8f)
                {
                    Debug.Log("Dpad Left...!!!");
                    return true;
                }
            }
            catch (System.Exception e3)
            {
                Debug.Log("can not find Dpad left now please wait " + e3.Message + " ...!!!");
            }
            finally
            {
                //none
            }
            try
            {
                if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && device.GetAxis(Valve.VR.EVRButtonId
              .k_EButton_Axis0).x > 0.8f)
                {
                    Debug.Log("Dpad Right...!!!");
                    return true;
                }
            }
            catch (System.Exception e4)
            {
                Debug.Log("can not find Dpad right now please wait " + e4.Message + " ...!!!");
            }
            finally
            {
                //none
            }
            return false;
        }
        catch(System.Exception e23)
        { 
            Debug.Log("can not handle the final part of animation "+e23.Message+" ...!!!"); 
            i = 0;
        }
        finally
        {
            //none
        }
        if (i == 1){return true; } else { return false; }
    }
    private void Do_Nothing()
    {
        //do nothing now...
    }
    #endregion
}