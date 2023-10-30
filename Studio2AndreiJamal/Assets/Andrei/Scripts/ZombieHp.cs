using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHp : MonoBehaviour
{
    [SerializeField] int health;
   // [SerializeField] GameObject triggerToAwake;
   // [SerializeField] GameObject triggerToStop;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 2)
            Death();
    }

    public IEnumerator HeadShot()
    {
        health -= 51;

        if(health > 2)
        {
            this.gameObject.GetComponent<ZombieFollow>().isFollowing = false;
            anim.SetBool("Idle", true);
            this.gameObject.GetComponent<ZombieFollow>().Stunned();
            yield return new WaitForSeconds(2f);
            anim.SetBool("Idle", false);
            this.gameObject.GetComponent<ZombieFollow>().isFollowing=true;
        }
        else
        {
            yield return null;
        }
        

        print("Zombie hp now is " + health);
    }

    public void BodyShot()
    {
        health -= 31;
        print("Zombie hp now is " + health);
    }
    
    void Death()
    {
       // if(triggerToAwake != null)
       // {
       //     Destroy(triggerToAwake);
       // }
       // if(triggerToStop != null)
       // {
       //     Destroy(triggerToStop);
       // }
        
        Destroy(this.gameObject);
    }
}
