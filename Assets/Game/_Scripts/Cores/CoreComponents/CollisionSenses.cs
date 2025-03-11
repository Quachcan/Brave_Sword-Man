using Game._Scripts.Generic;
using UnityEngine;

namespace Game._Scripts.Cores.CoreComponents
{
    public class CollisionSenses : CoreComponent
    {
        private Movement Movement => movement ?? Core.GetCoreComponent(ref movement);
        private Movement movement;
        
        #region CheckTransform
        
        public Transform GroundCheck 
        {
            get => GenericNotImplementedError<Transform>.TryGet(groundCheck, Core.transform.parent.name);
            private set => groundCheck = value; 
        }
        public Transform WallCheck 
        { 
            get => GenericNotImplementedError<Transform>.TryGet(wallCheck, Core.transform.parent.name);
            private set => wallCheck = value; 
        }
        public Transform LedgeCheckHorizontal 
        { 
            get => GenericNotImplementedError<Transform>.TryGet(ledgeCheckHorizontal, Core.transform.parent.name);
            private set => ledgeCheckHorizontal = value; 
        }
        public Transform LedgeCheckVertical
        {
            get  => GenericNotImplementedError<Transform>.TryGet(ledgeCheckVertical, Core.transform.parent.name);
            private set => ledgeCheckVertical = value;
        }
        public Transform CeilingCheck 
        { 
            get  => GenericNotImplementedError<Transform>.TryGet(ceilingCheck, Core.transform.parent.name);
            private set => ceilingCheck = value; 
        }
        
        public float GroundCheckRadius { get => groundCheckRadius;  set => groundCheckRadius = value; }
        public float WallCheckDistance { get => wallCheckDistance;  set => wallCheckDistance = value; }
        public LayerMask WhatIsGround { get => whatIsGround;  set => whatIsGround = value; }
        
        [SerializeField] private Transform groundCheck;
        [SerializeField] public Transform wallCheck;
        [SerializeField] private Transform ledgeCheckHorizontal;
        [SerializeField] private Transform ledgeCheckVertical;
        [SerializeField] private Transform ceilingCheck;
        
        [SerializeField] public float groundCheckRadius;
        [SerializeField] public float wallCheckDistance;
        
        [SerializeField] private LayerMask whatIsGround;
        #endregion
        
        
        #region Check Functions

        public bool Ground => Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, whatIsGround);

        public bool Ceiling => Physics2D.OverlapCircle(CeilingCheck.position, groundCheckRadius, whatIsGround);

        public bool WallFront => Physics2D.Raycast(WallCheck.position, Vector2.right * Movement.FacingDirection, wallCheckDistance, whatIsGround);

        public bool LedgeHorizontal => Physics2D.Raycast(LedgeCheckHorizontal.position, Vector2.right * Movement.FacingDirection, wallCheckDistance, whatIsGround);

        public bool LedgeVertical => Physics2D.Raycast(LedgeCheckVertical.position, Vector2.down, wallCheckDistance, whatIsGround);

        public bool WallBack => Physics2D.Raycast(WallCheck.position, Vector2.right * -Movement.FacingDirection, wallCheckDistance, whatIsGround);

        #endregion
    }
}
