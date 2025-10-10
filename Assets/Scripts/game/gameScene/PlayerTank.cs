using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : TankBase
{
    public Weapon nowWeapon;
    private float turretRotateSpeed;
    public GameObject turret;
    public Transform weaponPos;
    private void Awake()
    {
        moveSpeed = 8;
        rotateSpeed = 80;
        turretRotateSpeed = 100;
    }
    void Update()
    {
        transform.Translate(Input.GetAxis("Vertical")*Vector3.forward * Time.deltaTime * moveSpeed);
        transform.Rotate(Input.GetAxis("Horizontal")*Vector3.up * Time.deltaTime * rotateSpeed);
        turret.transform.Rotate(Input.GetAxis("Mouse X") * turretRotateSpeed * Vector3.up * Time.deltaTime);
        if (GamePanel.Instance.gameObject.activeSelf == true && Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    public override void Fire()
    {
        if (nowWeapon != null)
        {
            nowWeapon.Fire();
        }
    }
    public void ChangeWeapon(Weapon newWeapon)
    {
        if (nowWeapon != null)
        {
            Destroy(nowWeapon.gameObject);
        }
        nowWeapon = Instantiate(newWeapon, weaponPos,false);
    }
}
