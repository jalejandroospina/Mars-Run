using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDController : MonoBehaviour
{
    

    [SerializeField] private Text textAlienCoin;
    [SerializeField] private Text textJewels;
    [SerializeField] private Text textBoxes;
    [SerializeField] private Text textTime;
    [SerializeField] private Text textDistance;
    [SerializeField] protected PlayerData myData;
    [SerializeField] private ItemManager mgItem;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject GOPanel;
    [SerializeField] private GameObject finishPanel;
    [SerializeField] private PlayerController player;



    



    // Start is called before the first frame update

   
    
    void OnDestroy()
    {
     //PlayerController.OnDeath -= OnDeathHandler;
    }
    private void Awake()
    {
        PlayerController.OnDeath += OnDeathHandler;
        PlayerController.OnFinish += OnFinishHandler;
    }



    void Start()
    {

        
        
        mainPanel.SetActive(true);
        GOPanel.SetActive(false);
        finishPanel.SetActive(false);





    }

    // Update is called once per frame
    void Update()
    {
        UpdateCoinsUI();
        UpdateJewelsUI();
        UpdateBoxesUI();
        Statistics();
    }





    void UpdateCoinsUI()
    {
        int[] rewardsCount = mgItem.GetCoinsQuantity();
        textAlienCoin.text = rewardsCount[0].ToString();

    }
    void UpdateJewelsUI()
    {
        int[] rewardsCount = mgItem.GetJewelsQuantity();
        textJewels.text = rewardsCount[0].ToString();

    }
    void UpdateBoxesUI()
    {
        int[] rewardsCount = mgItem.GetBoxesQuantity();
        textBoxes.text = rewardsCount[0].ToString();

    }



    void Statistics()
    {
        
        textTime.text = player.GetTime();
        textDistance.text = player.GetDistance();

    }

    public void OnDeathHandler()
    {
        GOPanel.SetActive(true);
        mainPanel.SetActive(false);
        finishPanel.SetActive(false);
        PlayerController.OnDeath -= OnDeathHandler;
    }
    public void OnFinishHandler()
    {
        
        GOPanel.SetActive(false);
        mainPanel.SetActive(false);
        // finishPanel.SetActive(true);
        

        PlayerController.OnFinish -= OnFinishHandler;
    }



    public void OnClickPlayAgainButton()
     {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
     }
    public void OnClickMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnClickCreditsButton()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

    public void  GetFinish()
    {
        finishPanel.SetActive(true);

    }



}
