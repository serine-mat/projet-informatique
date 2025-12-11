using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovements : MonoBehaviour
{

    public float Position = 1.0f;
    public float speed = 1.0f;


    public float rotationSpeed = 200f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // deplacement de la camera en avant , arriere , a gauche et a droite 
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.position = new Vector3(0, 0, Position) + transform.position;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position = new Vector3(0, 0, -Position) + transform.position;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(Position, 0, 0) + transform.position;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(-Position, 0, 0) + transform.position;
        }


        // rotation de la camera selon l'axe X  

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Rotate(Vector3.right * -rotationSpeed * Time.deltaTime);
        }

        // rotation de la camera selon l'axe X  

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }






    }
























}
