using UnityEngine;

namespace Game.Scripts.Player.Config
{
    [CreateAssetMenu(fileName = "New Player Config", menuName = "Config/Player Config/Base Config")]
    public class PlayerConfig : ScriptableObject
    {
        [Header("MoveState")]
        public float movementVelocity = 10;
        
        [Header("JumpState")]
        public float jumpVelocity = 15f;
        public int amountOfJumps = 1;
        public float variableJumpHeightMultiplier = 0.5f;

        [Header("DashState")]
        public float dashCooldown = 0.5f;
        public float dashDuration = 0.5f;
        public float dashVelocity = 30f;
        public float drag = 10f;
        public float distanceBetweenAfterImage = 0.5f;
        
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
        
        [Header("Check Variables")]
        public float groundCheckRadius = 0.3f;
        public float wallCheckDistance = 0.5f;
        public LayerMask whatIsGround;
    }
}
