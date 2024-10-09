using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // ����� ��ũ�� �ϰ� �ʹ�.
    // �ʿ�Ӽ� : ��Ƽ����, ��ũ�� �ӵ�
    Material bgMaterial;
    public float scrollSpeed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        bgMaterial = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        // P = P0 + vt
        // 1. ������ �ʿ��ϴ�.
        Vector2 direction = Vector2.up;
        // 2. ��ũ���ϰ� �ʹ�.
        bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
