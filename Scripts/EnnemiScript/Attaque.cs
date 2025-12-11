using UnityEngine;

public class Attaque : MonoBehaviour
{

    public Vector3 cible;

    float distance;

    private Collider npc;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            npc = other;
        }
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        cible = this.GetComponent<EnnemiMove>().target;

       // Debug.Log("la cible pour la nouvelle attaque se trouve en : " + cible);


        distance = Mathf.Round(Vector3.Distance(this.transform.position, cible));

       // Debug.Log("distance entre l'ennemi est la cible est : " + distance);


        if (this.GetComponent<EnnemiMove>().targetIsNpc == true)
        {
           // Debug.Log(" la cible de la nouvelle attaque est un npc  ! ");

            if (distance < 2) { 

               // Debug.Log("la cible est a portee ! ");
                 npc.GetComponent<NpcEtat>().HP -= 0.05f;
            }

        }


    }
}
