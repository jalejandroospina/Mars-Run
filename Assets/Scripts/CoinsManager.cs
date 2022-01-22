using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] coinsGroup;
    
    void Start()
    {
        StartCoroutine(SpawnCoinGroup());
    }
    IEnumerator SpawnCoinGroup()
    {
        yield return new WaitForSeconds(0.1f);
        coinsGroup[0].SetActive(true);

        yield return new WaitForSeconds(20f);
        coinsGroup[1].SetActive(true);
        

        yield return new WaitForSeconds(30f);
        Destroy(coinsGroup[0]);
        coinsGroup[2].SetActive(true);

        yield return new WaitForSeconds(35f);
        coinsGroup[3].SetActive(true);
        Destroy(coinsGroup[1]);

        yield return new WaitForSeconds(36f);
        coinsGroup[4].SetActive(true);
        Destroy(coinsGroup[2]);

        yield return new WaitForSeconds(36.2f);
        coinsGroup[5].SetActive(true);
        Destroy(coinsGroup[3]);

        yield return new WaitForSeconds(36.4f);
        coinsGroup[6].SetActive(true);
        Destroy(coinsGroup[4]);

        yield return new WaitForSeconds(36.6f);
        coinsGroup[7].SetActive(true);
       
        ////
        yield return new WaitForSeconds(40.8f);
        coinsGroup[8].SetActive(true);
       

        yield return new WaitForSeconds(41f);
        coinsGroup[9].SetActive(true);
       

        yield return new WaitForSeconds(200f);
         Destroy(coinsGroup[5]);
         yield return new WaitForSeconds(220f);
          Destroy(coinsGroup[6]); 
    }
}
