using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 angle;
    public float sensitivity = 200;

    void Start()
    {
        angle = Camera.main.transform.eulerAngles;
        angle.x = angle.x * -1;// angle.x*=-1와 동일
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 정보 입력
        //방향 확인
        //회전
        float x = Input.GetAxis("Mouse Y");
        float y = Input.GetAxis("Mouse X");

        angle.x += x * sensitivity * Time.deltaTime;
        angle.y += y * sensitivity * Time.deltaTime;
        // 일부러 z 축의 값은 안 가져와 놓은 상태. angle.z = transform.eulerAngles.z 가 정상

        angle.x = Mathf.Clamp(angle.x, -90, 90);

        transform.eulerAngles = new Vector3(-angle.x,angle.y,transform.eulerAngles.z);
    }
    

}
