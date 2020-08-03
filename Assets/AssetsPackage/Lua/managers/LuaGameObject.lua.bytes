LuaGameObject = {}

local GameObject = CS.UnityEngine.GameObject
local GameObjectMap = {}	--GameObject与脚本的映射表

local function Instantiate(prefab)
    return GameObject.Instantiate(prefab)
end

local function Destroy(obj)
	local obj_id = obj:GetInstanceID()
	if (GameObjectMap[obj_id]) then -- 删除掉所有的组件实例
		table.remove(GameObjectMap, obj_id)
	end

	GameObject.Destroy(obj)
end

local function DestroyAfter(obj, afterTime)
	local obj_id = obj:GetInstanceID()
	if (GameObjectMap[obj_id]) then -- 删除掉所有的组件实例
		table.remove(GameObjectMap, obj_id)
	end

    GameObject.Destroy(obj, afterTime)
end

local function AddLuaComponent(obj, lua_class)
	local componet = lua_class:new()
	componet:init(obj)
	local obj_id = obj:GetInstanceID()
	if(GameObject[obj_id]) then
		table.insert(GameObjectMap[obj_id], componet)
	else
		GameObjectMap[obj_id] = {}
		table.insert(GameObjectMap[obj_id], componet)
	end
	-- 添加的时候调用 Awake
	if componet.Awake ~= nil then 
		componet:Awake()
	end
    return componet
end

local function Find(name)
	return GameObject.Find(name)
end

local function GetLuaComponent(obj, lua_class)
    return nil
end

local function trigger_update(components_array)
	local key, value
	for key, value in pairs(components_array) do
		if value.Update ~= nil then
			value:Update()
		end
	end
end

local function trigger_fixupdate(components_array)
	local key, value
	for key, value in pairs(components_array) do
		if value.FixedUpdate ~= nil then
			value:FixedUpdate()
		end
	end
end

local function trigger_lateupdate(components_array)
	local key, value
	for key, value in pairs(components_array) do
		if value.LateUpdate ~= nil then
			value:LateUpdate()
		end
	end
end


local function Update()
	local key, value
	for key, value in pairs(GameObjectMap) do
		trigger_update(value)
	end
end

local function FixedUpdate()
	local key, value
	for key, value in pairs(GameObjectMap) do
		trigger_fixupdate(value)
	end
end

local function LateUpdate()
	local key, value
	for key, value in pairs(GameObjectMap) do
		trigger_lateupdate(value)
	end
end

LuaGameObject.Update = Update
LuaGameObject.LateUpdate = LateUpdate
LuaGameObject.FixedUpdate = FixedUpdate

LuaGameObject.Find = Find
LuaGameObject.Instantiate = Instantiate
LuaGameObject.Destroy = Destroy
LuaGameObject.DestroyAfter = DestroyAfter
LuaGameObject.AddLuaComponent = AddLuaComponent
LuaGameObject.GetLuaComponent = GetLuaComponent
return LuaGameObject