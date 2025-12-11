/* using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class NpcMoveAuto: MonoBehaviour
{
    public Transform TargetI;
    private NavMeshAgent navMeshAgent;

    public Vector3 target;

    public bool canMove = false;

    public bool npcCharge;

    public bool need_eau;
    public bool need_bois;
    public bool need_alim;

    private void Awake() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        
    
    }

    private void OnEnable()
    {
        RessourceManager.Need_alim += SetToAlim;
        RessourceManager.Need_eau += SetToEau;
        RessourceManager.Need_bois += SetToBois;
       // NPCressources.OnDecharge += SetToManager;
      



    }

    private void OnDisable()
    {
        
        RessourceManager.Need_alim -= SetToAlim;
        RessourceManager.Need_eau -= SetToEau;
        RessourceManager.Need_bois -= SetToBois;
       // NPCressources.OnDecharge -= SetToManager;




    }
  

    private void SetToManager()
    {
        Debug.Log("direction manager"); 
        target = GameObject.Find("RessourceManager").transform.position;
        Debug.Log("target " + target);
    }


    private void SetToAlim() {

       // navMeshAgent.destination = GameObject.Find("Dist_alim").transform.position;
       // target = GameObject.Find("Dist_alim").transform.position;
       need_alim = true;


    }

    private void SetToEau()
    {

        // navMeshAgent.destination = GameObject.Find("Dist_eau").transform.position;
        // target = GameObject.Find("Dist_eau").transform.position;
        need_eau = true; 


    }

    private void SetToBois()
    {

       // navMeshAgent.destination = GameObject.Find("Dist_bois").transform.position;
       // target = GameObject.Find("Dist_bois").transform.position;
       need_bois = true;


    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // navMeshAgent.destination = GameObject.Find("RessourceManager").transform.position;
          //  navMeshAgent.SetDestination(target);

        if (Input.GetKeyUp(KeyCode.D)) {

            npcCharge = GameObject.Find("Rio").GetComponent<NPCressources>().estCharge;

            Debug.Log(" le npc est charge :  " + npcCharge);
        
        }

        npcCharge = GameObject.Find("Rio").GetComponent<NPCressources>().estCharge;

        if (npcCharge == true)
        {

            navMeshAgent.destination = GameObject.Find("RessourceManager").transform.position;

        }
        else {

            if (need_eau == true)
            {

                navMeshAgent.destination = GameObject.Find("Dist_eau").transform.position;
                need_eau = false;
            }
            else {

                if (need_alim == true)
                {
                    navMeshAgent.destination = GameObject.Find("Dist_alim").transform.position;
                    need_alim = false; 
                }
                else {

                    if (need_bois == true)
                    {
                        navMeshAgent.destination = GameObject.Find("Dist_bois").transform.position;
                        need_bois = false;
                    }
                    else {

                        Vector3 idle = new Vector3(-114, 0, -50);
                        navMeshAgent.destination = idle;

                    }
                    

                }

                    
            
            
            }






        }





        //Debug.Log("Agent position : " + transform.position + " ? Target : " + target + " | Remaining distance : " + navMeshAgent.remainingDistance);




    }


}
*/
