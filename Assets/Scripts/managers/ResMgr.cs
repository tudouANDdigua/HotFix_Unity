/****************************************
//by tudou
*QQ  : 987627639
****************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[LuaCallCSharp]
public class ResMgr : UnitySingleton<ResMgr>
{
    public override void Awake()
    {
        base.Awake();
    }

    public UnityEngine.Object GetAssetCache(string name, string type_name)
    {
        Debug.Log("ResMgr");
        return null;
    }

    public void LoadAssetBundleAsync(string assetbundleName, Action end_func)
    {
        end_func();
        //this.StartCoroutine(this.IE_LoadAssetBundleAsync(assetbundleName, end_func));
    }
}
