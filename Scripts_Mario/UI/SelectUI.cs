using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clickStar()
    {
        if (null != gameObject)
        {
            Destroy(gameObject);
            Main.Ins.CreatMap(1000);
            Main.Ins.CreatPlayer();
            Main.Ins.CreatBox();
            Main.Ins.CreatRock();
            Main.Ins.CreatEnemy();
        }
       
    }
    public void clickSet()
    {
        Destroy(gameObject);
        Main.Ins.CreatSetUI();

    }
}
