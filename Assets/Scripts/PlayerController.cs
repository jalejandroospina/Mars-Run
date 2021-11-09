using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speedPlayer = 5.0f;
    //[SerializeField] private float jumpHigh = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Run(Vector3.forward);
        Move();
        PlayerJump();
    }
    private void Run (Vector3 direction)
    {
        transform.position =  transform.position += direction * speedPlayer * Time.deltaTime;
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow))
        {

            transform.position = transform.position += (new Vector3(-0.27f, 0f, 0) * speedPlayer);

        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            transform.position = transform.position += (new Vector3(0.27f, 0f, 0) * speedPlayer);

        }

    }
    private void PlayerJump()
    {
        //float jumpVertical = Input.GetAxisRaw("Jump");
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {

            transform.position = transform.position += (new Vector3(0f, 0.23f, 0) * speedPlayer);

        }
       
    }




}
