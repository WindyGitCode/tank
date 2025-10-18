using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : TankBase
{
    public Weapon nowWeapon;
    protected float timer = 0;
    public float fireCD=1;
    public GameObject explosionPrefab;
    protected void Start()
    {
        atk = 20;
        def = 5;
        maxHP = 100;
        nowHP = maxHP;
    }
    protected void Update()
    {
        timer += Time.deltaTime;
        if (timer> fireCD && GamePanel.Instance.gameObject.activeSelf == true)
        {
            Fire();
            timer = 0;
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
    public override void Wound(TankBase other)
    {
        base.Wound(other);
    }
    public override void Dead()
    {
        base.Dead();
        Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
    }
}
