using UnityEngine;
using UnityEngine.AI;

public class NPCmoveWithEvents : MonoBehaviour
{

    public Transform Target;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
       

    }
    private void OnEnable()
    {
        Events_hub.OnClicked += moveNPC;
        
    }

    private void OnDisable()
    {
        Events_hub.OnClicked -= moveNPC;
    }

    void moveNPC() {
        navMeshAgent.destination = Target.position;

    }

  

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
