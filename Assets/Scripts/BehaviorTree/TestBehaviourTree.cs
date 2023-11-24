using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class TestBehaviourTree : MonoBehaviour
{
    [SerializeField] Transform[] patrolDestinations;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float sprintSpeed;

    Node rootBT;

    private void Awake()
    {
        Vector3[] destinations = patrolDestinations.Select(t => t.position).ToArray();

        TaskBT[] tasks0 = new TaskBT[]
        {
            new Patrol(destinations, agent),
        };
        TaskBT[] tasks3 = new TaskBT[]
        {
            new SprintPatrol(sprintSpeed, agent)
        };

        TaskNode patrolNode = new TaskNode("patrolNode1", tasks0);
        TaskNode sprintNode = new TaskNode("sprintNode1", tasks3);
        Node seq1 = new Sequence("seq1", new[] {patrolNode, sprintNode });

        rootBT = seq1;
    }

    void Update()
    {
        rootBT.Evaluate();
    }
}
