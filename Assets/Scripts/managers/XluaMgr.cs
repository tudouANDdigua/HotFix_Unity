using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class XluaMgr : UnitySingleton<XluaMgr>
{
    public const string luaScriptsFolder = "LuaScripts";
    public const string luaAssetbundleAssetName = "Lua";
    const string gameMainScriptName = "main"; //lua 启动脚本

    private LuaEnv luaEnv = null;
    private bool HasGameStart = false;//游戏是否启动

    public override void Awake()
    {
        base.Awake();
    }

    public void EnterLuaGame()
    {
        if (luaEnv == null) return;
        LoadScript(gameMainScriptName);//加载main脚本
        SafeDoString("main.start()");//执行main.start()方法
        this.HasGameStart = true;
    }

    //创建lua虚拟机
    public void Init()
    {
        luaEnv = new LuaEnv();
        if (luaEnv == null) return;
        //定制代码加载策略
        luaEnv.AddLoader(CustomLoader);
    }

    // require(main) 或者 require(game.game_start) 会加载这个方法
    public static byte[] CustomLoader(ref string filePath)
    {
        string scriptPath = string.Empty;
        filePath = filePath.Replace(".", "/") + ".lua"; // game/game_start.lua
#if UNITY_EDITOR
        //if (AssetBundleConfig.IsEditorMode)
        {
            scriptPath = Path.Combine(Application.dataPath, luaScriptsFolder);
            scriptPath = Path.Combine(scriptPath, filePath);

            byte[] data = GameUtility.SafeReadAllBytes(scriptPath);
            return data;
        }
#endif

        //scriptPath = string.Format("{0}/{1}.bytes", luaAssetbundleAssetName, filePath);
        //string assetbundleName = null;
        //string assetName = null;

        //bool status = AssetBundleManager.Instance.MapAssetPath(scriptPath, out assetbundleName, out assetName);
        //if (!status)
        //{
        //    Debug.LogError("MapAssetPath failed : " + scriptPath);
        //    return null;
        //}

        //var asset = AssetBundleManager.Instance.GetAssetCache(assetName) as TextAsset;
        //if (asset != null)
        //{
        //    return asset.bytes;
        //}
        //Debug.LogError("Load lua script failed : " + scriptPath + ", You should preload lua assetbundle first!!!");
        //return null;

    }

    // 执行脚本, scriptContent脚本代码的文本内容;
    public void SafeDoString(string scriptContent)
    {
        if (this.luaEnv != null)
        {
            try
            {
                luaEnv.DoString(scriptContent); // 执行我们的脚本代码;
            }
            catch (System.Exception ex)
            {
                string msg = string.Format("xLua exception : {0}\n {1}", ex.Message, ex.StackTrace);
                Debug.LogError(msg, null);
            }
        }
    }

    // LoadScript(game.game_start) == require(game.game_start)
    public void LoadScript(string scriptName)
    { 
        SafeDoString(string.Format("require('{0}')", scriptName));
    }

    //重载脚本 == 先卸载，在加载
    public void ReloadScript(string scriptName)
    {
        SafeDoString(string.Format("package.loaded['{0}'] = nil", scriptName));
        LoadScript(scriptName);
    }
}
