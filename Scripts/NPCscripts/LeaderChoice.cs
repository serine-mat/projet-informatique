/*
using UnityEngine;

public class LeaderChoice : MonoBehaviour
{

    //list de tous les npc
    public GameObject[] npcs;

    //distributeur cible pour le npc choisis
    public Vector3 distTarget;


    public float dist0;
    public float dist1;
    public float dist2;
    public float min;



    private void OnEnable()
    {
        RessourceManager.Need_alim += SetToDistAlim;
        RessourceManager.Need_eau += SetToDistEau;
        RessourceManager.Need_bois += SetToDistBois;





    }

    private void OnDisable()
    {

        RessourceManager.Need_alim -= SetToDistAlim;
        RessourceManager.Need_eau -= SetToDistEau;
        RessourceManager.Need_bois -= SetToDistBois;


    }



    private void SetToDistAlim()
    {

        distTarget = GameObject.Find("Dist_alim").transform.position;
    }

    private void SetToDistEau()
    {

        distTarget = GameObject.Find("Dist_eau").transform.position;
    }

    private void SetToDistBois()
    {

        distTarget = GameObject.Find("Dist_bois").transform.position;
    }


    private float RechercheMin(float x, float y, float z)
    {

        float min;
        if (x <= y)
        {
            min = x;
        }
        else min = y;

        if (z <= min)
        {
            min = z;
        }
        return min;


    }

    private bool NeedToAlim()
    {
        if (distTarget == GameObject.Find("Dist_alim").transform.position)
        {
            return true;
        }
        else return false;

    }

    private bool NeedToEau()
    {
        if (distTarget == GameObject.Find("Dist_eau").transform.position)
        {
            return true;
        }
        else return false;
    }

    private bool NeedToBois()
    {
        if (distTarget == GameObject.Find("Dist_bois").transform.position)
        {
            return true;
        }
        else return false;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        npcs = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {


        //parcours de tout les NPC disponible sur la scene

        foreach (object npc in npcs)
        {


            //calcul de la distance entre tous les npc et un dist target 


            // pour le Npc[0]
           dist0 = Vector3.Distance(distTarget, npcs[0].transform.position);
            Debug.Log("Distance pour npc0 : " + dist0);

            // pour le Npc[1]
             dist1 = Vector3.Distance(distTarget, npcs[1].transform.position);
            Debug.Log("Distance pour npc1 : " + dist1);

            // pour le Npc[2]
           dist2 = Vector3.Distance(distTarget, npcs[2].transform.position);
            Debug.Log("Distance pour npc2 : " + dist2);

             min = RechercheMin(dist0, dist1, dist2);
            Debug.Log("Distance minimale : " + min);


        }




            if (min == dist0)
            {

                if (NeedToEau() == true)
                {
                    npcs[0].GetComponent<NpcMoveLeader>().need_alim = true;
                }

                else if (NeedToAlim() == true)
                {

                    npcs[0].GetComponent<NpcMoveLeader>().need_bois = true;

                }

                else if (NeedToBois() == true)
                {

                    npcs[0].GetComponent<NpcMoveLeader>().need_eau = true;

                }

            }
            else if (min == dist1)
            {

                if (NeedToEau() == true)
                {
                    npcs[1].GetComponent<NpcMoveLeader>().need_alim = true;
                }

                else if (NeedToAlim() == true)
                {

                    npcs[1].GetComponent<NpcMoveLeader>().need_bois = true;

                }
                else if (NeedToBois() == true)
                {

                    npcs[1].GetComponent<NpcMoveLeader>().need_eau = true;

                }

            }
            else if (min == dist2)
            {

                if (NeedToEau() == true)
                {
                    npcs[2].GetComponent<NpcMoveLeader>().need_alim = true;
                }
                else if (NeedToAlim() == true)
                {

                    npcs[2].GetComponent<NpcMoveLeader>().need_bois = true;

                }
                else if (NeedToBois() == true)
                {

                    npcs[2].GetComponent<NpcMoveLeader>().need_eau = true;

                }
            }
        
    }
}
*/