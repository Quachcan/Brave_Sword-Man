using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleEntranceToVillage : MonoBehaviour
{
 [SerializeField]
    string sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneController.Instance.LoadScene(sceneName);
        }
    }
}
