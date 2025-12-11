using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class NpcMoveLeader : MonoBehaviour
{

    private NavMeshAgent navMeshAgent;

    public Vector3 leadpos;

    public float distancelead;

    public bool need_eau;
    public bool need_bois;
    public bool need_alim;
    public bool need_decharge;
    public bool effectueTache = false;

    public Vector3 cible;

    public int nbEnms;

    public List<GameObject> enms = new List<GameObject>();

    public bool eat;

    private void OnEnable()
    {

        TimeManager.OnEatNPCHour += eatCheck;
    }

    private void OnDisable()
    {

        TimeManager.OnEatNPCHour -= eatCheck;
    }

    private void eatCheck() {

        eat = true;

    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        leadpos = GameObject.Find("Leader").transform.position;

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        enms = GameObject.FindGameObjectsWithTag("ennemi").ToList();



        enms.RemoveAll(enm => enm == null);
        nbEnms = enms.Count;

        if (nbEnms != 0)
        {
            cible = enms[0].transform.position;
            navMeshAgent.destination = cible;


        }
        else { 
        if (need_decharge == true)
        {

            navMeshAgent.destination = GameObject.Find("RessourceManager").transform.position;

        }
        else
        {

            if (need_eau == true)
            {

                navMeshAgent.destination = GameObject.Find("Dist_eau").transform.position;
                effectueTache = true;
                need_eau = false;
            }
            else
            {

                if (need_alim == true)
                {
                    navMeshAgent.destination = GameObject.Find("Dist_alim").transform.position;
                    effectueTache = true;
                    need_alim = false;
                }
                else
                {

                    if (need_bois == true)
                    {
                        navMeshAgent.destination = GameObject.Find("Dist_bois").transform.position;
                        effectueTache = true;
                        need_bois = false;
                    }
                    else
                    {


                            //s'alimenter 
                            if (eat == true && GameObject.Find("RessourceManager").GetComponent<RessourceManager2>().total_alim > 0 )
                            {
                                navMeshAgent.destination = GameObject.Find("RessourceManager").transform.position;
                                //eat = false;
                            }
                            else { //vers le leader et s'arreter 

                                distancelead = Mathf.Round(Vector3.Distance(this.transform.position, leadpos));
                        if (distancelead > 2)
                        {
                            navMeshAgent.destination = leadpos;
                        }
                        else
                        {
                            Vector3 idle = this.transform.position;
                            navMeshAgent.destination = idle;
                        }
                            
                            
                            }



                                
                    }


                }




            }






        }
        
        
        }




        //npcCharge = this.GetComponent<NPCressources>().estCharge;







    }
}
