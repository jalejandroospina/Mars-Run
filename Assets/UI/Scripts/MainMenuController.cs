using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{
    [SerializeField] private InputField startButton;
    [SerializeField] private InputField backButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void OnClickMainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnClickPlayAgainButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnClickBackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickControlButton()
    {
        SceneManager.LoadScene("ControllersMenu");
    }

    public void OnClickCreditsButton()
    {
        SceneManager.LoadScene("CreditsMenu");
    }

}
