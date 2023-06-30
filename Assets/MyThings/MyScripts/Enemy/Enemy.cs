using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private State currentState;
    public State startingState;
    [SerializeField] private IdleState idleState;
    [SerializeField] private PatrolState patrolState;
    public Player target;
    public NavMeshAgent agent;
    public Animator anim;
    public Vector3 targetDirection { get; private set; }
    public float viewableAngleFromTarget { get; private set; }
    //Seek player
    public float detectionRadius ;
    public LayerMask detectionLayer;
    public float minDetectionRadiusAngle;
    public float maxDetectionRadiusAngle;
    [SerializeField] private bool isPatrol;

    //Cooldown
    public float attackCoolDownTimer;

    //Attack
    public float disengageDistance;
    public float attackDistance = 2;

    //SEEK PLAYER
    public float patrolSphere;
    public LayerMask obstructionMask;

    private void Awake()
    {
        startingState = isPatrol ? patrolState : idleState;
        currentState = startingState;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        
    }

    private void HandleStateMachine()
    {
        State nextState;
        if(currentState != null)
        {
            nextState = currentState.Tick(this);
            if (nextState != null)
            {
                currentState = nextState;
            }
        }
    }


    private void Update()
    {
        if(attackCoolDownTimer > 0)
        {
            attackCoolDownTimer -= Time.deltaTime;
        }
        if(target != null)
        {
            targetDirection = target.transform.position - transform.position;
            viewableAngleFromTarget = Vector3.SignedAngle(targetDirection, transform.forward, Vector3.up);
        }

    }

    public float DistanceFromTarget()
    {
        return Vector3.Distance(this.transform.position, target.transform.position);
    }
    private void FixedUpdate()
    {
        HandleStateMachine();
    }

    void OnTriggerEnter(Collider other)
    {
        Door door = other.gameObject.GetComponent<Door>();
        if(door != null)
        {
            door.TryOpenDoor(this.transform.position);
        }
    }
}
