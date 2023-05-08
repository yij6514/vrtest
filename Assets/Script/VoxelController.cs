using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1. 복셀은 랜덤한 방향으로 날아가는 운동을 한다.
// 필요 속성: 날아갈 속도
// 2. 일정 시간이 지나면 복셀을 제거하고 싶다.
// 필요 속성: 복셀을 제거할 시간, 경과 시간
public class VoxelController : MonoBehaviour
{
    // 1. 복셀이 날아갈 속도 구하기
    public float speed = 5;
    // 복셀을 제거할 시간
    public float destroyTime = 3.0f;
    // 경과 시간
    float currentTime;

    void OnEnable()
    {
        currentTime = 0;
        // 2. 랜덤한 방향을 찾는다.
        Vector3 direction = Random.insideUnitSphere;
        // 3. 랜덤한 방향으로 날아가는 속도를 준다.
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = direction * speed;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > destroyTime)
        {
            gameObject.SetActive(false);
            VoxelMaker.voxelPool.Add(gameObject);
        }
    }
}