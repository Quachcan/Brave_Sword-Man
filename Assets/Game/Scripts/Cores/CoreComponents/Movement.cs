using UnityEngine;

namespace Game.Scripts.Cores.CoreComponents
{
    public class Movement : CoreComponent
    {
        public Rigidbody2D Rb { get; private set; }
        public int FacingDirection { get; private set; }
        public Vector2 CurrentVelocity { get; private set; }
        private Vector2 workSpace;

        protected override void Awake()
        {
            base.Awake();
            
            Rb = GetComponentInParent<Rigidbody2D>();
            FacingDirection = 1;
        }

        public void LogicUpdate()
        {
            CurrentVelocity = Rb.linearVelocity;
        }
        
        #region Set Functions
        public void SetVelocityZero()
        {
            Rb.linearVelocity = Vector2.zero;
            CurrentVelocity = Vector2.zero;
        }
        public void SetVelocity(float velocity, Vector2 angle, int direction)
        {
            angle.Normalize();
            workSpace.Set(angle.x * velocity * direction, angle.y * velocity);
            Rb.linearVelocity = workSpace;
            CurrentVelocity = workSpace;
        }

        public void SetVelocity(float velocity, Vector2 direction)
        {
            workSpace = velocity * direction;
            Rb.linearVelocity = workSpace;
            CurrentVelocity = workSpace;
        }
        
        public void SetVelocityX(float velocity)
        {
            //Update new value for workSpace
            workSpace.Set(velocity, CurrentVelocity.y);   
            Rb.linearVelocity = workSpace;
            CurrentVelocity = workSpace;
        }

        public void SetVelocityY(float velocity)
        {
            //Update new value for workSpace
            workSpace.Set(CurrentVelocity.x, velocity);
            Rb.linearVelocity = workSpace;
            CurrentVelocity = workSpace;
        }
        
        public void CheckIfShouldFlip(int xInput)
        {
            if (xInput != 0 && xInput != FacingDirection)
            {
                Flip();
            }
        }
        
        public void Flip()
        {
            FacingDirection *= -1;
            Rb.transform.Rotate(0f, 180f, 0f);
        }
        #endregion
        
    }
}
