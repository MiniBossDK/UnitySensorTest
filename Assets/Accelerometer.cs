using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    private float threashold = 0.035f;

    private Quaternion rotationCorrection = Quaternion.Euler(0, 90, 0);

    void Start()
    {
        Input.gyro.enabled = true;    
    }    
    void Update()
    {
        Quaternion rotation = GyroToUnityRotation(Input.gyro.attitude);
        transform.rotation = RotationFromOrientation(rotation * rotationCorrection);
        print(isLayingFlat(Input.gyro.attitude));
    }

    private Quaternion GyroToUnityRotation(Quaternion q) 
    {
        return new Quaternion(-q.x, q.y, -q.z, -q.w);
    }

    private Quaternion RotationFromOrientation(Quaternion q)
    {
        DeviceOrientation orientation = Input.deviceOrientation;
        if(((int)orientation) >= 1)
        {
            return new Quaternion(-q.y, -q.x, -q.z, -q.w) * Quaternion.Euler(0, 180, 0);
        }
        return q;
    }

    private bool isLayingFlat(Quaternion q)
    {
        return (q.x <= threashold && q.x >= -threashold) && 
               (q.y <= threashold && q.y >= -threashold) ;
    }
}
