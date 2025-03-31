using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game._Scripts.Manager
{
    public class SceneLoader : MonoBehaviour
    {
        private void Awake()
        {
            SceneManager.LoadScene("Map_2", LoadSceneMode.Additive);
            SceneManager.LoadScene("Map_3", LoadSceneMode.Additive);
        }
    }
}
