using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    public GameObject voxelFactory;

    public int voxelPoolSize = 20;

    public static List<GameObject> voxelPool = new List<GameObject>();


    public float createTime = 0.1f;
    // 경과 시간
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

        // 2. 경과 시간이 생성 시간을 초과했다면
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
                        // 복셀을 생성했을 때만 경과 시간을 초기화해준다.
                        currentTime = 0;
                        // 2. 오브젝트 풀에서 복셀을 하나 가져온다.
                        GameObject voxel = voxelPool[0];
                        // 3. 복셀을 활성화한다.
                        voxel.SetActive(true);
                        // 4. 복셀을 배치하고 싶다.
                        voxel.transform.position = hitInfo.point;
                        // 5. 오브젝트 풀에서 복셀을 제거한다.
                        voxelPool.RemoveAt(0);
                    }
                }
            }
        }
    }
}
