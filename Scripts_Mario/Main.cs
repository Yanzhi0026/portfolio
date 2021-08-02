using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject _UIRoot;
    public LoadingUI _loadingui;
    public SelectUI _selectui;
    public static Main Ins;
    public GameObject map;
    public GameObject _Player;
    public DieUI _die;
    public WinUI _win;
    public GameObject Box;
    public SetUI _set;
    // Start is called before the first frame update
    void Start()
    {
        Ins = this;
        CreatLoadingUI();
        XmlMgr.Init();
        //CreatMap(1000);

    }

    // Update is called once per frame
    void Update()
    {

    }
    void Print(List<XElement> lst)
    {
        if (null != lst)
        {
            foreach (XElement xe in lst)
            {
                Debug.Log(xe);
            }
        }
    }
    public void CreatPlayer()
    {
        if (null == _Player)
        {
            GameObject player = Resources.Load<GameObject>("Prefabs/Player/Mario");
            _Player = Instantiate<GameObject>(player);
            _Player.transform.position = new Vector2(-16, 0);
        }

    }

    public void CreatDieUI()
    {
        DieUI die = Resources.Load<DieUI>("Prefabs/UI/DieUI");
        _die = Instantiate<DieUI>(die, _UIRoot.transform);

    }
    public void CreatLoadingUI()
    {
        LoadingUI loadingui = Resources.Load<LoadingUI>("Prefabs/UI/LoadingUI");
        _loadingui = Instantiate<LoadingUI>(loadingui, _UIRoot.transform);

    }
    public void CreatSelectUI()
    {
        if (null != _loadingui)
        {
            Destroy(_loadingui.gameObject);
        }
        if (null == _selectui)
        {
            SelectUI selectui = Resources.Load<SelectUI>("Prefabs/UI/SelectUI");
            _selectui = Instantiate<SelectUI>(selectui, _UIRoot.transform);
        }

    }
    public void CreatSetUI()
    {
        if (null == _set)
        {
            SetUI setui = Resources.Load<SetUI>("Prefabs/UI/SetUI");
            _set = Instantiate<SetUI>(setui, _UIRoot.transform);
        }
    }
    public void CreatWinUI()
    {
        if (null == _win)
        {
            WinUI winui = Resources.Load<WinUI>("Prefabs/UI/WinUI");
            _win = Instantiate<WinUI>(winui, _UIRoot.transform);
        }
    }

    public void CreatMap(int nID)
    {
        if (null != XmlMgr._LstMap)
        {
            foreach (XElement xe in XmlMgr._LstMap)//循环
            {
                XAttribute xaid = xe.Attribute("id");
                string strid = (string)xaid;
                int nid = int.Parse(strid);
                if (nID == nid)
                {
                    XAttribute xares = xe.Attribute("res");
                    string strres = (string)xares;
                    string strPath = "Prefabs/Map/" + strres;
                    GameObject scene = Resources.Load<GameObject>(strPath);
                    scene = Instantiate<GameObject>(scene);



                    XAttribute xax = xe.Attribute("posx");//从xml取值
                    XAttribute xay = xe.Attribute("posy");//从xml取值

                    string strX = (string)xax;//强制将Xml转换string
                    string strY = (string)xay;//强制将Xml转换string

                    float nX = float.Parse(strX);//转换float
                    float nY = float.Parse(strY);//转换float

                    scene.transform.position = new Vector2(nX, nY);
                }
            }
        }
    }

    public void CreatBox()
    {
        if (null != XmlMgr._LstBox)
        {
            foreach (XElement xe in XmlMgr._LstBox)//循环
            {
                XAttribute xres = xe.Attribute("res");
                string strRes = (string)xres;
                string strPath = "Prefabs/Box/" + strRes;
                Box = Resources.Load<GameObject>(strPath);
                Box = Instantiate<GameObject>(Box, map.transform);


                XAttribute xaid = xe.Attribute("id");//从xml取值
                XAttribute xaname = xe.Attribute("name");//从xml取值

                XAttribute xax = xe.Attribute("posx");//从xml取值
                XAttribute xay = xe.Attribute("posy");//从xml取值



                string strID = (string)xaid;//强制将Xml转换string
                string strName = (string)xaname;

                string strX = (string)xax;//强制将Xml转换string
                string strY = (string)xay;//强制将Xml转换string



                float nX = float.Parse(strX);//转换float
                float nY = float.Parse(strY);//转换float


                Box.transform.position = new Vector2(nX, nY);//修改坐标
                Box.transform.name = strID + "_" + strName;//改名
            }
        }
    }
    public void CreatRock()
    {
        if (null != XmlMgr._LstRock)
        {
            foreach (XElement xe in XmlMgr._LstRock)//循环
            {
                XAttribute xres = xe.Attribute("res");
                string strRes = (string)xres;
                string strPath = "Prefabs/Rock/" + strRes;
                GameObject Rock = Resources.Load<GameObject>(strPath);
                Rock = Instantiate<GameObject>(Rock, map.transform);


                XAttribute xaid = xe.Attribute("id");//从xml取值
                XAttribute xaname = xe.Attribute("name");//从xml取值

                XAttribute xax = xe.Attribute("posx");//从xml取值
                XAttribute xay = xe.Attribute("posy");//从xml取值



                string strID = (string)xaid;//强制将Xml转换string
                string strName = (string)xaname;

                string strX = (string)xax;//强制将Xml转换string
                string strY = (string)xay;//强制将Xml转换string



                float nX = float.Parse(strX);//转换float
                float nY = float.Parse(strY);//转换float


                Rock.transform.position = new Vector2(nX, nY);//修改坐标
                Rock.transform.name = strID + "_" + strName;//改名

                //RockControl box = Rock.AddComponent<RockControl>();
            }

        }
    }

    public void CreatEnemy()
    {
        if (null != XmlMgr._LstEnemy)
        {
            foreach (XElement xe in XmlMgr._LstEnemy)//循环
            {
                XAttribute xres = xe.Attribute("res");
                string strRes = (string)xres;
                string strPath = "Prefabs/Enemy/" + strRes;
                GameObject Enemy = Resources.Load<GameObject>(strPath);
                Enemy = Instantiate<GameObject>(Enemy, map.transform);


                XAttribute xaid = xe.Attribute("id");//从xml取值
                XAttribute xaname = xe.Attribute("name");//从xml取值

                XAttribute xax = xe.Attribute("posx");//从xml取值
                XAttribute xay = xe.Attribute("posy");//从xml取值



                string strID = (string)xaid;//强制将Xml转换string
                string strName = (string)xaname;

                string strX = (string)xax;//强制将Xml转换string
                string strY = (string)xay;//强制将Xml转换string



                float nX = float.Parse(strX);//转换float
                float nY = float.Parse(strY);//转换float


                Enemy.transform.position = new Vector2(nX, nY);//修改坐标
                Enemy.transform.name = strID + "_" + strName;//改名

                //BoxControl box = Box.AddComponent<BoxControl>();
            }

        }
    }
    //删除map目录下的子文件
    public void des()
    {
        int count = map.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            Destroy(map.transform.GetChild(i).gameObject);
        }
    }
}
