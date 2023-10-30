using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieFollow : MonoBehaviour
{

    NavMeshAgent agent;
    [SerializeField] GameObject player;
   
    Animator anim;
    Vector3 startPosition;

    public bool isFollowing;

    

    void Start()
    {
        //isFollowing = true;
        anim = GetComponent<Animator>();
        startPosition = transform.position;
        agent= GetComponent<NavMeshAgent>();

        anim.SetBool("Idle", true);
    }

    void Update()
    {
        if(isFollowing)
        {
            if (anim.GetBool("Idle"))
            {
                anim.SetBool("Idle", false);
            }
            FollowPlayer();
        }

        if(!isFollowing && (transform.position - startPosition).magnitude < 0.5f)
        {
            anim.SetBool("Idle", true);
        }
    }

    void FollowPlayer()
    {
        Vector3 newTarget = player.transform.position;
        agent.SetDestination(newTarget);
    }
    public void Stunned()
    {
        Vector3 stopPos = agent.transform.position;
        agent.SetDestination(stopPos);
    }

    public void StopFollowing()
    {
        isFollowing= false;
        Vector3 newTarget = startPosition;
        agent.SetDestination(newTarget);
    }
}
