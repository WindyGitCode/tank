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
        rotateSpeed = 100;
        turretRotateSpeed = 40;
        maxHP = 100;
        nowHP = 50;
        atk = 30;
        def = 10;
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
        if (nowHP <= 0)
        {
            Dead();
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
    public void AddHP(int Value)
    {
        nowHP += Value;
        if (nowHP > maxHP)
        {
            nowHP = maxHP;
        }
    }
    public void AddAtk(int Value)
    {
        atk += Value;
    }
    public void AddSpeed(int Value)
    {
        moveSpeed += Value;
    }
    public override void Wound(TankBase other)
    {
        base.Wound(other);
    }
    public override void Dead()
    {
        Debug.Log("Game Over");
    }
}
