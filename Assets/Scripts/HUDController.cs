using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Text textAlienCoin;
    [SerializeField] private Text textTime;
    [SerializeField] private Text textDistance;
    [SerializeField] protected PlayerData myData;
    [SerializeField] private ItemManager mgItem;
    private float distance;
    private float time;



    // Start is called before the first frame update

   

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRewardsUI();
        Statistics();
    }

    void UpdateRewardsUI()
    {
        int[] rewardsCount = mgItem.GetRewardsQuantity();
        textAlienCoin.text =  rewardsCount[0].ToString();
    }

    void Statistics()
    {
        distance +=  myData.SpeedPlayer * Time.deltaTime ;
        textDistance.text = ((int)distance).ToString();

        time += Time.deltaTime;
        int minutes = (int)time / 60;
        int seconds = (int)time % 60;
        textTime.text = minutes.ToString() + ":" + seconds.ToString().PadLeft(2,'0');

    }
}
