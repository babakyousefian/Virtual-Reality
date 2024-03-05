using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class katana : MonoBehaviour
{

    #region public Variables
    #endregion

    #region private Variables
    #endregion

    #region public Methods
    #endregion

    #region private Methods
    private void OnTriggerEnter(Collider other)
    {
        CutMeshController.instance.Cut(other.gameObject);
    }
    #endregion

}
