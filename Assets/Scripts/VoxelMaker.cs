using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    public GameObject voxelFactory;
    public int voxelPoolSize = 20 ;
    public static List<GameObject> voxelPool = new List<GameObject>();

    //voxel 관련
    public float createTime = 0.1f;
    float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        for ( int i=0; i < voxelPoolSize; i++)
        {
            GameObject voxel = Instantiate(voxelFactory);
            voxel.SetActive(false);
            voxelPool.Add(voxel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime > createTime)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            if(Physics.Raycast(ray,out hitInfo)) //마우스가 바닥에 위치해있다면,
            {
                if(voxelPool.Count > 0)
                {
                    GameObject voxel = voxelPool[0];
                    voxel.SetActive(true);
                    voxel.GetComponent<Renderer>().material.color = new Color(Random.value,Random.value,Random.value);
                    voxel.transform.position = hitInfo.point;
                    voxelPool.RemoveAt(0);
                    currentTime = 0;

                }
                else
                {
                    GameObject voxel = Instantiate(voxelFactory);
                    voxel.transform.position = hitInfo.point;
                }

            }
        }
        if (Input.GetButtonDown("Fire1"))
        {
            
        }
    }
}
