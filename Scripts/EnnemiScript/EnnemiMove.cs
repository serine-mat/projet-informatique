using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnnemiMove : MonoBehaviour
{


    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    //list contenant toous les npcs presents sur la scene 
    public List<GameObject> npcs = new List<GameObject>();

    //tableau contenant la distance entre tous les npcs et l'ennemi
    public float[] distNpcE = new float[10];

    //variable qui contient la distance minimale entre tous les npc et notre ennemi
    private float distMinNpc;

    //variable qui contient l'index du npc le plus proche
    private int NpcProche;

    //variable qui contient la distance entre notre ennemi et lle ressource manager
    private float distManager;

    //variable qui definit la position de la cible de l'ennemi
    public Vector3 target;

    //variable booleene qui est a vrai lorsque la cibre est un npc (utilise pour l'attaque )
    public bool targetIsNpc = true;

    // fonction qui prend en parametres un tableau de float et le nombre de floats de ce tableau et qui retourne le minimum  
    private float RechercheMin(float[] tab, int nb)
    {

        float min = tab[0];
        for (int x = 0; x < nb; x++)
        {

            if (tab[x] < min)
            {
                min = tab[x];
            }
        }
        return min;
    }

    // fonction qui prend en parametres un tableau de float et le nombre de flloats de ce tableau et qui retourne l'index du float minimum   
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









    private void Awake()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Start()
    {
        // on initialise le tableau
        npcs = GameObject.FindGameObjectsWithTag("Player").ToList();
    }

    
    void Update()
    {

        npcs = GameObject.FindGameObjectsWithTag("Player").ToList();

        //on enleve les npcs qui etait present mais qui on ete detruit 
        npcs.RemoveAll(npc => npc == null);

        //on compte le nombre de npcs
        int nbNpcs = npcs.Count;


        if (distNpcE.Length < nbNpcs)
        {
            distNpcE = new float[nbNpcs];
        }


        //calcule la distance entre l'ennemi et tous les npcs de la scene -> le resultat est stocke dans le tableau distNpc
        for (int x = 0; x < nbNpcs ; x++)
        {
            distNpcE[x] = Mathf.Round(Vector3.Distance(this.transform.position, npcs[x].transform.position));
            // Debug.Log(" distance entre le npc : " + x + "et l'ennemi : "+distNpcE[x]);
        }
        
        distMinNpc = RechercheMin(distNpcE, nbNpcs); //Debug.Log(" distance minimale : " + distMinNpc);
        NpcProche = RechercheMinI(distNpcE, nbNpcs); //Debug.Log("npc le pllus proche : " + NpcProche);

        distManager = Mathf.Round(Vector3.Distance(this.transform.position, GameObject.Find("RessourceManager").transform.position));
        //Debug.Log(" distance entre ennemi et ressource manager : " + distManager);


        //on compare quel cible est plus proche entre le ressource manager et le npc le plus proche 
        // si les deux distances sont egales alors  notre ennemi se dirige vers le npc
        
        if (distMinNpc <= distManager)
        {

            //Debug.Log(" notre cible est le npc : ");
            targetIsNpc = true;
            target = npcs[NpcProche].GetComponent<NpcMoveLeader>().transform.position;


        }
        else
        {
           // Debug.Log(" notre cible est le ressource manager : ");
            target = GameObject.Find("RessourceManager").transform.position;
            targetIsNpc = false;
        } 

       // target = npcs[NpcProche].GetComponent<NpcMoveLeader>().transform.position;

        navMeshAgent.destination = target;

        
        

    }



















}
