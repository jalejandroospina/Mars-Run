using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehaviour : MonoBehaviour
{
    
    [SerializeField] private ParticleSystem collisionDust;

    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            collisionDust.Play();
            StartCoroutine(DestroyMeteor());
            
        }
        
    }

    IEnumerator DestroyMeteor()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }


}
