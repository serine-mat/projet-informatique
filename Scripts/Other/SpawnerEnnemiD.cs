using UnityEngine;

public class SpawnerEnnemiD: MonoBehaviour
{
    public GameObject npcPrefab;
    public bool spawn;

    public GameObject enmDirection;

    private void OnEnable()
    {

        TimeManager.OnAttackHour += SpawnCheck;
    }

    private void OnDisable()
    {

        TimeManager.OnAttackHour -= SpawnCheck;
    }


    private void SpawnCheck() { 
    
            spawn = true;
       
           
    }

    // Update is called once per frame
    void Update()
    {
        if ( spawn == true && GameObject.Find("TimeManager").GetComponent<TimeManager>().nbJours > 1) {

            for (int x = 0; x < 3; x++)
            {

                enmDirection = Instantiate(npcPrefab, transform.position, Quaternion.identity);
                enmDirection.GetComponent<EnnemiEtat>().from = 0;
            }


            spawn = false;
        }

    }
}
