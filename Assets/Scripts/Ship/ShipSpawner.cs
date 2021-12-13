using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class ShipSpawner : MonoBehaviour
{
    
    [SerializeField] private UnityEvent onSpawnShip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            onSpawnShip?.Invoke();
        }
    }
}
