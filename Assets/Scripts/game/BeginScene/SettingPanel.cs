using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingPanel : UIbase<SettingPanel>
{
    public CustomGUIToggle togMusic;
    public CustomGUIToggle togSound;
    public CustomGUISlider sliderMusic;
    public CustomGUISlider sliderSound;
    public CustomGUIButton exit;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        togMusic.changeValue += (value) =>DataMgr.Instance.IsMusicOpenSetting(value);
        togSound.changeValue += (value) =>DataMgr.Instance.IsSoundOpenSetting(value);
        sliderMusic.changeValue += (value) =>DataMgr.Instance.MusicNumSetting(value);
        sliderSound.changeValue += (value) =>DataMgr.Instance.SoundNumSetting(value);
        exit.clickEvent += () => 
        {
            SettingPanel.Instance.HideMe();
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("beginScene"))
            {
                BeginPanel.Instance.ShowMe();
            }
            else
            {
                GamePanel.Instance.ShowMe();
            }
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
