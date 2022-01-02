using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    [SerializeField] private GameObject meteorPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMeteor()
    {
        //int meteorIndex = Random.Range(0, meteorPrefab.Length);
        Instantiate(meteorPrefab, transform.position, meteorPrefab.transform.rotation);
        
    }


}
