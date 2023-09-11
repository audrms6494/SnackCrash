using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float moveSpeed;
    void Update()
    {
        float mouseX = Input.mousePosition.x;

        Vector3 mousePosition=Camera.main.ScreenToWorldPoint(new Vector3(mouseX,0,0));

        transform.position = new Vector3(mousePosition.x, transform.position.y, transform.position.z);
    }

    public float GetPositionX()
    {
        return this.transform.position.x;
    }
}

