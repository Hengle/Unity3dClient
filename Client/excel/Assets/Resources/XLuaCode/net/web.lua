LOGIN_SERVER = { ip="192.168.0.108", port=6001 }
local web = {}
local http = CS.UnityEngine.GameObject.Find('GameFrameWork'):GetComponent('HttpNet')

function web.httpRequest(callback, svr, suburl, method, postdata)
    print(svr,suburl,method,postdata)
    local fullurl = "http://"..svr.ip..":"..svr.port..suburl

    if method == "POST" then
    	http:Post(callback, fullurl, postdata)
	elseif method == "GET" then
		http:Get(callback, fullurl)
	else
		print("method is not support!")
    end
    
    print("start request:", fullurl)
end


function web.getServerTime(callback)
    web.httpRequest(function (isErr, res)
        if isErr == true then
			callback(0)
            return
		end

        local time = math.floor(res)
        if callback then
            callback(time)
        end
    end, LOGIN_SERVER, "/hello", "GET")
end


return web

--[[
LOGIN_SERVER = { ip="192.168.0.100", port=6001 }
local json = require(".utility.json")
local util = require(".utility.util")
local web = require(".net.web")

local params = {
                cmd = "register",
                channel = "channel_game", 
                account = "test_acc", 
                password = "123",
                invite_code = "nviteCode",
                phone = "13566668888",
                reg_code = "code",
                reg_id = ""
            }

local LoginNet = {}

function LoginNet.auth(callback, params)
    web.getServerTime(function (time)
        if time <= 0 then
            return
        end

        params.client_tag = "test_clt_tag"
        params.platform = "test_pf"

        local msg = json.encode(params)
        msg = CS.Common.DESEncrypt.MyEncode(msg, time)
        msg = util.tohex(msg)

        auth(callback, time, msg, params)
    end)
end

function loginCallback(ok, msg)
    print(ok)
    print(msg)
    --print("loginCallback,ok:"..ok.."msg:"..msg)
end

function auth(callback, time, msg, params)
    local postdata = {
        time = tostring(time),
        content = msg,
    }

    web.httpRequest(callback, LOGIN_SERVER, "/login", "POST", postdata)
end

LoginNet.auth(loginCallback, params)
]]