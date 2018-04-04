local web = {}
local http = CS.UnityEngine.GameObject.Find('GameFrameWork'):GetComponent('HttpNet')

function web.httpRequest(callback, svr, suburl, method, postdata)
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
		end

		print(res)
        local time = math.floor(res)
        if callback then
            callback(time)
        end
    end, LOGIN_SERVER, "/hello", "GET")
end


return web