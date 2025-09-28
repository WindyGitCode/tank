using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMgr
{
    private static DataMgr instance = new DataMgr();
    public static DataMgr Instance { get => instance; }
    public MusicData musicData;
    public 
    private DataMgr() 
    {
        musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData),"musicData") as MusicData;
        if (!musicData.notFirstRun) 
        {
            musicData.isMusicOpen = true;
            musicData.isSoundOpen = true;
            musicData.notFirstRun = true;
            musicData.musicNum = 1;
            musicData.soundNum = 1;
            PlayerPrefsDataMgr.Instance.SaveData(musicData,"musicData");
        }
    }
    public void IsMusicOpenSetting(bool value)
    {
        musicData.isMusicOpen = value;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "musicData");
    }
    public void IsSoundOpenSetting(bool value)
    {
        musicData.isSoundOpen=value;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "musicData");
    }
    public void SoundNumSetting(float value)
    {
        musicData.soundNum=value;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "musicData");
    }
    public void MusicNumSetting(float value)
    {
        musicData.musicNum = value;
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "musicData");
    }
}
