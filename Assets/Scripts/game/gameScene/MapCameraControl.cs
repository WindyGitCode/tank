using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCameraControl : MonoBehaviour
{
    public Transform target;
    public float H;
    Vector3 pos;
    void LateUpdate()
    {
        pos.x=target.position.x;
        pos.z=target.position.z;
        pos.y = H;
        this.transform.position = pos;
    }
}
