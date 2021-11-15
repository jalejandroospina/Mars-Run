using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speedPlayer = 5.0f;
    [SerializeField] private int coins = 0;
    [SerializeField] private int jumpForce = 0;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Run(Vector3.forward);
        Move();
        PlayerJump();
       // Jump();
    }
    private void Run (Vector3 direction)
    {
        transform.position =  transform.position += direction * speedPlayer * Time.deltaTime;
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow))
        {

            transform.position = transform.position += (new Vector3(-0.22f, 0f, 0) * speedPlayer);

        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            transform.position = transform.position += (new Vector3(0.22f, 0f, 0) * speedPlayer);
            
        }
       

    }
    private void PlayerJump()
    {
        //float jumpVertical = Input.GetAxisRaw("Jump");
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {

            transform.position = transform.position += (new Vector3(0f, 0.22f, 0) * speedPlayer);
            //rb.AddForce(0, 1 * jumpForce, 0);
        }
       
    }

    /*  private void Jump()
     {
         if (Input.GetKeyDown(KeyCode.W))
         {
             Debug.Log("Saltando");
             rb.AddForce(0, 1 * jumpForce, 0);

         }

     }
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            coins++;
            Debug.Log("número de modenas" + coins);
            
            
        }
    }


    







}
