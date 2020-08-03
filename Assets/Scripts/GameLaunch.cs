using AssetBundles;
using GameChannel;
using System;
using System.Collections;
using UnityEngine;

public class GameLaunch : MonoBehaviour
{
    private void Awake()
    {
        //初始化框架 start
        this.gameObject.AddComponent<show_fps>();
        this.gameObject.AddComponent<XluaMgr>();
        this.gameObject.AddComponent<ResMgr>();
        //end
        XluaMgr.Instance.Init();
    }

    IEnumerator GameStart()
    {

        var start = DateTime.Now;
        yield return InitPackageName();
        Debug.Log(string.Format("InitPackageName use {0}ms", (DateTime.Now - start).Milliseconds));

        // 启动资源管理模块
        start = DateTime.Now;
        yield return AssetBundleManager.Instance.Initialize();
        Debug.Log(string.Format("AssetBundleManager Initialize use {0}ms", (DateTime.Now - start).Milliseconds));

        string luaAssetbundleName = XluaMgr.Instance.AssetbundleName;

        AssetBundleManager.Instance.SetAssetBundleResident(luaAssetbundleName, true);   //设置lua包为常驻包
        var abloader = AssetBundleManager.Instance.LoadAssetBundleAsync(luaAssetbundleName);
        yield return abloader;
        abloader.Dispose();
        //进入启动逻辑
        XluaMgr.Instance.EnterLuaGame();
        yield break;
    }

    IEnumerator InitPackageName()
    {
#if UNITY_EDITOR
        if (AssetBundleConfig.IsEditorMode)
        {
            yield break;
        }
#endif
        var packageNameRequest = AssetBundleManager.Instance.RequestAssetFileAsync(BuildUtils.PackageNameFileName);
        yield return packageNameRequest;
        var packageName = packageNameRequest.text;
        packageNameRequest.Dispose();
        AssetBundleManager.ManifestBundleName = packageName;
        ChannelManager.instance.Init(packageName);
        Debug.Log(string.Format("packageName = {0}", packageName));
        yield break;
    }

    private void Start()
    {
        StartCoroutine(GameStart());
    }
}
