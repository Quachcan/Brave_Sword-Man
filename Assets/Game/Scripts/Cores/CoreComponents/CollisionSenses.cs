using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.Cores.CoreComponents
{
    public class CollisionSenses : CoreComponent
    {
        
        #region CheckTransform
        
        public Transform GroundCheck {
            get
            {
                if (groundCheck)
                {
                    return groundCheck;
                }
                
                Debug.LogError("CollisionSenses::GroundCheck: Ground Check Not Set" + Core.transform.parent.name);
                return null;
            }
            private set => groundCheck = value; }
        public Transform WallCheck { 
            get
            {
                if (wallCheck)
                {
                    return wallCheck;
                }
                    
                Debug.LogError("CollisionSenses::WallCheck Wall Check Not Set" + Core.transform.parent.name);
                return null;
            } 
            private set => wallCheck = value; }
        public Transform LedgeCheckHorizontal { 
            get
            {
                if (ledgeCheckHorizontal)
                {
                    return ledgeCheckHorizontal;
                }
                    
                Debug.LogError("CollisionSenses::ledgeCheckHorizontal: ledge Check Horizontal Not Set" + Core.transform.parent.name);
                return null;
            }
            private set => ledgeCheckHorizontal = value; }
        public Transform LedgeCheckVertical
        {
            get
            {
                if (ledgeCheckVertical)
                {
                    return ledgeCheckVertical;
                }
                    
                Debug.LogError("CollisionSenses::ledgeCheckVertical: ledge Check Vertical Not Set" + Core.transform.parent.name);
                return null;
            }
            private set => ledgeCheckVertical = value;
        }
        public Transform CeilingCheck { 
            get
            {
                if (ceilingCheck)
                {
                    return ceilingCheck;
                }
                        
                Debug.LogError("CollisionSenses::ceilingCheck: ceiling Check Not Set" + Core.transform.parent.name);
                return null;
            } 
            private set => ceilingCheck = value; }
        
        public float GroundCheckRadius { get => groundCheckRadius;  set => groundCheckRadius = value; }
        public float WallCheckDistance { get => wallCheckDistance;  set => wallCheckDistance = value; }
        public LayerMask WhatIsGround { get => whatIsGround;  set => whatIsGround = value; }
        
        [SerializeField] private Transform groundCheck;
        [SerializeField] private Transform wallCheck;
        [SerializeField] private Transform ledgeCheckHorizontal;
        [SerializeField] private Transform ledgeCheckVertical;
        [SerializeField] private Transform ceilingCheck;
        
        [SerializeField] private float groundCheckRadius;
        [SerializeField] private float wallCheckDistance;
        
        [SerializeField] private LayerMask whatIsGround;
        #endregion
        
        
        #region Check Functions

        public bool Ground
        {
            get => Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, whatIsGround);
        }
        
        public bool Ceiling
        {
            get => Physics2D.OverlapCircle(CeilingCheck.position, groundCheckRadius, whatIsGround);
        }

        public bool WallFront
        {
            get => Physics2D.Raycast(WallCheck.position, Vector2.right * Core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
        }

        public bool LedgeHorizontal
        {
            get => Physics2D.Raycast(LedgeCheckHorizontal.position, Vector2.right * Core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
        }

        public bool LedgeVertical
        {
            get => Physics2D.Raycast(LedgeCheckVertical.position, Vector2.down, wallCheckDistance, whatIsGround);
        }
        
        public bool WallBack
        {
            get => Physics2D.Raycast(WallCheck.position, Vector2.right * -Core.Movement.FacingDirection, wallCheckDistance, whatIsGround);
        }
        #endregion
    }
}
