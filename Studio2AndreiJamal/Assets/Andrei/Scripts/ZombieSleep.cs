using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSleep : MonoBehaviour
{
    //[SerializeField] List<GameObject> zombiesToSleep;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Head")
        {
            Transform currentTransform = other.transform.parent;
            while (currentTransform.gameObject.name != "ZombieObject")
            {
                currentTransform = currentTransform.parent;
            }
            GameObject zombie = currentTransform.gameObject;
            zombie.GetComponent<ZombieFollow>().StopFollowing();
            
        }
    }
}
