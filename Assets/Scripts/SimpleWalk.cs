using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleWalk : MonoBehaviour
{
    public float moveSpeed;
    private Animator anim;
    private int _velocityID;
    //[SerializeField] private float _mouseSensitivity;

    private void Start() // Caching Component references in Start
    {
        anim = GetComponent<Animator>();
        _velocityID = Animator.StringToHash("Velocity");
    }

    void Update() // Moving with User Input in every frame
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.right);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.left);
        }

        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.forward);
            
            if (Input.GetKeyDown(KeyCode.LeftArrow)) // Rotation with left and right taps only while moving
            {
                transform.Rotate(0f, -90, 0f, Space.World);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.Rotate(0f, 90, 0f, Space.World);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(moveSpeed * Time.deltaTime * Vector3.back);

            if (Input.GetKeyDown(KeyCode.LeftArrow)) // Rotation with left and right taps only while moving
            {
                transform.Rotate(0f, -90, 0f, Space.World);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.Rotate(0f, 90, 0f, Space.World);
            }
        }

        //transform.Translate(horizontal * moveSpeed * Time.deltaTime, 0, vertical * moveSpeed * Time.deltaTime);

        if (horizontal != 0 | vertical != 0) // Setting Animator parameters using User Input
        {
            anim.SetFloat(_velocityID, 1);
        }

        else //Matches animation with movement
        {
            anim.SetFloat(_velocityID, 0);
        }

    }

}
