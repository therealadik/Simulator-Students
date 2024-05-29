using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadingScene(sceneName));
    }

    private IEnumerator LoadingScene(string sceneName) 
    {
        animator.SetBool("isBlack", false);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        yield return new WaitForSeconds(1);
        asyncOperation.allowSceneActivation = true;
    }
}
