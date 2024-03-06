using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
	{	
		private PlayerInput _playerInput;
		

		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool interact;
		public bool attack;
		public float changeWeapon;
		public bool menu;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
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

		public void OnAttack(InputValue value)
		{
			AttackInput(value.isPressed);
		}
		public void OnChangeWeapon(InputValue value)
		{
			Debug.Log(value);
			ChangeWeaponInput(value.Get<float>());
		}

        public void OnMenu(InputValue value)
		{
			Menu(value.isPressed);
		}
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

		public void AttackInput(bool newAttackState)
		{
			attack = newAttackState;
		}
		public void ChangeWeaponInput(float newChangeWeaponUpState)
		{
			changeWeapon = newChangeWeaponUpState;
		}
		public void Menu(bool newMenuState)
		{
			menu = newMenuState;
		}
		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

		private void ListenInput(bool isListening)
		{
			if(isListening) 
			{
				_playerInput.ActivateInput();
			}
			else 
			{
				_playerInput.DeactivateInput();
			}
		}
		private void OnDisable()
		{
			PauseMenuButtons.DeactivateInputAction -= ListenInput;
		}

		private void OnEnable()
		{
			PauseMenuButtons.DeactivateInputAction += ListenInput;
		}

		private void Awake()
		{
			_playerInput = GetComponent<PlayerInput>();
		}
	}
	
}