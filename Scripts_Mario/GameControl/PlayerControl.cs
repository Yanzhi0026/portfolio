using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public int Hp = 1;
    private Animator ani;
    //是否站在地面
    private bool isGround;
    private Rigidbody2D Rig2d;
    private CapsuleCollider2D cc2d;
    // Start is called before the first frame update
    public static PlayerControl ins;
    void Start()
    {
        ani = GetComponent<Animator>();
        Rig2d = GetComponent<Rigidbody2D>();
        cc2d = GetComponent<CapsuleCollider2D>();
        ins = this;
    }

    // Update is called once per frame
    //在Update下执行玩家跑动函数
    void Update()
    {
        if (Hp <= 1)
        {
            MarioRun();
        }
        if (Hp > 1)
        {
            BigMarioRun();
        }
    }
    //碰到地面碰撞体
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //如果标签是Win就加载win页面
        if (collision.collider.tag == "Win")
        {
            Destroy(gameObject);
            Main.Ins.CreatWinUI();
        }
        //当小马里奥时执行的逻辑(HP=1为小马里奥)
        if (Hp <= 1)
        {
            //小马里奥碰到地面时，让地面为True，跳跃动画为false
            if (collision.collider.tag == "Ground")
            {
                isGround = true;
                ani.SetBool("Jump",false);
            }
            //如果碰到敌人，玩家死亡
            if (collision.collider.tag == "Enemy"||collision.collider.tag=="Die")
            {
                Hp--;
                if (Hp <= 0)
                {
                    //播放死亡动画
                    ani.SetTrigger("Die");
                    //删除玩家刚体
                    Destroy(GetComponent<Collider2D>());
                    //停止当前音乐
                    AudioManagers.Ins.StopMusic();
                    //播放死亡音乐
                    AudioManagers.Ins.PlaySound("Sound/死亡1");
                    //让玩家静止
                    Rig2d.velocity = Vector2.zero;
                    //玩家向上跳跃
                    Rig2d.AddForce(Vector2.up * 200f);
                    //播放死亡2
                    Invoke("PlayerDieSound", 1f);
                    //删除当前玩家预制体
                    Destroy(gameObject, 1f);
                    //加载选择界面
                    Main.Ins.CreatDieUI();
                }
            }
            //碰到蘑菇变大
            if (collision.collider.tag == "mogu")
            {
                Hp++;
                ani.SetTrigger("Big");
                cc2d.size = new Vector2(0.16f, 0.32f);
            }

        }
        if (Hp > 1)
        {
            if (collision.collider.tag == "Ground")
            {
                isGround = true;
                ani.SetBool("BigJump",false);
            }
            //如果碰到敌人，玩家死亡
            if (collision.collider.tag == "Enemy")
            {
                Hp--;
                if (Hp == 1)
                {
                    //播放死亡动画
                    ani.SetTrigger("BigDie");
                    cc2d.size = new Vector2(0.12f, 0.16f);
                    ani.SetTrigger("Idle");
                }
            }
        }



    }
    void PlayerDieSound()
    {
        AudioManagers.Ins.PlaySound("Sound/死亡2");
    }
    //离开碰撞体
    private void OnCollisionExit2D(Collision2D collision)
    {
        //当人物离开地面时执行跳跃动画
        if (collision.collider.tag == "Ground")
        {
            isGround = false;
            //离开地面就跳跃       
            if (Hp <= 1)
            {
                ani.SetBool("Jump", true);
            }
            if (Hp > 1)
            {
                ani.SetBool("BigJump", true);
            }
        }


    }
    //人物跑动函数
    void MarioRun()
    {
        //得到水平轴-1 0 1
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            //移动 方向*速度*正负（左右）
            transform.Translate(transform.right * 1f * Time.deltaTime * horizontal);
            //转向，翻转
            if (horizontal > 0)
            {
                //水平轴为正的时候往右走，反转
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (horizontal < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            //播放移动动画
            ani.SetBool("Run", true);
        }
        else
        {
            //播放站立动画
            ani.SetBool("Run", false);
        }
        //跳跃
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            //给一个向上的力
            Rig2d.AddForce(Vector2.up * 200f);
            //播放跳跃声音
            AudioManagers.Ins.PlaySound("Sound/跳");
        }
        
    }
    //人物变大后跑动函数
    void BigMarioRun()
    {
        //得到水平轴-1 0 1
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            //移动 方向*速度*正负（左右）
            transform.Translate(transform.right * 1f * Time.deltaTime * horizontal);
            //转向，翻转
            if (horizontal > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (horizontal < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            //播放移动动画
            ani.SetBool("BigRun", true);
        }
        else
        {
            //播放站立动画
            ani.SetBool("BigRun", false);
        }
        //跳跃
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            //给一个向上的力
            Rig2d.AddForce(Vector2.up * 200f);
            //播放跳跃声音
            AudioManagers.Ins.PlaySound("Sound/跳");
        }
    }
}
