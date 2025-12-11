using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AttaqueEnnemi : MonoBehaviour
{


    public Vector3 cible;
    public float distance;
    private Collider enm;
    public int nbEnms;
    public List<GameObject> enms = new List<GameObject>();

    //tableau contenant la distance entre tous les enms et le npc
    public float[] distNpcE = new float[100];


    //variable qui contient la distance minimale entre tous les enms et notre npc
    private float distMinEnm;

    //variable qui contient l'index du enm le plus proche
    private int EnmProche;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ennemi"))
        {
            enm = other;
        }
    }


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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //enms = GameObject.FindGameObjectsWithTag("ennemi").ToList();
    }

    // Update is called once per frame
    void Update()
    {

        enms = GameObject.FindGameObjectsWithTag("ennemi").ToList();



        enms.RemoveAll(npc => npc == null);
         nbEnms = enms.Count;

        


        //recherche de l'ennemi le plus proche 

        //calcule la distance entre le et tous les enms de la scene -> le resultat est stocke dans le tableau distNpcE
        for (int x = 0; x < nbEnms; x++)
        {
            distNpcE[x] = Mathf.Round(Vector3.Distance(this.transform.position, enms[x].transform.position));
           
        }

        distMinEnm = RechercheMin(distNpcE, nbEnms); //Debug.Log(" distance minimale : " + distMinNpc);
        EnmProche = RechercheMinI(distNpcE, nbEnms); //Debug.Log("npc le pllus proche : " + NpcProche);



        if (GameObject.Find("TimeManager").GetComponent<TimeManager>().nbJours <= 2)
        {
           

            if (nbEnms != 0)
            {
                Debug.Log("on est dans le premier scenario ");
                cible = enms[0].transform.position;


            }
        }
        else { if (GameObject.Find("TimeManager").GetComponent<TimeManager>().nbJours == 3)
            {
                Debug.Log("on est dans le deuxieme scenario on attaque un ennemi aleatoire   ");
                
                //recupere le nombre max d'ennemis 
                int  index =    Random.Range(0, nbEnms+1);
                cible = enms[index].transform.position;
                
            }
            else {

                Debug.Log("on est dans le dernier scenario on attaque l'ennemi le plus proche  ");
                
                cible = enms[EnmProche].transform.position;

                
            }
          }
        


            //cible = this.GetComponent<EnnemiMove>().target;
            distance = Mathf.Round(Vector3.Distance(this.transform.position, cible));

        
            if (distance < 2)
            {

                enm.GetComponent<EnnemiEtat>().HP -= 0.05f;
            }

        


    }
}
