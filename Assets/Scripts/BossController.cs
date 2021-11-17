using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float distanceRay = 3f;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject bossSpawner;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        RayCastBoss();
    }
    private void RayCastBoss()
    {
        RaycastHit hit;


        if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.right),out hit , distanceRay)) 
        {
            if (hit.transform.tag == "Player")
            {
                Instantiate(boss, bossSpawner.transform.position, boss.transform.rotation);
            }
        }


    }
    private void OnDrawGizmos()
    {
        Vector3 direction = bossSpawner.transform.TransformDirection(Vector3.right) * distanceRay;
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, direction);
    }
}
