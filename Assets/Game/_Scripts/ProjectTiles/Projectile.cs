using System;
using Game._Scripts.Cores.CoreComponents;
using UnityEngine;

namespace Game._Scripts.ProjectTiles
{
    public class Projectile : MonoBehaviour
    {
        private float speed;
        private float travelDistance;
        private float damage;
        private float xStartPos;
        
        [SerializeField] private float gravity;
        [SerializeField] private float damageRadius;

        private bool isGravityOn;
        private bool hasHitGrounded; 
        
        private Rigidbody2D rb;
        
        [SerializeField] private LayerMask whatIsGround;
        [SerializeField] private LayerMask whatIsPlayer;
        [SerializeField] private Transform damagePosition;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            
            rb.gravityScale = 0.0f;
            rb.linearVelocity = transform.right * speed;
            
            isGravityOn = false;
            
            xStartPos = transform.position.x;
        }

        private void Update()
        {
            if (!hasHitGrounded)
            {
                if (isGravityOn)
                {
                    float angle = Mathf.Atan2(rb.linearVelocity.y, rb.linearVelocity.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                }
            }
        }

        private void FixedUpdate()
        {
            if (!hasHitGrounded)
            {
                Collider2D damageHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsPlayer);
                Collider2D groundHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsGround);

                if (damageHit)
                {
                    Combat targetHit = damageHit.GetComponent<Combat>();
                    if (targetHit != null)
                    {
                        targetHit.Damage(damage);
                        Destroy(gameObject);
                    }
                }
                

                if (groundHit)
                {
                    isGravityOn = true;
                    rb.gravityScale = 0f;
                    rb.linearVelocity = Vector2.zero;
                }
                
                if (Mathf.Abs(xStartPos - transform.position.x) >= travelDistance && !isGravityOn)
                {
                    isGravityOn = true;
                    rb.gravityScale = gravity;
                }   
            }
        }

        public void FireProjectile(float speed, float distance, float damage)
        {
            this.speed = speed;
            this.travelDistance = distance;
            this.damage = damage;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(damagePosition.position, damageRadius);
        }
    }
}

