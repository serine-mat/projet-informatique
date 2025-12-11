using UnityEngine;

public class animation : MonoBehaviour
{

    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (GetComponent<Rigidbody>().linearVelocity.magnitude < 0) {
            animator.SetBool("moving", true);
        } */




    }
}
