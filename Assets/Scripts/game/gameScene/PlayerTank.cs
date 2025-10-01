using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : TankBase
{
    public GameObject nowWeapon;
    private void Awake()
    {
        moveSpeed = 10;
        rotateSpeed = 50;
    }
    void Update()
    {
        transform.Translate(Input.GetAxis("Vertical")*Vector3.forward * Time.deltaTime * moveSpeed);
        transform.Rotate(Input.GetAxis("Horizontal")*Vector3.up * Time.deltaTime * rotateSpeed);
    }
    public override void Fire()
    {
        
    }
}
