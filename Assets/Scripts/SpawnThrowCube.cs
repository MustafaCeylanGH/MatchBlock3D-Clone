using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThrowCube : MonoBehaviour
{
    [SerializeField] private List<GameObject> cubes = new List<GameObject>();
    [SerializeField] private Transform spawnPoint;
    [SerializeField] public GameObject currentCube;
    void Awake()
    {
        SpawnThrowCubes();
    }

    public void SpawnThrowCubes()
    {
        currentCube=Instantiate(PickRandomCube(), spawnPoint.position, Quaternion.identity);       
    }

    private GameObject PickRandomCube()
    {
        GameObject randomcube = cubes[Random.Range(0, cubes.Count)];
        return randomcube;
    }
}
