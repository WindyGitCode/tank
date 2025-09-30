using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Ratate2 : MonoBehaviour
{
    public float rotationSpeed;
    public bool isTurnRight = true;
    float timer = 0;
    void Update()
    {
        timer += Time.deltaTime;
        float y = transform.localEulerAngles.y;
        if (isTurnRight == true)
        {
            this.transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else
        {
            this.transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        if ((y >= 30 && y <= 31) || (y >= 330 && y <= 331))
        {
            if (timer > 2)
            {
                isTurnRight = !isTurnRight;
                timer = 0;
            }

        }
    }
}