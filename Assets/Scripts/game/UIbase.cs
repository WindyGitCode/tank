using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIbase<T> : MonoBehaviour where T : class
{
    static private T instance;
    static public T Instance => instance;
    void Awake()
    {
        instance = this as T;
    }
    public void ShowMe()
    {
        this.gameObject.SetActive(true);
    }
    public void HideMe()
    {
        this .gameObject.SetActive(false);
    }
}
