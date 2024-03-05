using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detachable : MonoBehaviour
{

    private MeshRenderer meshRenderer;
    private GameObject bodyPartCopy;
    private Rigidbody rigidbodyCopy;

    private void Start()
    {

        try
        {
            meshRenderer = GetComponent<MeshRenderer>();
            Debug.Log("transfer child out of bound of array. can not accessable it...!!!");
            bodyPartCopy = transform.GetChild(1).gameObject;
            rigidbodyCopy = bodyPartCopy.GetComponent<Rigidbody>();
            bodyPartCopy.SetActive(false);
        }
        catch(System.Exception e) {
            Debug.Log("detachable class can not solved this array "+e.Message+" ...!!!");
        }
        finally
        {
            //none
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("pickup"))
        {
            meshRenderer.enabled = false;
            bodyPartCopy.SetActive(true);
            var random = UnityEngine.Random.Range(-10 , 10);
            rigidbodyCopy.AddTorque(new Vector3(random, random, random), ForceMode.Impulse);
        }
    }

}
