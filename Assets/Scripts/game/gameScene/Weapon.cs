using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform[] gunPoints;
    public GameObject bullet;
    public void Fire()
    {
        for (int i = 0; i < gunPoints.Length; i++)
        {
            Instantiate(bullet, gunPoints[i].position, gunPoints[i].rotation);
        }
    }
}
