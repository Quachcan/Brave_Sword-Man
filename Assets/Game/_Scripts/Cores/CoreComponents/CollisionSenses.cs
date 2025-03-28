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
        [SerializeField] public float ceilingCheckRadius;
        
        [SerializeField] private LayerMask whatIsGround;
        #endregion
        
        
        #region Check Functions

        public bool Ground => Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, whatIsGround);

        public bool Ceiling => Physics2D.OverlapCircle(CeilingCheck.position, ceilingCheckRadius, whatIsGround);

        public bool WallFront => Physics2D.Raycast(WallCheck.position, Vector2.right * Movement.FacingDirection, wallCheckDistance, whatIsGround);

        public bool LedgeHorizontal => Physics2D.Raycast(LedgeCheckHorizontal.position, Vector2.right * Movement.FacingDirection, wallCheckDistance, whatIsGround);

        public bool LedgeVertical => Physics2D.Raycast(LedgeCheckVertical.position, Vector2.down, wallCheckDistance, whatIsGround);

        public bool WallBack => Physics2D.Raycast(WallCheck.position, Vector2.right * -Movement.FacingDirection, wallCheckDistance, whatIsGround);

        #endregion

        #region Gizmos
        // private void OnDrawGizmos()
        // {
        //     if (GroundCheck != null)
        //     {
        //         Gizmos.color = Color.green;
        //         Gizmos.DrawWireSphere(GroundCheck.position, groundCheckRadius);
        //     }
        //     
        //     if (CeilingCheck != null)
        //     {
        //         Gizmos.color = Color.blue;
        //         Gizmos.DrawWireSphere(CeilingCheck.position, ceilingCheckRadius);
        //     }
        //
        //     if (wallCheck != null && Movement != null)
        //     {
        //         Gizmos.color = Color.red;
        //         Vector3 start = wallCheck.position;
        //         Vector3 end = start + (Vector3)(Vector2.right * Movement.FacingDirection * wallCheckDistance);
        //         Gizmos.DrawLine(start, end);
        //     }
        //     
        //     if (ledgeCheckHorizontal != null && Movement != null)
        //     {
        //         Gizmos.color = Color.yellow;
        //         Vector3 start = ledgeCheckHorizontal.position;
        //         Vector3 end = start + (Vector3)(Vector2.right * Movement.FacingDirection * wallCheckDistance);
        //         Gizmos.DrawLine(start, end);
        //     }
        //     
        //     if (ledgeCheckVertical != null)
        //     {
        //         Gizmos.color = Color.magenta;
        //         Vector3 start = ledgeCheckVertical.position;
        //         Vector3 end = start + (Vector3)(Vector2.down * wallCheckDistance);
        //         Gizmos.DrawLine(start, end);
        //     }
        //     
        //     if (wallCheck != null && Movement != null)
        //     {
        //         Gizmos.color = Color.cyan;
        //         Vector3 start = wallCheck.position;
        //         Vector3 end = start + (Vector3)(Vector2.right * -Movement.FacingDirection * wallCheckDistance);
        //         Gizmos.DrawLine(start, end);
        //     }
        // }
        
        #endregion
        
    }
}
