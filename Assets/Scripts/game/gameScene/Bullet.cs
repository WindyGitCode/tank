using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public GameObject explosionPrefab;
    private void Awake()
    {
        AudioSource audioSource = this.GetComponent<AudioSource>();
        audioSource.volume = DataMgr.Instance.musicData.soundNum;
        audioSource.mute = !DataMgr.Instance.musicData.isSoundOpen;
        audioSource.Play();
    }
    private void Update()
    {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyTank" || other.tag == "Wall")
        {
            Destroy(this.gameObject);
            GameObject pre=Instantiate(explosionPrefab,this.transform.position, this.transform.rotation);
            AudioSource sound = pre.GetComponent<AudioSource>();
            sound.volume =DataMgr.Instance.musicData.soundNum;
            sound.mute = !DataMgr.Instance.musicData.isSoundOpen;
            sound.Play();
        }
    }
}
