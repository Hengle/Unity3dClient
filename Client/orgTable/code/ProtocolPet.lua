local descriptor = require "descriptor"
local Protocol = require "Protocol"
local ProtocolBase = require "ProtocolBase"

module "ProtocolPet"

PetInfo = descriptor.def_struct("PetInfo", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("dataId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("exp", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("hunger", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("skillIndex", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("pointFeedCount", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("goldFeedCount", descriptor.type_uint8, 0),
	}
)

PetBaseInfo = descriptor.def_struct("PetBaseInfo", 
	{
		descriptor.def_scalar_field("dataId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("hunger", descriptor.type_uint16, 0),
		descriptor.def_scalar_field("skillIndex", descriptor.type_uint8, 0),
	}
)

ScenePet = descriptor.def_struct("ScenePet", 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("dataId", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("level", descriptor.type_uint16, 0),
	}
)

SceneSyncPetList = descriptor.def_message("SceneSyncPetList", 502201, 
	{
		descriptor.def_scalar_field("followPetId", descriptor.type_uint64, 0),
		descriptor.def_scalar_vector_field("battlePets", descriptor.type_uint64, 0),
		descriptor.def_message_vector_field("petList", PetInfo),
	}
)

SceneSyncPet = descriptor.def_message("SceneSyncPet", 502202, 
	{
	}
)

SceneDeletePet = descriptor.def_message("SceneDeletePet", 502203, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

SceneSetPetSoltReq = descriptor.def_message("SceneSetPetSoltReq", 502205, 
	{
		descriptor.def_scalar_field("petType", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("petId", descriptor.type_uint64, 0),
	}
)

SceneSetPetSoltRes = descriptor.def_message("SceneSetPetSoltRes", 502206, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_vector_field("battlePets", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("followPetId", descriptor.type_uint64, 0),
	}
)

SceneFeedPetReq = descriptor.def_message("SceneFeedPetReq", 502207, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("feedType", descriptor.type_uint8, 0),
	}
)

SceneFeedPetRes = descriptor.def_message("SceneFeedPetRes", 502208, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("feedType", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("isCritical", descriptor.type_uint8, 0),
		descriptor.def_scalar_field("value", descriptor.type_uint32, 0),
	}
)

SceneSellPetReq = descriptor.def_message("SceneSellPetReq", 502209, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

SceneSellPetRes = descriptor.def_message("SceneSellPetRes", 502210, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
	}
)

SceneChangePetSkillReq = descriptor.def_message("SceneChangePetSkillReq", 502211, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("skillIndex", descriptor.type_uint8, 0),
	}
)

SceneChangePetSkillRes = descriptor.def_message("SceneChangePetSkillRes", 502212, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("petId", descriptor.type_uint64, 0),
		descriptor.def_scalar_field("skillIndex", descriptor.type_uint8, 0),
	}
)

SceneSetPetFollowReq = descriptor.def_message("SceneSetPetFollowReq", 502213, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
	}
)

SceneSetPetFollowRes = descriptor.def_message("SceneSetPetFollowRes", 502214, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("petId", descriptor.type_uint64, 0),
	}
)

SceneDevourPetReq = descriptor.def_message("SceneDevourPetReq", 502215, 
	{
		descriptor.def_scalar_field("id", descriptor.type_uint64, 0),
		descriptor.def_scalar_vector_field("petIds", descriptor.type_uint64, 0),
	}
)

SceneDevourPetRes = descriptor.def_message("SceneDevourPetRes", 502216, 
	{
		descriptor.def_scalar_field("result", descriptor.type_uint32, 0),
		descriptor.def_scalar_field("exp", descriptor.type_uint32, 0),
	}
)

