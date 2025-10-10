using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroy : MonoBehaviour
{

    void Update()
    {
        Destroy(gameObject, 3f);
    }
}
