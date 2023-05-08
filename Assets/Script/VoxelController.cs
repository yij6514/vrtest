using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 1. ������ ������ �������� ���ư��� ��� �Ѵ�.
// �ʿ� �Ӽ�: ���ư� �ӵ�
// 2. ���� �ð��� ������ ������ �����ϰ� �ʹ�.
// �ʿ� �Ӽ�: ������ ������ �ð�, ��� �ð�
public class VoxelController : MonoBehaviour
{
    // 1. ������ ���ư� �ӵ� ���ϱ�
    public float speed = 5;
    // ������ ������ �ð�
    public float destroyTime = 3.0f;
    // ��� �ð�
    float currentTime;

    void OnEnable()
    {
        currentTime = 0;
        // 2. ������ ������ ã�´�.
        Vector3 direction = Random.insideUnitSphere;
        // 3. ������ �������� ���ư��� �ӵ��� �ش�.
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