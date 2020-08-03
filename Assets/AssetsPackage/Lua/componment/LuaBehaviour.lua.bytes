-- 返回一个基类为base的类(全局方法)
function LuaExtend(base) 
	return base:new()
end

local LuaBehaviour = {}
function LuaBehaviour:new(instant) 
	if not instant then 
		instant = {} --类的实例
	end

	setmetatable(instant, {__index = self}) 
	return instant
end

-- obj: GameObject
-- transform, gameObject 
function LuaBehaviour:init(obj)
	self.transform = obj.transform
	self.gameObject = obj
end

function LuaBehaviour:GetComponent(name)
	return self.gameObject:GetComponent(name)
end

return LuaBehaviour