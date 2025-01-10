using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float wanderinfRadius = 5f;
    [SerializeField] float reachingDistance = 1.5f;

    [SerializeField] float detectionDistance = 3f;

    NavMeshAgent agent;
    
    Vector3 homeOrigin;
    Vector3 wanderPosition;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        
        homeOrigin = transform.position;
        SelectWanderPosition();
    }

    private void Update()
    {
        Vector3 playerPosition = PlayerController.instance.transform.position;

        if (PlayerController.instance.gameObject.activeSelf && 
            (Vector3.Distance(playerPosition, transform.position) < detectionDistance))
        {
            agent.SetDestination(playerPosition);
        }
        else 
        {
            agent.SetDestination(wanderPosition);
            if (Vector3.Distance(transform.position, wanderPosition) < reachingDistance)
            { SelectWanderPosition(); }
        }
    }

    private void SelectWanderPosition()
    {
        Vector2 positionXY = Random.insideUnitCircle * wanderinfRadius;
        Vector3 positionXZ = new Vector3(positionXY.x, 0f, positionXY.y);
        wanderPosition = homeOrigin + positionXZ;
    }
}
