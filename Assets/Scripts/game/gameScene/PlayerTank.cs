using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : TankBase
{
    public GameObject nowWeapon;
    private float turretRotateSpeed;
    public GameObject turret;
    private void Awake()
    {
        moveSpeed = 10;
        rotateSpeed = 50;
        turretRotateSpeed = 150;
    }
    void Update()
    {
        transform.Translate(Input.GetAxis("Vertical")*Vector3.forward * Time.deltaTime * moveSpeed);
        transform.Rotate(Input.GetAxis("Horizontal")*Vector3.up * Time.deltaTime * rotateSpeed);
        turret.transform.Rotate(Input.GetAxis("Mouse X") * turretRotateSpeed * Vector3.up * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    public override void Fire()
    {
        
    }
}
