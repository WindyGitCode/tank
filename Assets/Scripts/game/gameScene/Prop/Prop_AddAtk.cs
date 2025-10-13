using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop_AddAtk : PropBase
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DoWhileTrigger();
            PlayerTank player = other.GetComponent<PlayerTank>();
            if (player != null)
            {
                player.AddAtk(20);
            }
        }
    }
}
