using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class TankBase : MonoBehaviour
{
    protected int atk;
    protected int def;
    protected int maxHP;
    protected int nowHP;
    protected int moveSpeed;
    protected int rotateSpeed;
    abstract public void Fire();
    public virtual void Wound(TankBase other)
    {
        nowHP -= other.atk - def;
    }
    public virtual void Dead()
    {
        Destroy(this);
    } 
}
