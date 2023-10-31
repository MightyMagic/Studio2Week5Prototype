using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBox : MonoBehaviour
{
    [SerializeField] int hp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            int rand = Random.Range(hp, hp);
            other.gameObject.GetComponent<PlayerHealth>().ChangeHealth(rand);
            if (this.gameObject.tag == "Zombie")
                return;
            else
                Destroy(this.gameObject);
        }
    }
}
