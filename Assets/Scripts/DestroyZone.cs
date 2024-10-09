using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // �ε��� �༮�� ���ְ� �ʹ�.
        // ���� �Ѿ��̶�� źâ�� �ٽ� �־�����Ѵ�.
        if (other.gameObject.name.Contains("Bullet"))
        {
            // ��Ȱ��ȭ �����ش�.
            other.gameObject.SetActive(false);
            // źâ�� �־�����.
            GameObject player = GameObject.Find("Player");
            // ���� �÷��̾ �ִٸ�
            if(player)
            {
                PlayerFire pf = player.GetComponent<PlayerFire>();
                pf.bulletObjectPool.Add(other.gameObject);
            }
        }
        else if(other.gameObject.name.Contains("Enemy"))
        {
            // ��Ȱ��ȭ �����ش�.
            other.gameObject.SetActive(false);
            // �� ������ƮǮ�� �־�����.
            GameObject em = GameObject.Find("EnemyManager");
            // ���� �÷��̾ �ִٸ�
            if (em)
            {
                EnemyManager manager = em.GetComponent<EnemyManager>();
                manager.enemyObjectPool.Add(other.gameObject);
            }
        }
        else
        {
            // �ʵ� �װ�
            Destroy(other.gameObject);
        }
    }
}
