using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmPanel : UIbase<ConfirmPanel>
{
    public CustomGUIButton exit;
    public CustomGUIButton yes;
    public CustomGUIButton no;
    private void Start()
    {
        exit.clickEvent += () =>
        {
            ConfirmPanel.Instance.HideMe();
            GamePanel.Instance.ShowMe();
        };
        yes.clickEvent += () =>
        {
            ConfirmPanel.Instance.HideMe();
            SceneManager.LoadScene("beginScene");
        };
        no.clickEvent += () =>
        {
            ConfirmPanel.Instance.HideMe();
            GamePanel.Instance.ShowMe();
        };
        ConfirmPanel.Instance.HideMe();
    }
}
