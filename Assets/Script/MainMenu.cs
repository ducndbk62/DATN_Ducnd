using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject UI_MainMenu;

    public GameObject UI_Setting;
    public GameObject UI_About;
    public GameObject UI_SelectMode;
    public Slider slider;

    public void OpenSelectMode()
    {
        UI_MainMenu.SetActive(false);
        UI_SelectMode.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Fight()
    {
        SceneManager.LoadScene("FightMode");

    }

    public void Practice()
    {
        SceneManager.LoadScene("PracticeMode");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        UI_About.SetActive(false);
        UI_Setting.SetActive(false);
        UI_SelectMode.SetActive(false);

        UI_MainMenu.SetActive(true);
    }

    public void OpenSetting()
    {
        UI_MainMenu.SetActive(false);
        UI_Setting.SetActive(true);
    }

    public void OpenAbout()
    {
        UI_MainMenu.SetActive(false);
        UI_About.SetActive(true);
    }

    public void SettingAudio()
    {
        AudioListener.volume = slider.value;
    }
}