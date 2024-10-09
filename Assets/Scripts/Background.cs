using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // 배경을 스크롤 하고 싶다.
    // 필요속성 : 머티리얼, 스크롤 속도
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
        // 1. 방향이 필요하다.
        Vector2 direction = Vector2.up;
        // 2. 스크롤하고 싶다.
        bgMaterial.mainTextureOffset += direction * scrollSpeed * Time.deltaTime;
    }
}
