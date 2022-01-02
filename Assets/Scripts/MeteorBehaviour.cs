using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehaviour : MonoBehaviour
{
    //[SerializeField] private float meteorSpeed = 5f;
    //[SerializeField] private float meteorRotation;
    [SerializeField] private ParticleSystem collisionDust;

    //private bool isGrounded = false;

    //private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {

        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //fall();
        //MeteorRotation();
    }

    /*
    private void fall()
    {
        rb.AddForce(0, meteorSpeed, 0, ForceMode.Force);
    }*/

    /*
    private void MeteorRotation()
    {
        if (!isGrounded) 
        {
            transform.Rotate(meteorRotation * Vector3.right, Space.Self);
        }
        
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            collisionDust.Play();
            StartCoroutine(DestroyMeteor());
            //isGrounded = true;
            //Destroy(gameObject);
        }
        
    }

    IEnumerator DestroyMeteor()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }


}
