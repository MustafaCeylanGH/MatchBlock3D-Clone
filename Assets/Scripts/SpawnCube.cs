using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCube : MonoBehaviour
{
    [SerializeField] private GameObject nextCube;    
    private Rigidbody rb;
    private float forcePower = 200.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();              
    }    
    public void SpawnNextCube()
    {
        if (nextCube!=null)
        {
            GameObject newcube = Instantiate(nextCube, transform.position, Quaternion.identity);
            newcube.GetComponent<SpawnCube>().CreateForce();                  
        }            
    }
    private void CreateForce()
    {
        rb.AddForce((Vector3.up + Vector3.forward) * forcePower);        
    }

    
}
