using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : TankBase
{
    public Weapon nowWeapon;
    private float timer = 0;
    private void Start()
    {
        atk = 20;
        def = 5;
        maxHP = 100;
        nowHP = maxHP;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer>1&&GamePanel.Instance.gameObject.activeSelf == true)
        {
            Fire();
            timer = 0;
        }
    }
    public override void Fire()
    {
        if (nowWeapon != null)
        {
            nowWeapon.Fire();
        }
    }

}
