using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ��� �̵��ϰ� �ʹ�.
// �ʿ�Ӽ� : �̵��ӵ�
public class Bullet : MonoBehaviour
{
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // ���� ��� �̵��ϰ� �ʹ�.
        // 1. ������ �ʿ��ϴ�.
        Vector3 dir = Vector3.up;
        // 2. �̵��ϰ� �ʹ�.
        // P = P0 + vt
        //Vector3 P0 = transform.position;
        //Vector3 vt = dir * speed * Time.deltaTime;
        //Vector3 P = P0 + vt;
        transform.position += dir * speed * Time.deltaTime;
    }
}
