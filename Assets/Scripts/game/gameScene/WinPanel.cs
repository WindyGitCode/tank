using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : UIbase<WinPanel>
{
    public CustomGUIButton comfirm;
    public CustomGUIInput input;
    public float nowtime;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        comfirm.clickEvent += () =>
        {
            if (input.content.text == "")
            {
                input.content.text = "…Ò√ÿÕÊº“";
            }
            DataMgr.Instance.AddRankInfo(input.content.text,GamePanel.Instance.score, nowtime);
            SceneManager.LoadScene("beginScene");
        };
        WinPanel.Instance.HideMe();
    }
}
