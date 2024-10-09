using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �¾�� �ѹ� ������ ���ϰ� �׸��� ��� �̵��ϰ� �ʹ�.
public class Enemy : MonoBehaviour
{
    // �ʿ�Ӽ� : �̵��ӵ�
    public float speed = 5;
    // Ÿ��
    public Transform target;
    Vector3 dir;
    // ���߰���
    public GameObject explosionFactory;

    // Start is called before the first frame update
    void Start()
    {
        // Ÿ���� ã�ƾ��Ѵ�.
        GameObject player = GameObject.Find("Player");
        // ���� Player �� �ִٸ� Ÿ�ٿ� ���� �־�����
        if(player)
        {
            target = player.transform;
        }

        // Ȯ���� ���ؾ� �Ѵ�.
        int percent = Random.Range(1, 10);
        // Ÿ���� �ְ� Ȯ���� 30�ۼ��� �ȿ� ������
        if(target && percent <= 3)
        {
            // 30% �� Ȯ���� Ÿ�������� ������ ���ϰ�
            dir = target.position - transform.position;
            dir.Normalize();
        }
        // �׷��� ������ �׳� �Ʒ��� ������ ��������
        else
        {
            dir = Vector3.down;
        }
        //  �¾�� �ѹ� ������ ���ϰ�
    }

    // Update is called once per frame
    void Update()
    {
        // ��� �̵��ϰ� �ʹ�.
        transform.position += dir * speed * Time.deltaTime;
    }

    // �ٸ� ��ü�� �ε����� �ʵ� �װ� ���� �װ�ʹ�.
    private void OnCollisionEnter(Collision other)
    {
        // �ε������� ������ ������Ű�� �ʹ�.
        // 3. ScoreManager �� Get/Set �Լ��� �̿��ؼ� �� ����
        ScoreManager.Instance.Score++;

        // ����ȿ���� �߻���Ű�� �ʹ�.
        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        // ���� �Ѿ��̶�� źâ�� �ٽ� �־�����Ѵ�.
        if(other.gameObject.name.Contains("Bullet"))
        {
            // ��Ȱ��ȭ �����ش�.
            other.gameObject.SetActive(false);
            // źâ�� �־�����.
            GameObject player = GameObject.Find("Player");
            // ���� �÷��̾ �ִٸ�
            if (player)
            {
                PlayerFire pf = player.GetComponent<PlayerFire>();
                pf.bulletObjectPool.Add(other.gameObject);
            }
        }
        else
        {
            // �ʵ� �װ�
            Destroy(other.gameObject);
        }
        // ������ƮǮ�� ��ȯ ����� �Ѵ�.
        gameObject.SetActive(false);
        // �� ������ƮǮ�� �־�����.
        GameObject em = GameObject.Find("EnemyManager");
        // ���� �÷��̾ �ִٸ�
        if (em)
        {
            EnemyManager manager = em.GetComponent<EnemyManager>();
            manager.enemyObjectPool.Add(gameObject);
        }
    }
}
