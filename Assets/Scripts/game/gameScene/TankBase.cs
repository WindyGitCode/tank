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
    public int MaxHP=>maxHP;
    public int NowHP=>nowHP;
    public int MoveSpeed=>moveSpeed;
    public int RotateSpeed=>rotateSpeed;
    public int Atk=>atk;
    public int Def=>def;
    abstract public void Fire();
    public virtual void Wound(TankBase other)
    {
        nowHP -= other.atk - def;
    }
    public virtual void Dead()
    {
        Destroy(this.gameObject);
        Debug.Log("dead");
    } 
}
