using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class CameraHandler : MonoBehaviour {

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_TRIGGERAUTO);
        }
    }
   
}
