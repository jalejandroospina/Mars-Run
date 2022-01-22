using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    [SerializeField] private GameObject meteorPrefab;

    [SerializeField] protected AudioClip asteroidFX;
    [SerializeField] protected AudioSource asteroidSource;

    public void SpawnMeteor()
    {
        
        Instantiate(meteorPrefab, transform.position, meteorPrefab.transform.rotation);
        asteroidSource.PlayOneShot(asteroidFX);
    }


}
