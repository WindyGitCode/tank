using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPoint : MonoBehaviour
{
    public PlayerTank playerTank;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            WinPanel.Instance.nowtime=GamePanel.Instance.time;
            playerTank.isGaming = false;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            GamePanel.Instance.HideMe();
            WinPanel.Instance.ShowMe();
        }
    }
}
