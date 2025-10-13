using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootble : MonoBehaviour
{
    public GameObject eff;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bullet"))
        {
            Destroy(this.gameObject);
            Instantiate(eff, this.transform.position, this.transform.rotation);
        }
    }
}
