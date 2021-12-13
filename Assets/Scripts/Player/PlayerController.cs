using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    
    [SerializeField] private Vector3 resetPosition = (new Vector3 (0, 0, 0));
    [SerializeField] private GameObject coins;
    [SerializeField] private Animator animplayer;
    [SerializeField] private int difficulty;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] protected PlayerData myData;
    private Rigidbody rb;
    private ItemManager mgItem;
    private int jewels = 0;
    private int boxes = 0;

    //Events
    public static event Action OnDeath;
  
    
    //public static event Action<int> onCollect;


    void Start()
    {

        //SelectDificult();
        myData.SetSpeed(5);
        rb = GetComponent<Rigidbody>();
      mgItem = GetComponent<ItemManager>();
       // onCollect?.Invoke(coins);
    }

    // Update is called once per frame
    void Update()
    {
        Run(Vector3.forward);
        
        MoveSide();
        Jump();
        Slide();
        death(Vector3.zero);
      
    }
    private void Run (Vector3 direction)
    {
        
        transform.position =  transform.position += direction * myData.SpeedPlayer * Time.deltaTime;

        
    }

    public virtual void MoveSide()
    {
        if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow))
        {      
            if (!IsGrounded())
            {
                rb.AddForce(-92, 0, 0);
            }
            else
            {  
                rb.AddForce(-200,0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!IsGrounded())
            {
                rb.AddForce(92, 0, 0);
            }
            else
            {
                rb.AddForce(200, 0, 0);
            }
        }
    }
    

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {         
            animplayer.SetBool("IsJump", true);

            if (IsGrounded())
            {
                rb.AddForce(0,1* myData.PlayerJumpForce, 0);
            }  
        }
        else
        { 
          animplayer.SetBool("IsJump", false);   
        }
    }
    private void Slide()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            animplayer.SetBool("IsSlide", true);
        }
        else
        {
            animplayer.SetBool("IsSlide", false);
        }
    }

    private bool IsGrounded()
    {
        if(Physics.Raycast(transform.position, Vector3.down, 0.5f, groundLayer))
        {
            return true;
        }
        else return false;
         
    }
    

   


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
            GameObject coin = other.gameObject;
            coin.SetActive(false);
            mgItem.AddinventoryOne(coin);
            mgItem.GetInventoryOne();
            mgItem.countRewards(coin);
           
            
        }
        if (other.gameObject.CompareTag("jewel"))
        {
            GameObject jewel = other.gameObject;
            jewel.SetActive(false);
            mgItem.AddinventoryOne(jewel);
            jewels++;
            
            Debug.Log( "Numero de joyas"+""+jewels);


        }
        if (other.gameObject.CompareTag("box"))
        {
            GameObject box = other.gameObject;
            box.SetActive(false);
            boxes++;
            Debug.Log("Numero de cajas" + "" + boxes);
        }
       
    }
  
   
    private void OnCollisionEnter(Collision collision)
    {

        
        if (collision.gameObject.CompareTag("Enemy"))
        {

            myData.SetSpeed(0);
            animplayer.Play("Death");
            
            OnDeath?.Invoke();
           StartCoroutine(Restart());

        }
    }
    IEnumerator Restart()
    {
        
        yield return new WaitForSeconds(3f);
        
        SceneManager.LoadScene("GameOver");
    }

    private void death(Vector3 direction)
    {

        transform.position = transform.position += direction * myData.SpeedPlayer * Time.deltaTime;
    }
    /*
    private void SelectDificult()
    {
        switch (difficulty)
        {
            case 1:
                Debug.Log("Easy Mode");
                myData.SpeedPlayer + 3.0f;
                break;
            case 2:
                Debug.Log("Normal Mode");
                speedPlayer = 3.5f;
                break;
            case 3:
                Debug.Log("Hard Mode");
                speedPlayer = 4.0f;
                break;

            default:
                speedPlayer = 3.0f;
                break;
        }
    }

    
    public float GetSpeedPlayer()
    {
        return myData.SpeedPlayer;
    }
    public Vector3 GetPlayerPosition()
    {
        return resetPosition;
    }

    public bool GetPlayerEstate()
    {
        return death;
    }
    */




}
