using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerData", menuName = "Player Data")]

public class PlayerData : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float sideSpeed;
    [SerializeField] private float jumpForce;

   

    public float SpeedPlayer
    {
        get
        {
            return speed;
        }
    }

    public float SideSpeedPlayer
    {
        get
        {
            return sideSpeed;
        }
    }

    public float PlayerJumpForce
    {
        get
        {
            return jumpForce;
        }
    }
    public void SetSpeed(float newSpeed)
    {
       speed = newSpeed;
    }


}
