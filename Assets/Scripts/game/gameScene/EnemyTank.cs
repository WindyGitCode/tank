using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : TankBase
{
    public PlayerTank playerTank;
    public Weapon nowWeapon;
    protected float timer = 0;
    public float fireCD=1;
    public GameObject explosionPrefab;
    public Texture labHP;
    public Texture labHPBgr;
    protected Rect drawPos;
    public float headOffset = 1.8f; // 头部偏移量（根据敌人高度调整，比如2米）
    public float baseWidth = 50f; // 基础宽度（近距离时的大小）
    public float baseHeight = 6f; // 基础高度
    protected void Start()
    {
        playerTank=GameObject.Find("Player").GetComponent<PlayerTank>();
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
        GamePanel.Instance.AddScore(10);
        Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
    }
    private void OnGUI()
    {
        if(playerTank.isGaming==true)
        {
            // 1. 计算敌人头部的世界坐标（在敌人位置上方headOffset处）
            Vector3 headWorldPos = this.transform.position + new Vector3(0, headOffset, 0);

            // 2. 转换头部世界坐标到屏幕坐标（含距离z值）
            Vector3 screenPos = Camera.main.WorldToScreenPoint(headWorldPos);

            // 3. 若物体在摄像机后方（z<0），不显示血条
            if (screenPos.z < 0)
                return;

            // 4. 计算缩放比例（基于距离，近大远小）
            // 公式：缩放 = 基础缩放 / 距离（可调整系数0.1f控制缩放幅度）
            float scale = 1f / (screenPos.z * 0.1f);
            // 限制缩放范围（避免过近时太大，过远时太小）
            scale = Mathf.Clamp(scale, 0.3f, 2f);

            // 5. 计算血条在屏幕上的位置（GUI原点在左上角，需转换）
            // 血条中心点对齐头部屏幕坐标，因此x/y需要减去一半大小的偏移
            float x = screenPos.x - (baseWidth * scale) / 2;
            float y = Screen.height - screenPos.y - (baseHeight * scale) / 2;
            float widthBgr = baseWidth* scale;
            float width = baseWidth * ((float)nowHP / maxHP) * scale;
            float height = baseHeight * scale;
            Rect drawRectBgr = new Rect(x, y, widthBgr, height);
            Rect drawRect = new Rect(x, y, width, height);
            GUI.DrawTexture(drawRectBgr, labHPBgr);
            GUI.DrawTexture(drawRect, labHP);
        } 
    }

}
