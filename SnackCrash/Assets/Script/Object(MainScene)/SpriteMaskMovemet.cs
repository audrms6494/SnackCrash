using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMaskMovemet : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 endPos;   
    public float speed = 2.0f; 

    private bool movingToEnd = true; 

    private void Start()
    {
        transform.position = startPos; 
    }

    private void Update()
    {
        Vector3 targetPos = movingToEnd ? endPos : startPos;

      
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (transform.position == targetPos)
        {
            movingToEnd = !movingToEnd;
        }
    }
}
