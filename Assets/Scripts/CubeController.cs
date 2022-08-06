using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private SpawnThrowCube spawnThrowCube;
    private float swipeSpeed = 0.5f;
    private float lastFingerPositionX;
    private float moveX;
    private float moveXMaxValue = 1.0f;
    private float forcePower = 1000.0f;
    private float delayTime =0.5f;
    private void Awake()
    {
        spawnThrowCube = FindObjectOfType<SpawnThrowCube>();
    }
    private void Update()
    {
        if (spawnThrowCube.currentCube!=null)
        {
            InputControl();
            SwipeCube();
        }        
    }

    private void InputControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveX = Input.mousePosition.x - lastFingerPositionX;
            lastFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ThrowForce();
            moveX = 0;
            StartCoroutine(SpawnDelay());
        }
    }

    private void SwipeCube()
    {
        moveX = moveX * swipeSpeed * Time.deltaTime;
        moveX = Mathf.Clamp(moveX, -moveXMaxValue, moveXMaxValue);

        spawnThrowCube.currentCube.transform.Translate(moveX, 0, 0);
    }

    private void ThrowForce()
    {
        spawnThrowCube.currentCube.GetComponent<Rigidbody>().AddForce(Vector3.forward * forcePower);
    }

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(delayTime);
        spawnThrowCube.SpawnThrowCubes();
    }
}
