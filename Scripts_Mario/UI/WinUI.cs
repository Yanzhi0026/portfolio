﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void clickReturn()
    {
        XmlMgr.remove();
        XmlMgr.Init();
        Main.Ins.CreatSelectUI();
        Destroy(this.gameObject);
        Main.Ins.des();
    }
}
