using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Player.Config
{
    [CreateAssetMenu(fileName = "New Player Config", menuName = "Config/Player Config/Base Config")]
    public class PlayerConfig : ScriptableObject
    {
        [Header("MoveState")]
        public float movementVelocity = 10;
        
        [Header("CrouchState")]
        public float crouchMovementVelocity = 5f;
        public float crouchColliderHeight = 1f;
        public float standColliderHeight = 2.4f;
        
        [Header("JumpState")]
        public float jumpVelocity = 15f;
        public int amountOfJumps = 1;
        public float variableJumpHeightMultiplier = 0.5f;

        [Header("DodgeState")]
        public float dashCooldown = 0.5f;
        public float dodgeDuration = 0.5f;
        public float dodgeVelocity = 30f;
        public float drag = 10f;
        
        [Header("WallJumpState")]
        public float wallJumpVelocity = 20f;
        public float wallJumpTime = 0.4f;
        public Vector2 wallJumpAngle = new Vector2(1, 2);
        
        [Header("WallSlideState")]
        public float wallSlideVelocity = 3f;
        
        [Header("WallClimbState")]
        public float wallClimbVelocity = 3f;

        [Header("LedgeClimbState")] 
        public Vector2 startOffset;
        public Vector2 endOffset;
    }
}
