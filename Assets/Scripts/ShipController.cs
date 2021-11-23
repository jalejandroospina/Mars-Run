using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private float shipSpeed = 6f;
    [SerializeField] private float timeLive = 9f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       moveForward(Vector3.forward);
       autoDestruction();
    }
    private void moveForward(Vector3 direction)
    {
        transform.Translate(shipSpeed * direction * Time.deltaTime);
    }

  private void autoDestruction()
    {
        timeLive -= Time.deltaTime;
        if(timeLive <= 0f)
        {
            Destroy(gameObject);
        }
    }
    
}

