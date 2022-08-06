using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollision : MonoBehaviour
{
    [SerializeField] private int value;
    private int ID;
    private SpawnCube spawnCube;    

    private void Awake()
    {
        ID = GetInstanceID();
        spawnCube = GetComponent<SpawnCube>();        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            if (value == other.gameObject.GetComponent<CubeCollision>().value)
            {
                if (ID > other.gameObject.GetComponent<CubeCollision>().ID)
                {
                    return;
                }
                Destroy(this.gameObject);
                Destroy(other.gameObject);
                spawnCube.SpawnNextCube();                
            }
        }
    }  
}
