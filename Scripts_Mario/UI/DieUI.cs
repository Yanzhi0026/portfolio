using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class DieUI : MonoBehaviour
{
    public DieUI die;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clickReset()
    {
        Main.Ins.CreatPlayer();
        Destroy(die.gameObject);
    }
    public void clickReturn()
    {
        XmlMgr.remove();   
        XmlMgr.Init();
        Main.Ins.CreatSelectUI();
        Destroy(die.gameObject);
        Main.Ins.des();
    }
}
