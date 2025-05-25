using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class TopPanel : MonoBehaviour
{
    public GameObject sceneTransition;
    public void ReturnToHomeScreen()
    {
        StartCoroutine(ChangeScene("MainMenu"));
    }
    private IEnumerator ChangeScene(string sceneName)
    {
        Instantiate(sceneTransition, transform.position, transform.rotation);
        yield return new WaitForSeconds(.3f);
        SceneManager.LoadScene(sceneName);
    }
    
}
