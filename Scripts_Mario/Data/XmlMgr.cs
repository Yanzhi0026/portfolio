using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using System.Xml;

public class XmlMgr
{
    public static List<XElement> _LstRock = new List<XElement>();//获取列表
    public static List<XElement> _LstBox = new List<XElement>();//获取列表
    public static List<XElement> _LstEnemy = new List<XElement>();//获取列表
    public static List<XElement> _LstItem = new List<XElement>();//获取列表
    public static List<XElement> _LstMap = new List<XElement>();//获取列表

    public static void Init()//加载MonsterXml
    {
        InitRockXml();
        InitEnemyXml();
        InitItemXml();
        InitMapXml();
        InitBoxXml();
    }
    public static void remove()
    {
        _LstBox.Clear();
        _LstMap.Clear();
        _LstRock.Clear();
        _LstEnemy.Clear();
        _LstItem.Clear();
        //_LstEnemy.Clear();
    }

    public static List<XElement> InitXml(string strPath, string strRoot, string strData = "")
    {
        string strText = strData;
        if ("" == strData)
        {
            TextAsset text = Resources.Load<TextAsset>(strPath);//读取Xml/Monster
            strText = text.text;
            //Debug.Log(text.text);
        }
        if ("" != strText)
        {
            List<XElement> lst = new List<XElement>();
            
            XElement elets = XElement.Parse(strText);//解析Monster.xml
            if (null != elets)
            {
                IEnumerable iens = elets.DescendantsAndSelf(strRoot);//迭代器，游标
                foreach (XElement xe in iens)
                {
                    lst.Add(xe);//将Monster的内容添加到_LstMonster列表
                }
                return lst;
            }
            if (null == elets)
            {
                return null;
            }
        }
        return null;
    }

    //加载方法
    public static void InitBoxXml()
    {
        _LstBox = InitXml("Config/Box", "Box");
    }
    public static void InitRockXml()
    {
        _LstRock = InitXml("Config/Rock", "Rock");
    }
    public static void InitEnemyXml()
    {
        _LstEnemy = InitXml("Config/Enemy", "Enemy");
    }
    public static void InitItemXml()
    {
        _LstItem = InitXml("Config/Item", "Item");
    }
    public static void InitMapXml()
    {
        _LstMap = InitXml("Config/Map", "Map");
    }
}
