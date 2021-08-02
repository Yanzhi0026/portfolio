using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockControl : MonoBehaviour
{
    public GameObject Rock;
    public GameObject[] Rocks;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PlayerControl.ins.Hp > 1)
        {
            //如果玩家碰了我，并且碰撞点的法线向上（说明玩家是从线面碰到的）
        if (collision.collider.tag == "Player" && collision.contacts[0].normal == Vector2.up)
        {
            //播放音乐
            AudioManagers.Ins.PlaySound("Sound/顶破砖");
            //小砖块会四散开来。首先遍历一下
            foreach (GameObject rock in Rocks)
            {
                //把父物体（大砖块）设置为空，小砖块就没有父物体了，会显示在前面
                rock.transform.parent = null;
                //3D有爆炸力，2D没有。首先，添加刚体。rock是4个小砖块
                Rigidbody2D rbody = rock.AddComponent<Rigidbody2D>();
                //得到从整体的中心点到各个小砖块中心点的向量。
                Vector2 dir = rock.transform.position - transform.position;
                //给力。dir沿着这个向量的方向*100的力
                rbody.AddForce(dir * 900f);
                //1秒之后销毁
                Destroy(rock, 1f);
            }
            //销毁大砖块
            Destroy(gameObject);
        }
        }
        
    } 
}
