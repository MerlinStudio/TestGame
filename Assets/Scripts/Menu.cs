using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static Menu instance = null;

    [SerializeField] private GameObject MenuGameOver, MenuWon;
    [SerializeField] private Button[] Restart;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        Restart[0].onClick.AddListener(RestartScene);
        Restart[1].onClick.AddListener(RestartScene);
    }

    public void OpenMenuGameOver()
    {
        MenuGameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void OpenMenuWon()
    {
        MenuWon.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
