using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleSpawner : MonoBehaviour
{
    public GameObject spawner;
    BoxCollider spawnerCollider;

    private void Awake()
    {
        spawnerCollider = spawner.GetComponent<BoxCollider>();
        //콜라이더 위에 랜덤으로 캡슐 생성하기
    }

    Vector3 RandomPosition()
    {
        Vector3 originPosition =spawner.transform.position;
        // 콜라이더의 사이즈를 가져오는 bound.size 사용
        float range_X = spawnerCollider.bounds.size.x;
        float range_Z = spawnerCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        float range_Y = Random.Range(2f, 4f);
        Vector3 RandomPostion = new Vector3(range_X, range_Y, range_Z);

        Vector3 spawnPosition = originPosition + RandomPostion;
        return spawnPosition;
    }
    public GameObject capsule;
    private void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());   //3초 간격으로 캡슐 생성
    }

    IEnumerator RandomRespawn_Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f); 

            Instantiate(capsule, RandomPosition(), Quaternion.identity);

        }
    }
}
