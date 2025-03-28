using System;
using Game._Scripts.Manager;
using UnityEngine;

namespace Game._Scripts.CheckPoint
{
    public class CheckPoint : MonoBehaviour
    {
        [Header("Srpites")]
        [SerializeField] private Animator animator;
        [SerializeField] private string isActivateParam = "IsActivated";
        
        [Header("Settings")]
        [SerializeField] private AudioClip activatedSrpiteSound;
        
        private SpriteRenderer spriteRenderer;
        private bool isActivated;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                EnemyManager.Instance.RespawnEnemy();
                if (!isActivated)
                {
                    ActivateCheckPoint();
                }
            }
        }

        private void ActivateCheckPoint()
        {
            isActivated = true;

            if (animator != null)
            {
                animator.SetBool(isActivateParam, true);
            }

            if (activatedSrpiteSound != null)
            {
                //AudioSource.PlayClipAtPoint(activatedSrpiteSound, transform.position);
            }
            
            Debug.Log("CheckPoint activated");
        }
    }
}
