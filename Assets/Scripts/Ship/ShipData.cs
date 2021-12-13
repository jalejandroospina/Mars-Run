using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Ship Data", menuName = "Ship Data")]

public class ShipData : ScriptableObject
{
    [SerializeField] private float shipSpeed = 6f;
    [SerializeField] private float timeLive = 9f;


    public float ShipSpeed
    {
        get
        {
            return shipSpeed;
        }
        
    }

    public float TimeLive
    {
        get
        {
            return timeLive;
        }

    }
}
