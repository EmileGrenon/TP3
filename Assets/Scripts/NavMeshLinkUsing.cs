using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
using UnityEngine.AI;
using System.Security;

public class NavMeshLinkUsing : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Animator animator;
    private bool isRunning = false;

    private void Awake()
    {
        animator.SetBool("isJumping", false);    
    }

    private void Update()
    {
        if (agent.isOnOffMeshLink)
        {
            if (!isRunning)
            {
                isRunning = true;
                animator.SetBool("isWalking", false);
                animator.Play("Brute Jumping");
            }
            
            agent.speed = 3.2f;
        }
        else
        {
            animator.SetBool("isWalking", true);
            isRunning = false;
            agent.speed = 8;
        }
    }
}
