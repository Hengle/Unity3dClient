local Message = {}

require("framework.protobuf")
local Msgprotocol = require "app.net.Msgprotocol"

local function registerProto(path)
	local buffer = cc.HelperFunc:getFileData(path)
	protobuf.register(buffer)
end


--TODO: auto generate below code
--[[registerProto(cc.FileUtils:getInstance():fullPathForFilename("Protocol/game.pb"))
registerProto(cc.FileUtils:getInstance():fullPathForFilename("Protocol/user.pb"))
registerProto(cc.FileUtils:getInstance():fullPathForFilename("Protocol/HkFiveCard.pb"))
registerProto(cc.FileUtils:getInstance():fullPathForFilename("Protocol/NN100.pb"))
registerProto(cc.FileUtils:getInstance():fullPathForFilename("Protocol/TBNN.pb"))
registerProto(cc.FileUtils:getInstance():fullPathForFilename("Protocol/HLNN.pb"))
registerProto(cc.FileUtils:getInstance():fullPathForFilename("Protocol/TexasPoker.pb"))
registerProto(cc.FileUtils:getInstance():fullPathForFilename("Protocol/Baccarat.pb"))
registerProto(cc.FileUtils:getInstance():fullPathForFilename("Protocol/XZMJ.pb"))
registerProto(cc.FileUtils:getInstance():fullPathForFilename("Protocol/CatchFish.pb"))
registerProto(cc.FileUtils:getInstance():fullPathForFilename("Protocol/ShiSanShui.pb"))
registerProto(cc.FileUtils:getInstance():fullPathForFilename("Protocol/MaJiang.pb"))]]--

local dispatch_handler = {}
local current = ""

function Message.sendMessage(name, msg)
	local id = Msgprotocol[name]
	if not id then
		print("!!! msg have no id, name:", name)
		return
	end
    local data = protobuf.encode(name, msg)
    -- print("send message "..name)
	if Message.net and Message.net.sendData then
		Message.net.sendData(string.char(math.floor(id/256)%256) .. string.char(id%256) .. data)
	end
end

function Message.dispatch(id, data)
	-- heart beat
	if id == 2 then 
		return 
	end

	-- kick player
	if id == 3 or id == 4 then 
		Message.net.disconnect(id) 
	end 

	local name = Msgprotocol[id]
	if not name then
		print("!!! recv error proto id:", id)
		return
	end
	
	-- printf("recv msg[%s]:%s length:%d", tostring(id), tostring(name), #data)
	local msg = protobuf.decode(name, data)
	protobuf.extract(msg)  -- or else crashed when dump(msg).

    local module, method = name:match "([^.]*).(.*)"
    local fun = dispatch_handler[module]
    if fun ~= nil then
    	fun(name, msg)
    else
    	print("no handle for module:", module)
    	print("msg dropped:", name)
    end
end

function Message.dispatchCurrent(name, msg)
	local fun = dispatch_handler[current]
    if fun ~= nil then
    	fun(name, msg)
    end
end

function Message.dispatchGame(name, msg)
	local fun = dispatch_handler["game"]
    if fun ~= nil then
    	fun(name, msg)
    end
end

function Message.registerHandle(name, fun)
	if name ~= "user" and name ~= "game" then
		print("register current:" .. name)
		current = name;
	end
	dispatch_handler[name] = fun
end

function Message.unregisterHandle(name)
	name = name or current
	if name ~= "user" and name ~= "game" then
		current = "";
	end
	dispatch_handler[name] = nil
end

function Message.notifyScene(name, msg, ...)
	local scene = display.getRunningScene()
	if not scene then 
		print("scene is nil, notify msg failed", name, msg)
		return
	end
	if scene[name] then
		scene[name](scene, msg, ...)
	else
		-- print("notify scene failed", scene.name, "have no method:", name)
	end
end

return Message