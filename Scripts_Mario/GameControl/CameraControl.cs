using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //跟随的目标
    //public Transform taget;
    public GameObject Mario;
    //边界
    public float MinX;
    public float MaxX;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        //找到马里奥
        Mario = GameObject.Find("Mario(Clone)");
        if (null != Mario)
        {
            //让摄像机和马里奥位置相等
            Vector3 v3 = transform.position;
            v3.x = Mario.transform.position.x;
            //定义边界
            if (v3.x > MaxX)
            {
                v3.x = MaxX;
            }
            if (v3.x < MinX)
            {
                v3.x = MinX;
            }
            transform.position = v3;
        }
       
    }
}
