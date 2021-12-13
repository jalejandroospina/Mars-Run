using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Stack inventoryOne;

    [SerializeField] private int[] rewardsQuantity = { 0 };

    //Events
    

    void Start()
    {
        inventoryOne = new Stack();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int[] GetRewardsQuantity()
    {
        return rewardsQuantity;
    }

    public void countRewards(GameObject reward)
    {
        RewardsController r = reward.GetComponent<RewardsController>();

        switch (r.GetReward())
        {
            case GameManager.Rewards.AlienCoin:
                rewardsQuantity[0]++;
                break;
            default:
                Debug.Log("No es una recompensa");
                break;
        }
    }

    public void AddinventoryOne(GameObject item)
    {
        inventoryOne.Push(item);

    }
    public GameObject GetInventoryOne()
    {
       return  inventoryOne.Pop() as GameObject;

    }



}
