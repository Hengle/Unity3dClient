

local util = {}

function util.tohex(str)
    return str:gsub('.', function (c)
        return string.format('%02X', string.byte(c))
    end)
end

return util
