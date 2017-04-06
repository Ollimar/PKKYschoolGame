#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// PlayerMovement
struct PlayerMovement_t3166138480;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CameraScript
struct  CameraScript_t1663580776  : public MonoBehaviour_t1158329972
{
public:
	// UnityEngine.Transform CameraScript::target
	Transform_t3275118058 * ___target_2;
	// UnityEngine.Transform CameraScript::camTargetY
	Transform_t3275118058 * ___camTargetY_3;
	// System.Single CameraScript::smoothTime
	float ___smoothTime_4;
	// System.Single CameraScript::cameraOffsetX
	float ___cameraOffsetX_5;
	// System.Single CameraScript::cameraDepth
	float ___cameraDepth_6;
	// PlayerMovement CameraScript::playerMovement
	PlayerMovement_t3166138480 * ___playerMovement_7;
	// System.Boolean CameraScript::xPlus
	bool ___xPlus_8;
	// System.Boolean CameraScript::xMinus
	bool ___xMinus_9;

public:
	inline static int32_t get_offset_of_target_2() { return static_cast<int32_t>(offsetof(CameraScript_t1663580776, ___target_2)); }
	inline Transform_t3275118058 * get_target_2() const { return ___target_2; }
	inline Transform_t3275118058 ** get_address_of_target_2() { return &___target_2; }
	inline void set_target_2(Transform_t3275118058 * value)
	{
		___target_2 = value;
		Il2CppCodeGenWriteBarrier(&___target_2, value);
	}

	inline static int32_t get_offset_of_camTargetY_3() { return static_cast<int32_t>(offsetof(CameraScript_t1663580776, ___camTargetY_3)); }
	inline Transform_t3275118058 * get_camTargetY_3() const { return ___camTargetY_3; }
	inline Transform_t3275118058 ** get_address_of_camTargetY_3() { return &___camTargetY_3; }
	inline void set_camTargetY_3(Transform_t3275118058 * value)
	{
		___camTargetY_3 = value;
		Il2CppCodeGenWriteBarrier(&___camTargetY_3, value);
	}

	inline static int32_t get_offset_of_smoothTime_4() { return static_cast<int32_t>(offsetof(CameraScript_t1663580776, ___smoothTime_4)); }
	inline float get_smoothTime_4() const { return ___smoothTime_4; }
	inline float* get_address_of_smoothTime_4() { return &___smoothTime_4; }
	inline void set_smoothTime_4(float value)
	{
		___smoothTime_4 = value;
	}

	inline static int32_t get_offset_of_cameraOffsetX_5() { return static_cast<int32_t>(offsetof(CameraScript_t1663580776, ___cameraOffsetX_5)); }
	inline float get_cameraOffsetX_5() const { return ___cameraOffsetX_5; }
	inline float* get_address_of_cameraOffsetX_5() { return &___cameraOffsetX_5; }
	inline void set_cameraOffsetX_5(float value)
	{
		___cameraOffsetX_5 = value;
	}

	inline static int32_t get_offset_of_cameraDepth_6() { return static_cast<int32_t>(offsetof(CameraScript_t1663580776, ___cameraDepth_6)); }
	inline float get_cameraDepth_6() const { return ___cameraDepth_6; }
	inline float* get_address_of_cameraDepth_6() { return &___cameraDepth_6; }
	inline void set_cameraDepth_6(float value)
	{
		___cameraDepth_6 = value;
	}

	inline static int32_t get_offset_of_playerMovement_7() { return static_cast<int32_t>(offsetof(CameraScript_t1663580776, ___playerMovement_7)); }
	inline PlayerMovement_t3166138480 * get_playerMovement_7() const { return ___playerMovement_7; }
	inline PlayerMovement_t3166138480 ** get_address_of_playerMovement_7() { return &___playerMovement_7; }
	inline void set_playerMovement_7(PlayerMovement_t3166138480 * value)
	{
		___playerMovement_7 = value;
		Il2CppCodeGenWriteBarrier(&___playerMovement_7, value);
	}

	inline static int32_t get_offset_of_xPlus_8() { return static_cast<int32_t>(offsetof(CameraScript_t1663580776, ___xPlus_8)); }
	inline bool get_xPlus_8() const { return ___xPlus_8; }
	inline bool* get_address_of_xPlus_8() { return &___xPlus_8; }
	inline void set_xPlus_8(bool value)
	{
		___xPlus_8 = value;
	}

	inline static int32_t get_offset_of_xMinus_9() { return static_cast<int32_t>(offsetof(CameraScript_t1663580776, ___xMinus_9)); }
	inline bool get_xMinus_9() const { return ___xMinus_9; }
	inline bool* get_address_of_xMinus_9() { return &___xMinus_9; }
	inline void set_xMinus_9(bool value)
	{
		___xMinus_9 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
