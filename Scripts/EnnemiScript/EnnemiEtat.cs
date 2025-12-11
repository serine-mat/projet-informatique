using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EnnemiEtat : MonoBehaviour
{


    public float HP = 100;
    public Slider healthbar;
    public int from;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (HP <= 0) { HP = 0; }

        if (HP == 0) {

            Object.Destroy(this.gameObject);  
            
            }

        

        healthbar.value = HP;
    }
}
