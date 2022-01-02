using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Animator animplayer;
    [SerializeField] private int difficulty;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] protected PlayerData myData;
    /*  [SerializeField] protected AudioClip jump;
      [SerializeField] protected AudioSource run;
      [SerializeField] protected AudioClip crash;
      [SerializeField] protected AudioClip slide;
      [SerializeField] protected AudioClip coinfx;
      [SerializeField] protected AudioClip jewelfx;
      [SerializeField] protected AudioClip boxfx;
      */
    [SerializeField] protected SoundManager soundManager;
    private Rigidbody rb;
    private ItemManager mgItem;

    private float distance;
    private float time;
    private string score;
    private string tm;
    private bool timeOn;


    //Events
    public static event Action OnDeath;
    

  


    void Start()
    {


        
       
        myData.SetSpeed(6);  // Corregir seteo de variable !!!!!!!!
        rb = GetComponent<Rigidbody>();
        mgItem = GetComponent<ItemManager>();
        timeOn = true;


    }

    // Update is called once per frame
    void Update()
    {
        Run(Vector3.forward);
        MoveSide();
        Jump();
        Slide();
        Statistics();



    }
    private void Run (Vector3 direction)
    {
        Debug.Log(myData.SpeedPlayer);
        
        transform.position =  transform.position += direction * myData.SpeedPlayer * Time.deltaTime;
        

    }

    public virtual void MoveSide()
    {
        if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow))
        {      
            if (!IsGrounded())
            {
               // rb.AddForce(-90, 0, 0);
            }
            else
            {  
                rb.AddForce(-180,0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (!IsGrounded())
            {
               // rb.AddForce(90, 0, 0);
            }
            else
            {
                rb.AddForce(180, 0, 0);
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
                rb.AddForce(0, 1* myData.PlayerJumpForce, 0);
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
           // GetComponent<AudioSource>().PlayOneShot(slide);
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
           // GetComponent<AudioSource>().PlayOneShot(coinfx);
            GameObject coin = other.gameObject;
            mgItem.AddinventoryOne(coin);
            mgItem.GetInventoryOne();
            mgItem.countRewards(coin);
            Destroy(other.gameObject);
           
            
        }
        if (other.gameObject.CompareTag("jewel"))
        {
           // GetComponent<AudioSource>().PlayOneShot(jewelfx);
            GameObject jewel = other.gameObject;
            mgItem.AddinventoryOne(jewel);
            mgItem.GetInventoryOne();
            mgItem.countRewards(jewel);
            Destroy(other.gameObject);

        }

        if (other.gameObject.CompareTag("box"))
        {
           // GetComponent<AudioSource>().PlayOneShot(boxfx);
            GameObject box = other.gameObject;
            mgItem.AddinventoryOne(box);
            mgItem.GetInventoryOne();
            mgItem.countRewards(box);
            Destroy(other.gameObject);

        }

        
        if (other.gameObject.CompareTag("jump"))
        {
            animplayer.SetBool("IsJump", true);
            rb.AddForce(0, 1 * myData.PlayerJumpForce, 0);
        }
        if (other.gameObject.CompareTag("jumpx3"))
        {
            animplayer.SetBool("IsJump", true);
            rb.AddForce(0, 2 * myData.PlayerJumpForce, 0);
        }
        if (other.gameObject.CompareTag("key"))
        {
            
            Destroy(other.gameObject);

        }
        if (other.gameObject.CompareTag("Speed1"))
        { 
            myData.SetSpeed(7);
        }
        if (other.gameObject.CompareTag("Speed2"))
        {
            myData.SetSpeed(8);
        }
        if (other.gameObject.CompareTag("Speed3"))
        {
            myData.SetSpeed(9);
        }
        
        if (other.gameObject.CompareTag("finish"))
        {
            SceneManager.LoadScene("CreditsMenu");
        }
    }
  
   
    private void OnCollisionEnter(Collision collision)
    {

        
        if (collision.gameObject.CompareTag("Enemy"))
        {
         //   GetComponent<AudioSource>().PlayOneShot(crash);
            timeOn = false;
            myData.SetSpeed(0);
            animplayer.Play("Death");

            
            StartCoroutine(Restart());
            

        }
    }
    IEnumerator Restart()
    {
        
        yield return new WaitForSeconds(1f);
        OnDeath?.Invoke();
       

    }
    void Statistics()
    {
        distance += myData.SpeedPlayer * Time.deltaTime;
        score = ((int)distance).ToString();

        if (timeOn == true)
        {
            time += Time.deltaTime;
        }

        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        tm = minutes.ToString() + ":" + seconds.ToString().PadLeft(2, '0');

    }
    public  string  GetDistance()
    {
        return score;
           
    }
    public  string GetTime()
    {
        return tm;

    }











}
