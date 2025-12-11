using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NpcEtat : MonoBehaviour
{


    public float HP = 100;
    public Slider healthbar;

    public float _total_eau = 100;
    public float _total_alim = 100;
    public float _total_bois = 100;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0) { HP = 0; }

        if (HP == 0) { Object.Destroy(this.gameObject); }

        healthbar.value = HP;

        if (this.GetComponent<NpcMoveLeader>().need_eau == true) {

            HP -= 0.01f;
        }

        if (this.GetComponent<NpcMoveLeader>().need_alim == true)
        {

            HP -= 0.01f;
        }

        if (this.GetComponent<NpcMoveLeader>().need_bois == true)
        {

            HP -= 0.01f;
        }


        _total_eau =  GameObject.Find("RessourceManager").GetComponent<RessourceManager2>().total_eau;
        _total_bois =   GameObject.Find("RessourceManager").GetComponent<RessourceManager2>().total_bois;
        _total_alim =   GameObject.Find("RessourceManager").GetComponent<RessourceManager2>().total_alim;

        /*
        if (_total_eau > 0 && _total_bois > 0 && _total_alim > 0) {

            if (HP >= 100) { HP = 100; }
            HP += 0.1f;

        } */

        

    }

    
}
