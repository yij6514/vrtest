using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    public GameObject voxelFactory;

    public int voxelPoolSize = 20;

    public static List<GameObject> voxelPool = new List<GameObject>();


    public float createTime = 0.1f;
    // ��� �ð�
    float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < voxelPoolSize; i++)
        {
            GameObject voxel = Instantiate(voxelFactory);

            voxelFactory.SetActive(false);

            voxelPool.Add(voxel);
        }
    }


    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        // 2. ��� �ð��� ���� �ð��� �ʰ��ߴٸ�
        if (ARAVRInput.Get(ARAVRInput.Button.One))
        {
            if (currentTime > createTime)
            {
                Ray ray = new Ray(ARAVRInput.RHandPosition, ARAVRInput.RHandDirection);
                RaycastHit hitInfo = new RaycastHit();
                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (voxelPool.Count > 0)
                    {
                        // ������ �������� ���� ��� �ð��� �ʱ�ȭ���ش�.
                        currentTime = 0;
                        // 2. ������Ʈ Ǯ���� ������ �ϳ� �����´�.
                        GameObject voxel = voxelPool[0];
                        // 3. ������ Ȱ��ȭ�Ѵ�.
                        voxel.SetActive(true);
                        // 4. ������ ��ġ�ϰ� �ʹ�.
                        voxel.transform.position = hitInfo.point;
                        // 5. ������Ʈ Ǯ���� ������ �����Ѵ�.
                        voxelPool.RemoveAt(0);
                    }
                }
            }
        }
    }
}
