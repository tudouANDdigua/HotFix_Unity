using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class GameLaunch : MonoBehaviour
{
    private void Awake()
    {
        //初始化框架 start
        this.gameObject.AddComponent<show_fps>();
        this.gameObject.AddComponent<XluaMgr>();
        //end
        XluaMgr.Instance.Init();
    }

    private void Start()
    {
        //进入启动逻辑 start
        XluaMgr.Instance.EnterLuaGame();    
        //end
    }
}
