using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankPanel :UIbase<RankPanel>
{
    List<CustomGUILabel> nameList=new List<CustomGUILabel>();
    List<CustomGUILabel> scoreList=new List<CustomGUILabel>();
    List<CustomGUILabel> timeList = new List<CustomGUILabel>();
    public CustomGUIButton exit;
    void Start()
    {
        exit.clickEvent += () =>
        {
            RankPanel.Instance.HideMe();
            BeginPanel.Instance.ShowMe();
        };
        for (int i = 1; i <= 9; i++)
        {
            nameList.Add(this.transform.Find($"Name/name_{i}").GetComponent<CustomGUILabel>());
            scoreList.Add(this.transform.Find($"Score/score_{i}").GetComponent<CustomGUILabel>());
            timeList.Add(this.transform.Find($"Time/time_{i}").GetComponent<CustomGUILabel>());
        }
        RankPanel.Instance.HideMe();
    }
    public override void ShowMe()
    {
        base.ShowMe();
        UpdateInfo();
    }
    public void UpdateInfo()
    {
        string time="";
        for(int i = 0; i < DataMgr.Instance.rankData.rankInfos.Count; i++)
        {
            RankInfo info = DataMgr.Instance.rankData.rankInfos[i];
            time =$"{(int)info.time / 3600}Ê±{(int)info.time%3600/60}·Ö{(int)info.time%60}Ãë";
            nameList[i].content.text = info.name;
            scoreList[i].content.text = info.score.ToString();
            timeList[i].content.text = time;
        }
    }
}
