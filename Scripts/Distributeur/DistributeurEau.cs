using UnityEngine;
using UnityEngine.Events;

public class DistributeurEau : MonoBehaviour
{


    public delegate void CollisionAction();
    public static event CollisionAction OnCollision_eau;


    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player"))
        { Debug.Log("Collision dist eau effectue ");
            if (OnCollision_eau != null)
            {

                OnCollision_eau();

            }
            
        } 
            
       
    
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

}
