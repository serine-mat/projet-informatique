using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TimeManager : MonoBehaviour
{

    public static Action OnMinuteChanged;
    public static Action OnHourChanged;
    public static Action OnAttackHour;
    public static Action OnNPCHour;
    public static Action OnEatNPCHour;

    public static int Minute { get; private set; }

    public static int Hour { get; private set; }

    public float minuteToRealTime = 0.1f;
    private float timer;

    public int nbJours = 0;

    void Start()
    {
        Minute = 0;
        Hour = 8;
        timer = minuteToRealTime;
    }

    
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0) {

            Minute++; 
            OnMinuteChanged?.Invoke();

            if (Minute >= 60) 
            {
                Hour++;
                OnHourChanged?.Invoke();
                Minute = 0;
            }

            if (Hour >= 24)
            {
                //Hour++;
                //OnHourChanged?.Invoke();
                Hour = 0;
            }

            if (Hour == 0 && Minute == 00)
            {
                nbJours++;
                Debug.Log("il est minuit ! nbJours :  " + nbJours);
                OnAttackHour?.Invoke();
            }

            if (Hour == 15 && Minute == 00)
            {
                
               // Debug.Log("il est minuit ! nbJours :  " + nbJours);
                OnNPCHour?.Invoke();
            }

            if (Hour == 10 && Minute == 00)
            {

                // Debug.Log("il est minuit ! nbJours :  " + nbJours);
                OnEatNPCHour?.Invoke();
            }


            timer = minuteToRealTime;
        




        }

       
    }
}
