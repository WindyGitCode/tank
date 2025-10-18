using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankMove : EnemyTank
{
    public GameObject[] moveTargetPos;
    public GameObject nowTarget;
    public float moveSpeed1;
    public GameObject tullet;
    public GameObject player;
    private void Start()
    {
        base.Start();
        nowTarget = moveTargetPos[0];
    }
    private void Update()
    {
        base.Update();
        if (Vector3.Distance(this.transform.position, nowTarget.transform.position)<0.5)
        {
            int i;
            i = Random.Range(0, moveTargetPos.Length);
            nowTarget=moveTargetPos[i];
        }
        transform.LookAt(nowTarget.transform);
        tullet.transform.LookAt(player.transform);
        transform.Translate(Vector3.forward*moveSpeed1*Time.deltaTime);
    }
}
