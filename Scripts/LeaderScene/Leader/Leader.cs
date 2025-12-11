using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;




public class Leader : MonoBehaviour
{

    //list de tous les npc
    //public GameObject[] npcs;
    public List<GameObject> npcs = new List<GameObject>();

    //distributeur cible pour le npc choisis
    public Vector3 distTarget;

    public int max;

    public float[] distNpc = new float[100];

    public float min;
    public float min2;

    private void OnEnable()
    {
        RessourceManager2.Need_alim += SetToDistAlim;
        RessourceManager2.Need_eau += SetToDistEau;
        RessourceManager2.Need_bois += SetToDistBois;
    }

    private void OnDisable()
    {
        RessourceManager2.Need_alim -= SetToDistAlim;
        RessourceManager2.Need_eau -= SetToDistEau;
        RessourceManager2.Need_bois -= SetToDistBois;
    }

    private void SetToDistAlim()
    {
        distTarget = GameObject.Find("Dist_alim").transform.position;
    }

    private void SetToDistEau()
    {
        var obj = GameObject.Find("Dist_eau");

        if (obj == null)
        {
            Debug.LogError(" Dist_eau n’existe pas dans la scène !");
            return;
        }

        distTarget = obj.transform.position;
       // Debug.Log(" distTarget mis à jour vers : " + distTarget);
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


    private float RechercheMin(float[] tab, int nb)
    {

        float min = tab[0];
        for(int x = 0; x < nb ; x++){
                
            if (tab[x] < min) {
                min = tab[x];
            }
        }
        return min;
    }

    private int RechercheMinI(float[] tab, int nb)
    {

        float min = tab[0];
        int index = 0; 
        for (int x = 0; x < nb; x++)
        {

            if (tab[x] < min)
            {
                min = tab[x];
                index = x;
            }
        }
        return index;
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
        //npcs = GameObject.FindGameObjectsWithTag("Player");
        npcs = GameObject.FindGameObjectsWithTag("Player").ToList();

    }

    // Update is called once per frame
    void Update()
    {
        npcs.RemoveAll(npc => npc == null);

        //int nbNpcs = npcs.Length ;
        int nbNpcs = npcs.Count;

        for (int x = 0; x < nbNpcs; x++) {
            distNpc[x] = Mathf.Round(Vector3.Distance(distTarget, npcs[x].transform.position));
           // Debug.Log(" distance entre le npc : " + x + "et le dist target : "+distNpc[x]);
        }

        min2 = RechercheMin(distNpc,nbNpcs);
        int indexMin = RechercheMinI(distNpc, nbNpcs);

       // Debug.Log(" distance minimale trois valeurs : " + min);
       // Debug.Log(" distance minimale recherche sur tous le tableau : " + min2 );
       // Debug.Log(" index du npc avec la distance min  : " + indexMin);

        if (NeedToEau() == true)
        {
            npcs[indexMin].GetComponent<NpcMoveLeader>().need_eau = true;
            distTarget = npcs[indexMin].GetComponent<NpcMoveLeader>().transform.position;
        }

        else if (NeedToAlim() == true)
        {

            npcs[indexMin].GetComponent<NpcMoveLeader>().need_alim = true;
            distTarget = npcs[indexMin].GetComponent<NpcMoveLeader>().transform.position;
        }

        else if (NeedToBois() == true)
        {

            npcs[indexMin].GetComponent<NpcMoveLeader>().need_bois = true;
            distTarget = npcs[indexMin].GetComponent<NpcMoveLeader>().transform.position;

        }


    }

    
}

