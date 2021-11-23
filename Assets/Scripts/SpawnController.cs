using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        int enemyIndex = Random.Range(0, enemyPrefab.Length);
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
