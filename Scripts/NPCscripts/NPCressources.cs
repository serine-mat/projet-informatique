using UnityEngine;

public class NPCressources : MonoBehaviour
{

    public int ressources_eau = 0 ;
    public int ressources_bois = 0;
    public int ressources_alim = 0; 

    public bool estCharge = false; 

    private void OnEnable()
    {
        DistributeurEau2.OnCollision_eau += AddRessourcesEau;
        DistributeurBois2.OnCollision_bois += AddRessourcesBois;
        DistributeurAlim2.OnCollision_alim += AddRessourcesAlim;
        RessourceManager2.OnCollision_manager += RemoveRessources;


    }

    private void OnDisable()
    {
        DistributeurEau2.OnCollision_eau -= AddRessourcesEau;
        DistributeurBois2.OnCollision_bois -= AddRessourcesBois;
        DistributeurAlim2.OnCollision_alim -= AddRessourcesAlim;
        RessourceManager2.OnCollision_manager -= RemoveRessources;

    }

    private void AddRessourcesBois() {

        if (estCharge == false)
        { ressources_bois = ressources_bois + 15;
            estCharge = true;
            
           
        }

        //this.GetComponent<NpcMoveLeader>().need_decharge = true;
    }

    private void AddRessourcesEau()
    {

        if (estCharge == false)
        {
            ressources_eau = ressources_eau + 35;
            estCharge = true;
           

        }
        //this.GetComponent<NpcMoveLeader>().need_decharge = true;
    }

    private void AddRessourcesAlim()
    {

        if (estCharge == false)
        {
            ressources_alim = ressources_alim + 25;
            estCharge = true;
            
        }
       // this.GetComponent<NpcMoveLeader>().need_decharge = true;
    }

   

    private void RemoveRessources() { 

        ressources_alim = 0;
        ressources_bois = 0;
        ressources_eau = 0;
        estCharge = false;
        this.GetComponent<NpcMoveLeader>().need_decharge = false;


    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            Debug.Log(" NPC ressources eau  :  " + ressources_eau + "\n" +
                      " NPC ressources alim :   " + ressources_alim + "\n" +
                      " NPC ressources bois :  " + ressources_bois);

            


        }
    }
}
