using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    private float threashold = 0.03f;
    void Start()
    {
        Input.gyro.enabled = true;    
    }    
    void Update()
    {
        
        Quaternion r = GyroToUnityRotation(Input.gyro.attitude);
        transform.rotation = r * Quaternion.Euler(-90, 0, 0);
        print(isLayingFlat(r));
    }

    private Quaternion GyroToUnityRotation(Quaternion q) 
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }

    private bool isLayingFlat(Quaternion q)
    {
        print("x: " + q.x);
        print("y: " + q.y);
        print("z: " + q.z);
        return (q.x < threashold || q.x > -threashold) &&
               (q.y < threashold || q.y > -threashold);
    }
}
