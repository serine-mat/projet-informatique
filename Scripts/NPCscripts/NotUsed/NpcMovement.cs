using UnityEngine;

public class NpcMovement : MonoBehaviour
{

    // public variables
    public float zPosition = 5.0f;
    public float speed = 1.0f;
    public Vector3 target = new Vector3(0f, 0f, 0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move Dummy's position using the arrows 
        
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            transform.position = new Vector3(0,0,zPosition) + transform.position;
                }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position = new Vector3(0, 0, -zPosition) + transform.position;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(zPosition, 0, 0) + transform.position;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(-zPosition, 0, 0) + transform.position;
        }

        // makes the Dummy moves towards the target's position if T is pressed

        var step = speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.T)) {

            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }

        transform.position = Vector3.MoveTowards(transform.position, target, step);

    }
}
