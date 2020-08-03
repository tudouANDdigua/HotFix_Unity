local LuaBehaviour = require("componment.LuaBehaviour")
local cube_ctrl = LuaExtend(LuaBehaviour)

local ResMgr = require("managers.ResMgr")

function cube_ctrl:Awake()
	print("=============Awake===========")
	ResMgr.GetAssetCache("test", "test_type")
end

function cube_ctrl:Update()
	print("=============Update===========")
end

return cube_ctrl