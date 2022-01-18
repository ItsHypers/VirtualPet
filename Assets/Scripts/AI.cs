using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AI : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent agent;
    public enum AllStates { Random, Center, Kickball }
    public AllStates state;
    private NavMeshAgent nav;
    public float radius;
    public float timer = 5f;
    public bool destination;
    public float movement = 7f;
    public Vector3 lastSeen;
    [SerializeField] float destinationReachedTreshold;
    private Rigidbody rb;
    public Animator anim;
    private float movementDirection;
    public GameObject center;
    public GameObject player;
    private float distanceFromCenter;
    public float distanceLimit;
    public float CloseToBall;

    private GameObject closestBall;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>(); 
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        lastSeen = transform.position;
        nav.updateRotation = false;
        GameObject[] balls;
        balls = GameObject.FindGameObjectsWithTag("ball");
    }
    public GameObject FindClosestBall()
    {
        GameObject[] balls;
        balls = GameObject.FindGameObjectsWithTag("ball");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject ball in balls)
        {
            Vector3 diff = ball.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = ball;
                distance = curDistance;
            }
        }
        return closest;
    }
    private void Update()
    {
        OnAIStates();
        distanceFromCenter = Vector3.Distance(player.transform.position, center.transform.position);

        if (distanceFromCenter >= distanceLimit && state != AllStates.Kickball)
        {
            state = AllStates.Center;
        }
        if (Random.value <= 0.0005)
        {
            var closest = FindClosestBall();
            Debug.Log("0.5%");
            if (closest != null)
            {
                state = AllStates.Kickball;
                closestBall = closest;
                Debug.Log("closest");
            }
        }

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
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (closestBall != null)
        {
            timer = 8f;
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer += 5f;
                state = AllStates.Random;
                closestBall = null;
            }
            if (Vector3.Distance(closestBall.transform.position, player.transform.position) < CloseToBall)
            { 
                rb = closestBall.GetComponent<Rigidbody>();
                rb.AddForce(5, 0, 0, ForceMode.VelocityChange);
                state = AllStates.Random;
                closestBall = null;
            }
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
                nav.SetDestination(lastSeen);
            }   
        }

        if(state == AllStates.Center)
        {
            nav.SetDestination(center.transform.position);
            lastSeen = center.transform.position;
            movement = 7f;
            state = AllStates.Random;
            Debug.Log("Center");
        }

        if(state == AllStates.Kickball)
        {
            nav.SetDestination(closestBall.transform.position);
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
        Gizmos.DrawWireSphere(center.transform.position, distanceLimit);
        Gizmos.DrawWireSphere(player.transform.position, CloseToBall);
    }


#endif
}
