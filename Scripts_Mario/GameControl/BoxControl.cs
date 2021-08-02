using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BoxControl : MonoBehaviour
{
    public AnimationCurve curve;//动画曲线
    public GameObject spawnObj;//顶出来的物品
    public GameObject nextobj;//顶出物品之后变为空盒子
    public string sound;
    public int Hp = 1;
    //携程函数
    IEnumerator BoxMove()
    {
        // 开始坐标
        Vector2 pos = transform.position;

        // 曲线时间
        for (float t = 0; t < curve.keys[curve.length-1].time; t += Time.deltaTime)
        {
            // 根据曲线移动Y轴
            transform.position = new Vector2(pos.x, pos.y + curve.Evaluate(t)*0.25f);
            // 下次更新后回到原点
            yield return null;
            Destroy(gameObject, 1f);
        }
        if (null!=spawnObj)
        {
            //实例化物品 向上移动
            Instantiate(spawnObj, transform.position + Vector3.up*0.25f, Quaternion.identity);
        }
        if (null != nextobj)
        {
            //实例化砖块盒子
            Instantiate(nextobj, transform.position, Quaternion.identity);
        }

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        // 当碰撞到人物并且向上移动的时候
        if (coll.collider.tag == "Player" && coll.contacts[0].normal == Vector2.up)
        {
            //当盒子生命大于0
            if (Hp > 0)
            {
                //盒子生命减1
                Hp--;
                //调用委托函数
                StartCoroutine("BoxMove");
                //播放声音
                AudioManagers.Ins.PlaySound(sound);
            }
            else
            {
                AudioManagers.Ins.PlaySound("Sound/顶砖石块");
            }
        } 
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
