using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ڰ� �߻��ư�� ������ �Ѿ��� ����� �ʹ�.
// �ʿ�Ӽ� : �Ѿ˰���, �ѱ�
public class PlayerFire : MonoBehaviour
{
    // �ʿ�Ӽ� : �Ѿ˰���
    public GameObject bulletFactory;
    // �ѱ�
    public GameObject firePosition;
    // źâ�� ���� �Ѿ� ����
    public int poolSize = 10;
    // źâ - ������ƮǮ �迭
    public List<GameObject> bulletObjectPool;

    void Start()
    {
        // �¾�� ������ƮǮ(źâ)�� �Ѿ��� �ϳ��� �����ؼ� �ְ� �ʹ�.
        // 1. źâ�� �Ѿ� ���� �� �ִ� ũ��� ����� �ش�.
        bulletObjectPool = new List<GameObject>();
        // 2. źâ�� ���� �Ѿ� ���� ��ŭ �ݺ��Ͽ�
        for(int i=0;i<poolSize;i++)
        {
            // 3. �Ѿ��� �Ѿ˰��忡�� �����ؾ� �Ѵ�.
            GameObject bullet = Instantiate(bulletFactory);
            // 4. �Ѿ��� ������ƮǮ�� �ְ�ʹ�.
            bulletObjectPool.Add(bullet);
            bullet.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ����ڰ� �߻��ư�� ������ �Ѿ��� ����� �ʹ�.
        // 1. ����ڰ� �߻��ư�� �������ϱ�
        if(Input.GetButtonDown("Fire1"))
        {
            // źâ���� �Ѿ��� �����ٰ� �߻��ؾ� �Ѵ�.
            // źâ�ȿ� �Ѿ��� �ִٸ�
            if(bulletObjectPool.Count > 0)
            {
                // ù��° �Ѿ��� ��������
                GameObject bullet = bulletObjectPool[0];
                // 3. �Ѿ��� ��ġ�� ����
                bullet.transform.position = firePosition.transform.position;
                // 2. �߻��ؾ��Ѵ�.(Ȱ��ȭ ��Ų��)
                bullet.SetActive(true);
                bulletObjectPool.Remove(bullet);
            }
        }
    }
}
