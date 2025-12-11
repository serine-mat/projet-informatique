using UnityEngine;

public class Events_hub : MonoBehaviour
{


    public delegate void ClickAction();
    public static event ClickAction OnClicked;

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) {
            if (OnClicked != null) {

                OnClicked();
          
            }
                
        }
    }

























}
