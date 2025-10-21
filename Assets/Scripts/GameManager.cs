using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public /*async*/ void StartGame()
    {
        Time.timeScale = 1;
        //await SceneManager.UnloadSceneAsync("Level1", UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

}
