#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "UnityEngine_UnityEngine_LayerMask3188175821.h"

// UnityEngine.Transform
struct Transform_t3275118058;
// UnityEngine.Rigidbody2D
struct Rigidbody2D_t502193897;
// CameraScript
struct CameraScript_t1663580776;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// PlayerMovement
struct  PlayerMovement_t3166138480  : public MonoBehaviour_t1158329972
{
public:
	// System.Single PlayerMovement::speed
	float ___speed_2;
	// System.Single PlayerMovement::jumpVelocity
	float ___jumpVelocity_3;
	// System.Boolean PlayerMovement::facingRight
	bool ___facingRight_4;
	// System.Boolean PlayerMovement::isGrounded
	bool ___isGrounded_5;
	// System.Boolean PlayerMovement::canMoveInAir
	bool ___canMoveInAir_6;
	// System.Boolean PlayerMovement::canEnterMetalliala
	bool ___canEnterMetalliala_7;
	// System.Boolean PlayerMovement::canEnterTeatteriJaEsitysTekniikka
	bool ___canEnterTeatteriJaEsitysTekniikka_8;
	// UnityEngine.Transform PlayerMovement::circlePos
	Transform_t3275118058 * ___circlePos_9;
	// System.Single PlayerMovement::circleRadius
	float ___circleRadius_10;
	// UnityEngine.LayerMask PlayerMovement::whatIsGround
	LayerMask_t3188175821  ___whatIsGround_11;
	// UnityEngine.Transform PlayerMovement::myTransform
	Transform_t3275118058 * ___myTransform_12;
	// UnityEngine.Rigidbody2D PlayerMovement::myRB
	Rigidbody2D_t502193897 * ___myRB_13;
	// CameraScript PlayerMovement::cameraScript
	CameraScript_t1663580776 * ___cameraScript_14;
	// UnityEngine.Transform PlayerMovement::maxCam
	Transform_t3275118058 * ___maxCam_15;
	// UnityEngine.Transform PlayerMovement::minCam
	Transform_t3275118058 * ___minCam_16;
	// UnityEngine.Transform PlayerMovement::camTargetY
	Transform_t3275118058 * ___camTargetY_17;
	// UnityEngine.Transform PlayerMovement::targetPoint
	Transform_t3275118058 * ___targetPoint_18;
	// System.Single PlayerMovement::hInput
	float ___hInput_19;

public:
	inline static int32_t get_offset_of_speed_2() { return static_cast<int32_t>(offsetof(PlayerMovement_t3166138480, ___speed_2)); }
	inline float get_speed_2() const { return ___speed_2; }
	inline float* get_address_of_speed_2() { return &___speed_2; }
	inline void set_speed_2(float value)
	{
		___speed_2 = value;
	}

	inline static int32_t get_offset_of_jumpVelocity_3() { return static_cast<int32_t>(offsetof(PlayerMovement_t3166138480, ___jumpVelocity_3)); }
	inline float get_jumpVelocity_3() const { return ___jumpVelocity_3; }
	inline float* get_address_of_jumpVelocity_3() { return &___jumpVelocity_3; }
	inline void set_jumpVelocity_3(float value)
	{
		___jumpVelocity_3 = value;
	}

	inline static int32_t get_offset_of_facingRight_4() { return static_cast<int32_t>(offsetof(PlayerMovement_t3166138480, ___facingRight_4)); }
	inline bool get_facingRight_4() const { return ___facingRight_4; }
	inline bool* get_address_of_facingRight_4() { return &___facingRight_4; }
	inline void set_facingRight_4(bool value)
	{
		___facingRight_4 = value;
	}

	inline static int32_t get_offset_of_isGrounded_5() { return static_cast<int32_t>(offsetof(PlayerMovement_t3166138480, ___isGrounded_5)); }
	inline bool get_isGrounded_5() const { return ___isGrounded_5; }
	inline bool* get_address_of_isGrounded_5() { return &___isGrounded_5; }
	inline void set_isGrounded_5(bool value)
	{
		___isGrounded_5 = value;
	}

