using UnityEngine;
using UnityEngine.AI;

public class SheepWalking : MonoBehaviour
{
    public Transform[] walkPoints; // Points jahan sheep chalegi
    private int currentIndex = 0;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoToNextPoint();

        
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }
    }

    void GoToNextPoint()
    {
        if (walkPoints.Length == 0)
            return;

        agent.destination = walkPoints[currentIndex].position;

        currentIndex = (currentIndex + 1) % walkPoints.Length;
    }
}
