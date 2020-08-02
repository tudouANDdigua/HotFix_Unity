local LuaBehaviour = require("componment.LuaBehaviour")
local cube_ctrl = LuaExtend(LuaBehaviour)

function cube_ctrl:Awake()
	print("=============Awake===========")
end

function cube_ctrl:Update()
	print("=============Update===========")
end

return cube_ctrl