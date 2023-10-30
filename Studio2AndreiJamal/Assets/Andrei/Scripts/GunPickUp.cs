using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    [SerializeField] GameObject gunObject;
    [SerializeField] Transform gunTransform;

    GameObject player;

    bool playerNearGun = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            player = other.gameObject;  

            playerNearGun= true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerNearGun = false;    
        }
    }

    private void Update()
    {
        if(playerNearGun && Input.GetKeyDown(KeyCode.Space)) 
        { 
            PickUpGun();
           // Destroy(this);
        }
    }

    void PickUpGun()
    { 
        gunObject.transform.localPosition = gunTransform.position;
        gunObject.transform.rotation = player.transform.rotation;
        gunObject.transform.parent = player.transform;

        player.GetComponent<PlayerShooting>().GunAcquired();
    }
}
