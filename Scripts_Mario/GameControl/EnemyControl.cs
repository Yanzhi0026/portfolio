using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public int Hp = 1;
    //方向
    private int dir = 1;
    //刚体
    private Rigidbody2D rig;
    //动画
    private Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //如果死亡就不要移动，不死亡就移动
        if (Hp <= 0)
        {
            return;
        }
        transform.Translate(Vector3.right * dir * 0.3f * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //发生碰撞时
        dir = -dir;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //如果玩家进入触发器
        if (collision.tag == "Player")
        {
            Hp--;
            //判断死亡
            if (Hp <= 0)
            {
                //一秒后销毁
                Destroy(gameObject, 1f);
                //播放死亡声音
                AudioManagers.Ins.PlaySound("Sound/踩敌人");
                //播放死亡动画
                ani.SetBool("Die", true);
                //给玩家向上的力
                collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300f);
                //删除身上的刚体和碰撞体
                foreach (Collider2D c in GetComponents<Collider2D>())
                {
                    Destroy(c);
                }
                Destroy(rig);
            }
        }
    }
}
