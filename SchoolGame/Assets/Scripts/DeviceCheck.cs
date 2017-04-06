using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceCheck : MonoBehaviour 
{
    #if !UNITY_ANDROID
    void Start () {
        Destroy( this.gameObject );
	}
    #endif
}
