using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [SerializeField] int ammo;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            int rand = Random.Range(ammo, ammo);
            other.gameObject.GetComponent<PlayerShooting>().GainAmmo(rand);
            Destroy(this.gameObject);
        }
    }
}
