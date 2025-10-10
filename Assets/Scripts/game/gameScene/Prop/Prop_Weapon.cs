using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop_Weapon : PropBase
{
    public Weapon[] weaponList;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            DoWhileTrigger();
            int index = Random.Range(0, weaponList.Length);
            PlayerTank player= other.GetComponent<PlayerTank>();
            player.ChangeWeapon(weaponList[index]);
        }
    }
}
