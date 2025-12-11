using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject npcPrefab;
    public bool spawn;
    public int nbNPC = 3;


    private void OnEnable()
    {

        TimeManager.OnNPCHour += SpawnCheck;
    }

    private void OnDisable()
    {

        TimeManager.OnNPCHour -= SpawnCheck;
    }


    private void SpawnCheck()
    {

        spawn = true;


    }



    void Start()
    {
        for (int i = 0; i < nbNPC; i++)
        {
            Instantiate(npcPrefab, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (spawn == true &&
                !(GameObject.Find("RessourceManager").GetComponent<RessourceManager2>().total_eau != 0
                && GameObject.Find("RessourceManager").GetComponent<RessourceManager2>().total_bois != 0
                && GameObject.Find("RessourceManager").GetComponent<RessourceManager2>().total_alim != 0)) {

            for (int x = 0; x < 2; x++)
            {

                Instantiate(npcPrefab, transform.position, Quaternion.identity);
                
            }

            spawn = false;
        }


    }
}
