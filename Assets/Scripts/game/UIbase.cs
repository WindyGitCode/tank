using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbase : MonoBehaviour
{
    static private UIbase<T> instance;
    public UIbase<T> Instance => instance;
    void Awake()aaa
    {
        instance = this;
    }
}
