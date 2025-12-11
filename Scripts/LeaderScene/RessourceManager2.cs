using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RessourceManager2 : MonoBehaviour
{

    public float total_eau = 25;
    public float total_alim = 25;
    public float total_bois = 25;

 

    public Slider alimBar;
    public Slider eauBar;
    public Slider boisBar;

    public void UseRessources()
    {

        if (total_eau > 0)
        {

            total_eau -= Time.deltaTime * 2.0f;
            if (total_eau < 0) { total_eau = 0; }
           

        }



        if (total_alim > 0)
        {

            total_alim -= Time.deltaTime * 1.5f;
            if (total_alim < 0) { total_alim = 0; }
            
        }

        

        if (total_bois > 0)
        {

            total_bois -= Time.deltaTime * 0.5f;
            if (total_bois < 0) { total_bois = 0; }
           
        }

        eauBar.value = total_eau;
        alimBar.value = total_alim;
        boisBar.value = total_bois;


    }

    public delegate void OnNeedBois();
    public static event OnNeedBois Need_bois;

    public delegate void OnNeedAlim();
    public static event OnNeedAlim Need_alim;

    public delegate void OnNeedEau();
    public static event OnNeedEau Need_eau;


    public delegate void CollisionAction();
    public static event CollisionAction OnCollision_manager;


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            //Debug.Log("Collision manager effectue ");

            total_eau += other.GetComponent<NPCressources>().ressources_eau;
            total_bois += other.GetComponent<NPCressources>().ressources_bois;
            total_alim += other.GetComponent<NPCressources>().ressources_alim;

            if (other.GetComponent<NpcMoveLeader>().eat == true) {
                other.GetComponent<NpcEtat>().HP = 100;
                other.GetComponent<NpcMoveLeader>().eat = false;
            }

            //this.GetComponent<NpcMoveLeader>().effectueTache = false;

            if (OnCollision_manager != null)
            {

                OnCollision_manager();


            }

        }

        if (other.CompareTag("ennemi"))
        {
            Debug.Log("les ressources ont ete pilles par les ennemis  ");

            
            total_eau -= 10; if (total_eau < 0) { total_eau = 0; }
            total_bois -= 10; if (total_bois < 0) { total_eau = 0; }
            total_alim -= 10; if (total_alim < 0) { total_alim = 0; }
            ;

        }



    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (total_alim == 0.0)
        {
            Need_alim();

        }


        if (total_eau == 0.0)
        {
            Need_eau();

        }


        if (total_bois == 0.0)
        {
            Need_bois();

        }


        UseRessources();

        if (Input.GetKeyUp(KeyCode.P))
        {
            Debug.Log(" le nombre de ressources en eau est  :  " + total_eau + "\n" +
                      " le nombre de ressources alimentaire est :   " + total_alim + "\n" +
                      " le nombre de ressources en bois est :  " + total_bois);


        }

    }
}
