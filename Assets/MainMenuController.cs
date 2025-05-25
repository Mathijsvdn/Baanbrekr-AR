using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadScene1()
    {
        SceneManager.LoadScene("ARclicking");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("ARmoving");
    }
}

