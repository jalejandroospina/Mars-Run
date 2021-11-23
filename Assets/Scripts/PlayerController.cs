using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speedPlayer = 3.0f;
    [SerializeField] private bool death = false;
    [SerializeField] private float jumpForce = 0.8f;
    [SerializeField] private Vector3 resetPosition = (new Vector3 (0, 0, 0));
    [SerializeField] private GameObject coins;
    [SerializeField]  private Animator animplayer;
    [SerializeField] private float sideSpeed = 3.0f;
    [SerializeField] private int difficulty;
    private ItemManager mgItem;
    private int jewels = 0;
    private int boxes = 0;





    void Start()
    {
      SpawnCoins();
      SelectDificult();
      mgItem = GetComponent<ItemManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Run(Vector3.forward);
        Move();
        PlayerJump();
        

     /* if (death)
        {
            resetTime -= Time.deltaTime;
        }
     */
        if (death)   //&& Input.GetKeyDown(KeyCode.Space)
        {
            speedPlayer = 3.0f;
            SpawnCoins();
            death = false;
            GameManager.instance.scoreInstance = 0;
           // score = 0;

            
        }

    }
    private void Run (Vector3 direction)
    {
        transform.position =  transform.position += direction * speedPlayer * Time.deltaTime;
    }

    private void Move()
    {
        if (Input.GetKeyDown(KeyCode.A)|| Input.GetKeyDown(KeyCode.LeftArrow))
        {

            transform.position = transform.position += (new Vector3(-0.38f, 0f, 0) * sideSpeed);

        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            transform.position = transform.position += (new Vector3(0.38f, 0f, 0) * sideSpeed);

        }

    }
    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animplayer.SetBool("IsRun", false);  
            animplayer.SetBool("IsJump", true);
            
            transform.position = transform.position += (new Vector3 (0f, 1f, 0) *jumpForce);

        }
        else
        {
            animplayer.SetBool("IsRun", true);
            animplayer.SetBool("IsJump", false);
            
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coin"))
        {
           Destroy(other.gameObject);
           GameManager.instance.GetScore();
           GameManager.instance.addScore();
           Debug.Log(GameManager.instance.GetScore());
            //score += 1;
            //Debug.Log(score);
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
            transform.position = resetPosition;
            speedPlayer = 0f;
            death = true;
           

        }

    }
    private void SelectDificult()
    {
        switch (difficulty)
        {
            case 1:
                Debug.Log("Easy Mode");
                speedPlayer =3.0f;
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

   private void SpawnCoins()
    {
        Instantiate(coins.gameObject);
    }
   
   


}
