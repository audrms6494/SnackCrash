using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMaskMovemet : MonoBehaviour
{
    public Vector3 startPos; // 시작 위치
    public Vector3 endPos;   // 도착 위치
    public float speed = 2.0f; // 이동 속도

    private bool movingToEnd = true; // 현재 이동 방향

    private void Start()
    {
        transform.position = startPos; // 시작 위치로 초기화
    }

    private void Update()
    {
        // 현재 이동 방향에 따라 목표 위치 선택
        Vector3 targetPos = movingToEnd ? endPos : startPos;

        // 현재 위치에서 목표 위치로 부드럽게 이동
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // 목표 위치에 도달하면 이동 방향을 반대로 바꿈
        if (transform.position == targetPos)
        {
            movingToEnd = !movingToEnd;
        }
    }
}
