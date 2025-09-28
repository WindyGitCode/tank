using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : UIbase<SettingPanel>
{
    public CustomGUITexture bgr1;
    public CustomGUITexture bgr2;
    public CustomGUITexture bgr3;
    public CustomGUILabel title;
    public CustomGUIToggle togMusic;
    public CustomGUIToggle togSound;
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;
    public CustomGUIButton exit;
    void Start()
    {
        togMusic.changeValue += (value) =>DataMgr.Instance.IsMusicOpenSetting(value);
        togSound.changeValue += (value) =>DataMgr.Instance.IsSoundOpenSetting(value);
        sliderMusic.changeValue += (value) =>DataMgr.Instance.MusicNumSetting(value);
        sliderSound.changeValue += (value) =>DataMgr.Instance.SoundNumSetting(value);
        exit.clickEvent += () => 
        {
            SettingPanel.Instance.HideMe();
            BeginPanel.Instance.ShowMe();
        };
        SettingPanel.Instance.HideMe();
    }
    private void UpdateInfo()
    {
        MusicData data = DataMgr.Instance.musicData;
        togMusic.isSel = data.isMusicOpen;
        togSound.isSel = data.isSoundOpen;
        sliderMusic.nowValue=data.musicNum;
        sliderSound.nowValue = data.soundNum;
    }
    public override void ShowMe()
    {
        base.ShowMe();
        UpdateInfo();
    }
}
