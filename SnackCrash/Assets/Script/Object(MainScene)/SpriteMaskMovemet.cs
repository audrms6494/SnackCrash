using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMaskMovemet : MonoBehaviour
{
    public Vector3 startPos; // ���� ��ġ
    public Vector3 endPos;   // ���� ��ġ
    public float speed = 2.0f; // �̵� �ӵ�

    private bool movingToEnd = true; // ���� �̵� ����

    private void Start()
    {
        transform.position = startPos; // ���� ��ġ�� �ʱ�ȭ
    }

    private void Update()
    {
        // ���� �̵� ���⿡ ���� ��ǥ ��ġ ����
        Vector3 targetPos = movingToEnd ? endPos : startPos;

        // ���� ��ġ���� ��ǥ ��ġ�� �ε巴�� �̵�
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        // ��ǥ ��ġ�� �����ϸ� �̵� ������ �ݴ�� �ٲ�
        if (transform.position == targetPos)
        {
            movingToEnd = !movingToEnd;
        }
    }
}
