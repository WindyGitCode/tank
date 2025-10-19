using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanel :UIbase<GamePanel>
{
    public float time = 0;
    public int score = 0;
    public CustomGUIButton exit;
    public CustomGUIButton setting;
    public CustomGUILabel labScore;
    public CustomGUILabel labTime;
    public CustomGUITexture hp;
    public PlayerTank player;
    private void Start()
    {
        exit.clickEvent += () =>
        {
            GamePanel.Instance.HideMe();
            ConfirmPanel.Instance.ShowMe();
        };
        setting.clickEvent += () =>
        {
            GamePanel.Instance.HideMe();
            SettingPanel.Instance.ShowMe();
        };
    }
    private void Update()
    {
        time += Time.deltaTime;
        ShowHP(player.MaxHP, player.NowHP);
        UpdateInfo();
    }
    public void AddScore(int score)
    {
        this.score += score;
        labScore.content.text = this.score.ToString();
    }
    public void ShowHP(float maxHP,float nowHP)
    {
        if (nowHP >= 0)
        {
            hp.guiPos.width = 300*(nowHP / maxHP);
        }
        else
        {
            hp.guiPos.width = 0;
        }
    }
    public void UpdateInfo()
    {
        //Ãæ°åÊý¾ÝÓ³Éä
        if (time > 60) 
        {
            labTime.content.text = $"{(int)(time / 60)}M{(int)(time % 60)}S";
        }
        else
        {
            labTime.content.text = $"{(int)(time % 60)}S";
        }
    }
}
