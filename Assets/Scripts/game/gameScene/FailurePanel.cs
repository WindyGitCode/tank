using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailurePanel : UIbase<FailurePanel>
{
    public CustomGUIButton btnRegame;
    public CustomGUIButton btnReturnMenu;
    void Start()
    {
        btnRegame.clickEvent += () => 
        {
            FailurePanel.Instance.HideMe();
            SceneManager.LoadScene("gameScene");
        };
        btnReturnMenu.clickEvent += () => 
        {
            SceneManager.LoadScene("beginScene"); 
        };
        FailurePanel.Instance.HideMe();
    }

}
