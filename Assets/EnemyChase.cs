using UnityEngine;
using UnityEngine.AI;

public class EnemyChase : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;
    private float repathThreshold = 0.5f;
    private Vector3 lastTargetPosition;
    public GameObject panel;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        lastTargetPosition = player.position;
    }

    void Update()
    {
        if (Vector3.Distance(lastTargetPosition, player.position) > repathThreshold)
        {
            agent.SetDestination(player.position);
            lastTargetPosition = player.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}