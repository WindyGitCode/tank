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
            
        };
        btn_Rank.clickEvent += () =>
        {
            
        };
        btn_Exit.clickEvent += () =>
        {
            Environment.Exit(0);
        };
    }
}
