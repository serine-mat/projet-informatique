using UnityEngine;
using UnityEngine.Events;

public class DistributeurAlim : MonoBehaviour
{

    public delegate void CollisionAction();
    public static event CollisionAction OnCollision_alim;

   


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision dist alim effectue ");
            if (OnCollision_alim != null)
            {

                OnCollision_alim();

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
