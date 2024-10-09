using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자가 발사버튼을 누르면 총알을 만들고 싶다.
// 필요속성 : 총알공장, 총구
public class PlayerFire : MonoBehaviour
{
    // 필요속성 : 총알공장
    public GameObject bulletFactory;
    // 총구
    public GameObject firePosition;
    // 탄창에 넣을 총알 개수
    public int poolSize = 10;
    // 탄창 - 오브젝트풀 배열
    public List<GameObject> bulletObjectPool;

    void Start()
    {
        // 태어날때 오브젝트풀(탄창)에 총알을 하나씩 생성해서 넣고 싶다.
        // 1. 탄창을 총알 담을 수 있는 크기로 만들어 준다.
        bulletObjectPool = new List<GameObject>();
        // 2. 탄창에 넣을 총알 개수 만큼 반복하여
        for(int i=0;i<poolSize;i++)
        {
            // 3. 총알을 총알공장에서 생성해야 한다.
            GameObject bullet = Instantiate(bulletFactory);
            // 4. 총알을 오브젝트풀에 넣고싶다.
            bulletObjectPool.Add(bullet);
            bullet.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 사용자가 발사버튼을 누르면 총알을 만들고 싶다.
        // 1. 사용자가 발사버튼을 눌렀으니까
        if(Input.GetButtonDown("Fire1"))
        {
            // 탄창에서 총알을 가져다가 발사해야 한다.
            // 탄창안에 총알이 있다면
            if(bulletObjectPool.Count > 0)
            {
                // 첫번째 총알을 가져오자
                GameObject bullet = bulletObjectPool[0];
                // 3. 총알의 위치를 설정
                bullet.transform.position = firePosition.transform.position;
                // 2. 발사해야한다.(활성화 시킨다)
                bullet.SetActive(true);
                bulletObjectPool.Remove(bullet);
            }
        }
    }
}
