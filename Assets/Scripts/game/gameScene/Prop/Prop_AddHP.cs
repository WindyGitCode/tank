using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop_AddHP : PropBase
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            DoWhileTrigger();
            PlayerTank player = other.gameObject.GetComponent<PlayerTank>();
            player.AddHP(30);
        }
    }
}
