using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardsController : MonoBehaviour
{

    [SerializeField] private GameManager.Rewards rewards;

    void Start()
    {
        
    }

    public GameManager.Rewards GetReward()
    {
        return rewards;
    }
}
