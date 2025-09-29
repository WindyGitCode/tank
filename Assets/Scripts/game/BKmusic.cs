using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BKmusic : MonoBehaviour
{
    private static BKmusic instance;
    public static BKmusic Instance=>instance;
    public AudioSource audioSource;
    private void Start()
    {
        instance = this;
        audioSource.mute=!DataMgr.Instance.musicData.isMusicOpen;
        audioSource.volume= DataMgr.Instance.musicData.musicNum;
    }
    public void ChangeMusicNum(float value)
    {
        audioSource.volume = value;
    }
    public void ChangeMusicIsOpen(bool value)
    {
        audioSource.mute = !value;
    }
}
