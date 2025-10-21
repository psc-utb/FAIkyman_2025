using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    InputAction menuAction;
    // Awake is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        menuAction = InputSystem.actions.FindAction("Menu");
        menuAction.performed += MenuAction_performed;
        menuLoaded = false;
    }

    bool menuLoaded;
    private void MenuAction_performed(InputAction.CallbackContext obj)
    {
        if (menuLoaded == false)
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
            menuLoaded = true;
            Time.timeScale = 0;
        }
        else
        {
            SceneManager.UnloadSceneAsync("Menu");
            menuLoaded = false;
            Time.timeScale = 1;
        }
    }

    //we need to delete connection to event in menu action
    private void OnDestroy()
    {
        menuAction.performed -= MenuAction_performed;
    }
}
