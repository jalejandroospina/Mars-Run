using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] protected AudioClip shipFX;
    [SerializeField] protected AudioSource shipSource;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnShip()
    {
        int enemyIndex = Random.Range(0, enemyPrefab.Length);
        shipSource.PlayOneShot(shipFX);
        Instantiate(enemyPrefab[enemyIndex], transform.position, enemyPrefab[enemyIndex].transform.rotation);
        ShipsName(enemyIndex);
        
    }

    private void ShipsName( int enemyIndex)
    {
        for (int i = 0; i < enemyPrefab.Length; i++)
        {
            Debug.Log("Acercandose, nave : " + enemyPrefab[enemyIndex] );
        }
    }




}
