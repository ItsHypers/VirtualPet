using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    public enum AllStates { Random }
    public AllStates state;
    private NavMeshAgent nav;
    public float radius;
    public float timer = 5f;
    private bool destination;
    public float movement = 7f;
    public Vector3 lastSeen;
    [SerializeField] float destinationReachedTreshold;
    private Rigidbody rb;
    public Animator anim;
    private float movementDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>(); 
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        lastSeen = transform.position;
    }

    private void Update()
    {
        OnAIStates();
        if (nav.velocity != Vector3.zero)
            anim.SetBool("moving", true);
        else
            anim.SetBool("moving", false);
        if(lastSeen.x == transform.position.x && lastSeen.z == transform.position.z)
        {
            destination = true;
        }
        else
        {
            destination = false;
            movementDirection = lastSeen.x - transform.position.x;
        }
        if (destination)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void OnAIStates()
    {
        timer -= Time.deltaTime;
        movement -= Time.deltaTime;
        nav.SetDestination(lastSeen);
        nav.updateRotation = false;
        if (state == AllStates.Random)
        {
            if (timer <= 0f)
            {
                timer += 5f;
            }
            if (movement <= 0f)
            {
                movement = 7f;
                lastSeen = RandomNavmeshLocation(5f);
            }   
        }
    }
    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += lastSeen;
        randomDirection.y = 0;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

#if UNITY_EDITOR

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

#endif
}
