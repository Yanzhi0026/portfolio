using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : MonoBehaviour
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
        //ani = GetComponent<Animator>();
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
        if (collision.tag == "Player")
        {
            Hp--;
            //判断死亡
            if (Hp <= 0)
            {
                //一秒后销毁
                Destroy(gameObject);
            }
        }
    }
}
