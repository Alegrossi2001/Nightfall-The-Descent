using System;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool toggleNightVision;
		public bool canPickUp;
		public bool reload;
		public bool lookbackCamera;

		[Header("Movement Settings")]
		public bool analogMovement;

#if !UNITY_IOS || !UNITY_ANDROID
		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;
#endif

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnNightVision(InputValue value)
		{
			NightVisionInput(value.isPressed);
		}
		
		public void OnPickUp(InputValue value)
		{
			PickUpInput(value.isPressed);
		}

		public void OnReload(InputValue value)
		{
			ReloadInput(value.isPressed);
		}

		public void OnLookBackCamera(InputValue value)
		{
			LooKBackCameraInput(value.isPressed);
		}

#else
        // old input sys if we do decide to have it (most likely wont)...
#endif


        public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void NightVisionInput(bool newNightVisionState)
		{
			toggleNightVision = newNightVisionState;
		}

		public void PickUpInput(bool newPickUpState)
		{
			canPickUp= newPickUpState;
		}

		public void ReloadInput(bool newReloadValue)
		{
			reload = newReloadValue;
		}

        public void LooKBackCameraInput(bool newLookBackValue)
        {
            lookbackCamera = newLookBackValue;
        }

#if !UNITY_IOS || !UNITY_ANDROID

        private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

#endif

	}
	
}