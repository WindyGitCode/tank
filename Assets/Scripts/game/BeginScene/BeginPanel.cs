using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BeginPanel : UIbase<BeginPanel>
{
    public CustomGUIButton btn_BeginGame;
    public CustomGUIButton btn_Setting;
    public CustomGUIButton btn_Rank;
    public CustomGUIButton btn_Exit;
    void Start()
    {
        btn_BeginGame.clickEvent += () =>
        {
            SceneManager.LoadScene("gameScene");
        };
        btn_Setting.clickEvent += () =>
        {
            BeginPanel.Instance.HideMe();
            SettingPanel.Instance.ShowMe();
        };
        btn_Rank.clickEvent += () =>
        {
            BeginPanel.Instance.HideMe();
            RankPanel.Instance.ShowMe();
        };
        btn_Exit.clickEvent += () =>
        {
            Environment.Exit(0);
        };
    }
}