	inline static int32_t get_offset_of_canMoveInAir_6() { return static_cast<int32_t>(offsetof(PlayerMovement_t3166138480, ___canMoveInAir_6)); }
	inline bool get_canMoveInAir_6() const { return ___canMoveInAir_6; }
	inline bool* get_address_of_canMoveInAir_6() { return &___canMoveInAir_6; }
	inline void set_canMoveInAir_6(bool value)
	{
		___canMoveInAir_6 = value;
	}

	inline static int32_t get_offset_of_canEnterMetalliala_7() { return static_cast<int32_t>(offsetof(PlayerMovement_t3166138480, ___canEnterMetalliala_7)); }
	inline bool get_canEnterMetalliala_7() const { return ___canEnterMetalliala_7; }
	inline bool* get_address_of_canEnterMetalliala_7() { return &___canEnterMetalliala_7; }
	inline void set_canEnterMetalliala_7(bool value)
	{
		___canEnterMetalliala_7 = value;
	}

	inline static int32_t get_offset_of_canEnterTeatteriJaEsitysTekniikka_8() { return static_cast<int32_t>(offsetof(PlayerMovement_t3166138480, ___canEnterTeatteriJaEsitysTekniikka_8)); }
	inline bool get_canEnterTeatteriJaEsitysTekniikka_8() const { return ___canEnterTeatteriJaEsitysTekniikka_8; }
	inline bool* get_address_of_canEnterTeatteriJaEsitysTekniikka_8() { return &___canEnterTeatteriJaEsitysTekniikka_8; }
	inline void set_canEnterTeatteriJaEsitysTekniikka_8(bool value)
	{
		___canEnterTeatteriJaEsitysTekniikka_8 = value;
	}

	inline static int32_t get_offset_of_circlePos_9() { return static_cast<int32_t>(offsetof(PlayerMovement_t3166138480, ___circlePos_9)); }
	inline Transform_t3275118058 * get_circlePos_9() const { return ___circlePos_9; }
	inline Transform_t3275118058 ** get_address_of_circlePos_9() { return &___circlePos_9; }
	inline void set_circlePos_9(Transform_t3275118058 * value)
	{
		___circlePos_9 = value;
		Il2CppCodeGenWriteBarrier(&___circlePos_9, value);
	}

	inline static int32_t get_offset_of_circleRadius_10() { return static_cast<int32_t>(offsetof(PlayerMovement_t3166138480, ___circleRadius_10)); }
	inline float get_circleRadius_10() const { return ___circleRadius_10; }
	inline float* get_address_of_circleRadius_10() { return &___circleRadius_10; }
	inline void set_circleRadius_10(float value)
	{
		___circleRadius_10 = value;
	}

	inline static int32_t get_offset_of_whatIsGround_11() { return static_cast<int32_t>(offsetof(PlayerMovement_t3166138480, ___whatIsGround_11)); }
	inline LayerMask_t3188175821  get_whatIsGround_11() const { return ___whatIsGround_11; }
	inline LayerMask_t3188175821 * get_address_of_whatIsGround_11() { return &___whatIsGround_11; }
	inline void set_whatIsGround_11(LayerMask_t3188175821  value)
	{
		___whatIsGround_11 = value;
	}

	inline static int32_t get_offset_of_myTransform_12() { return static_cast<int32_t>(offsetof(PlayerMovement_t3166138480, ___myTransform_12)); }
	inline Transform_t3275118058 * get_myTransform_12() const { return ___myTransform_12; }
	inline Transform_t3275118058 ** get_address_of_myTransform_12() { return &___myTransform_12; }
	inline void set_myTransform_12(Transform_t3275118058 * value)
	{
		___myTransform_12 = value;
		Il2CppCodeGenWriteBarrier(&___myTransform_12, value);
	}

