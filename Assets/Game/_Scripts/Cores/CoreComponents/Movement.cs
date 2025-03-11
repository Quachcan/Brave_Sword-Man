using UnityEngine;

namespace Game._Scripts.Cores.CoreComponents
{
    public class Movement : CoreComponent
    {
        public Rigidbody2D Rb { get; private set; }
        public int FacingDirection { get; private set; }
        
        public bool CanSetVelocity { get; set; }
        public Vector2 CurrentVelocity { get; private set; }
        private Vector2 workSpace;

        protected override void Awake()
        {
            base.Awake();
            
            Rb = GetComponentInParent<Rigidbody2D>();
            FacingDirection = 1;
            CanSetVelocity = true;
        }

        public override void LogicUpdate()
        {
            CurrentVelocity = Rb.linearVelocity;
        }
        
        #region Set Functions
        public void SetVelocityZero()
        {
            workSpace = Vector2.zero;
            SetFinalVelocity();
        }
        public void SetVelocity(float velocity, Vector2 angle, int direction)
        {
            angle.Normalize();
            workSpace.Set(angle.x * velocity * direction, angle.y * velocity);
            SetFinalVelocity();
        }

        public void SetVelocity(float velocity, Vector2 direction)
        {
            workSpace = velocity * direction;
            SetFinalVelocity();
        }
        
        public void SetVelocityX(float velocity)
        {
            //Update new value for workSpace
            workSpace.Set(velocity, CurrentVelocity.y);   
            SetFinalVelocity();
        }

        public void SetVelocityY(float velocity)
        {
            //Update new value for workSpace
            workSpace.Set(CurrentVelocity.x, velocity);
            SetFinalVelocity();
        }

        public void SetFinalVelocity()
        {
            if(!CanSetVelocity)  return;
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
