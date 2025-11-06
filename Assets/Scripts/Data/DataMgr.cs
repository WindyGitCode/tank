using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataMgr
{
    private static DataMgr instance = new DataMgr();
    public static DataMgr Instance=>instance;
    public MusicData musicData;
    public RankData rankData;
    private DataMgr() 
    {
        musicData = PlayerPrefsDataMgr.Instance.LoadData(typeof(MusicData),"musicData") as MusicData;
        rankData=PlayerPrefsDataMgr.Instance.LoadData(typeof(RankData),"rankData") as RankData; 
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
        BKmusic.Instance.ChangeMusicIsOpen(value);
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
        BKmusic.Instance.ChangeMusicNum(value);
        PlayerPrefsDataMgr.Instance.SaveData(musicData, "musicData");
    }
    public void AddRankInfo(string name,int score,float time)
    {
        RankInfo rank=new RankInfo();
        rank.time = time;
        rank.name = name;
        rank.score = score;
        rankData.rankInfos.Add(rank);
        rankData.rankInfos.Sort((a, b) =>a.time > b.time ? 1 : -1);
        for(int i = rankData.rankInfos.Count; i > 9; i--)
        {
            rankData.rankInfos.RemoveAt(i-1);
        }
        PlayerPrefsDataMgr.Instance.SaveData(rankData, "rankData");
    }
}