	inline static int32_t get_offset_of_myRB_13() { return static_cast<int32_t>(offsetof(PlayerMovement_t3166138480, ___myRB_13)); }
	inline Rigidbody2D_t502193897 * get_myRB_13() const { return ___myRB_13; }
	inline Rigidbody2D_t502193897 ** get_address_of_myRB_13() { return &___myRB_13; }
	inline void set_myRB_13(Rigidbody2D_t502193897 * value)
	{
		___myRB_13 = value;
		Il2CppCodeGenWriteBarrier(&___myRB_13, value);
	}

	inline static int32_t get_offset_of_cameraScript_14() { return static_cast<int32_t>(offsetof(PlayerMovement_t3166138480, ___cameraScript_14)); }
	inline CameraScript_t1663580776 * get_cameraScript_14() const { return ___cameraScript_14; }
	inline CameraScript_t1663580776 ** get_address_of_cameraScript_14() { return &___cameraScript_14; }
	inline void set_cameraScript_14(CameraScript_t1663580776 * value)
	{
		___cameraScript_14 = value;
		Il2CppCodeGenWriteBarrier(&___cameraScript_14, value);
	}

	inline static int32_t get_offset_of_maxCam_15() { return static_cast<int32_t>(offsetof(PlayerMovement_t3166138480, ___maxCam_15)); }
	inline Transform_t3275118058 * get_maxCam_15() const { return ___maxCam_15; }
	inline Transform_t3275118058 ** get_address_of_maxCam_15() { return &___maxCam_15; }
	inline void set_maxCam_15(Transform_t3275118058 * value)
	{
		___maxCam_15 = value;
		Il2CppCodeGenWriteBarrier(&___maxCam_15, value);
	}

	inline static int32_t get_offset_of_minCam_16() { return static_cast<int32_t>(offsetof(PlayerMovement_t3166138480, ___minCam_16)); }
	inline Transform_t3275118058 * get_minCam_16() const { return ___minCam_16; }
	inline Transform_t3275118058 ** get_address_of_minCam_16() { return &___minCam_16; }
	inline void set_minCam_16(Transform_t3275118058 * value)
	{
		___minCam_16 = value;
		Il2CppCodeGenWriteBarrier(&___minCam_16, value);
	}

	inline static int32_t get_offset_of_camTargetY_17() { return static_cast<int32_t>(offsetof(PlayerMovement_t3166138480, ___camTargetY_17)); }
	inline Transform_t3275118058 * get_camTargetY_17() const { return ___camTargetY_17; }
	inline Transform_t3275118058 ** get_address_of_camTargetY_17() { return &___camTargetY_17; }
	inline void set_camTargetY_17(Transform_t3275118058 * value)
	{
		___camTargetY_17 = value;
		Il2CppCodeGenWriteBarrier(&___camTargetY_17, value);
	}

	inline static int32_t get_offset_of_targetPoint_18() { return static_cast<int32_t>(offsetof(PlayerMovement_t3166138480, ___targetPoint_18)); }
	inline Transform_t3275118058 * get_targetPoint_18() const { return ___targetPoint_18; }
	inline Transform_t3275118058 ** get_address_of_targetPoint_18() { return &___targetPoint_18; }
	inline void set_targetPoint_18(Transform_t3275118058 * value)
	{
		___targetPoint_18 = value;
		Il2CppCodeGenWriteBarrier(&___targetPoint_18, value);
	}

	inline static int32_t get_offset_of_hInput_19() { return static_cast<int32_t>(offsetof(PlayerMovement_t3166138480, ___hInput_19)); }
	inline float get_hInput_19() const { return ___hInput_19; }
	inline float* get_address_of_hInput_19() { return &___hInput_19; }
	inline void set_hInput_19(float value)
	{
		___hInput_19 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
