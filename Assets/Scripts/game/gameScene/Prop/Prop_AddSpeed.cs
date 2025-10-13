using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop_AddSpeed : PropBase
{
    public PlayerTank playerTank;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DoWhileTrigger();
            playerTank.AddSpeed(4);
        }
    }
}
