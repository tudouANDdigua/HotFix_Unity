require("managers.LuaGameObject")
local game = require("game.start")


main = {}
local function start()
    game.init();
end

local function OnApplicationQuit()
end

local function Update()
    LuaGameObject.Update()
end

local function FixedUpdate()
	LuaGameObject.FixedUpdate()
end


local function LateUpdate()
	LuaGameObject.LateUpdate()
end

-- 这样写可以直接用.来调用方法
main.OnApplicationQuit = OnApplicationQuit
main.Update = Update
main.FixedUpdate = FixedUpdate
main.LateUpdate = LateUpdate
main.start = start

return main