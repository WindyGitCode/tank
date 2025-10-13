using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public TankBase fatherTank;
    public GameObject explosionPrefab;
    private void Awake()
    {
        AudioSource audioSource = this.GetComponent<AudioSource>();
        audioSource.volume = DataMgr.Instance.musicData.soundNum;
        audioSource.mute = !DataMgr.Instance.musicData.isSoundOpen;
        audioSource.Play();
    }
    private void Start()
    {
        if (fatherTank.tag == "Enemy")
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
    private void Update()
    {
        transform.Translate(Vector3.forward*speed*Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy"&&fatherTank.tag=="Player" ||
            other.tag == "Player"&&fatherTank.tag=="Enemy" ||
            other.tag == "Wall")
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
