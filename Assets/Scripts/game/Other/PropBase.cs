using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropBase : MonoBehaviour
{
    protected GameObject getEff;
    AudioSource audioSource;
    private void Start()
    {
        getEff = Resources.Load<GameObject>("Prefabs/CltEffectStar");
    }
    protected void DoWhileTrigger()
    {
        if (getEff != null)
        {
            GameObject eff = Instantiate(getEff, this.transform.position, this.transform.rotation);
            audioSource = eff.gameObject.GetComponent<AudioSource>();
            Destroy(eff, 1f);
        }
        audioSource.volume = DataMgr.Instance.musicData.soundNum;
        audioSource.mute = !DataMgr.Instance.musicData.isSoundOpen;
        audioSource.Play();
        Destroy(this.gameObject);
    }
}
