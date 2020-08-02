local start = {}

-- require所有的脚本 start
local cube_ctrl = require("game.cube.cube_ctrl")

-- require所有的脚本 end

-- 进入游戏场景
local function enter_game_scene()
end

-- 进入登录场景
local function enter_login_scene()
    -- 放所有的业务逻辑（加载地图，怪物，UI ... ...)
    

    -- 测试
    local obj = LuaGameObject.Find("Cube")
    LuaGameObject.AddLuaComponent(obj, cube_ctrl)
    -- end
end

function init()
    print("init方法被调用")
    enter_login_scene()
end

start.init = init

return start