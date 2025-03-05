using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Scripts.Player
{
    public class PlayerInputHandler : MonoBehaviour
    {
        public Vector2 RawMovementInput {get; private set;}
        public int NormalizeInputX {get; private set;}
        public int NormalizeInputY {get; private set;}
        public bool JumpInput {get; private set;}
        public bool JumpInputStop {get; private set;}
        public bool GrabInput {get; private set;}
        public bool DodgeInput {get; private set;}
        
        public bool[] AttackInputs  {get; private set;}

        [SerializeField] private float inputHoldTime = 0.2f;
        
        private float jumpInputStartTime;

        private void Start()
        {
            var count = Enum.GetValues(typeof(CombatInputs)).Length;
            AttackInputs = new bool[count];
        }

        private void Update()
        {
            CheckJumpInputHoldTime();
        }

        public void OnPrimaryAttackInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                AttackInputs[(int)CombatInputs.Primary] = true;
            }
            if (context.canceled)
            {
                AttackInputs[(int)CombatInputs.Primary] = false;
            }
        }

        public void OnSecondaryAttackInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                AttackInputs[(int)CombatInputs.Secondary] = true;
            }
            if (context.canceled)
            {
                AttackInputs[(int)CombatInputs.Secondary] = false;
            }
        }

        public void OnMoveInput(InputAction.CallbackContext context)
        {
            RawMovementInput = context.ReadValue<Vector2>();
            
            NormalizeInputX = Mathf.RoundToInt(RawMovementInput.x);
            NormalizeInputY = Mathf.RoundToInt(RawMovementInput.y);
            //Debug.Log(RawMovementInput);
        }

        public void OnJumpInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                JumpInput = true;
                JumpInputStop = false;
                jumpInputStartTime = Time.time;
            }

            if (context.canceled)
            {
                JumpInputStop = true;
            }
        }

        public void OnGrabInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                GrabInput = true;
            }

            if (context.canceled)
            {
                GrabInput = false;
            }
        }

        public void OnDodgeInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                DodgeInput = true;
            }
            else if (context.canceled)
            {
                DodgeInput = false;
            }
        }
        
        private void CheckJumpInputHoldTime()
        {
            if (Time.time > jumpInputStartTime + inputHoldTime)
            {
                JumpInput = false;
            }
        }

        public void UseJumpInput() => JumpInput = false;
        public void UseDashInput() => DodgeInput = false;
    }
    
    public enum CombatInputs
    {
        Primary,
        Secondary
    }
}
