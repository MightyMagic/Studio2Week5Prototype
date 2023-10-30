using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAwake : MonoBehaviour
{
    [SerializeField] List<GameObject> zombiesToAwake;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            foreach(GameObject zombie in zombiesToAwake)
            {
                if(zombie != null)
                    zombie.GetComponent<ZombieFollow>().isFollowing = true;
            }
        }
    }
}
