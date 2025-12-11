using UnityEngine;
using UnityEngine.Events;

public class DistributeurAlim2 : MonoBehaviour
{

    public delegate void CollisionAction();
    public static event CollisionAction OnCollision_alim;

   


    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision dist alim effectue ");
            //ajouter une variable a la place d'un evenement afin que seul un npc soit concerne et pas tous faire la meme chose pour ressourceManager variable deja cree ? 

            other.GetComponent<NpcMoveLeader>().need_decharge = true;
            OnCollision_alim();

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
