using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject uI_MainMenu;

    public GameObject uI_Setting;
    public GameObject uI_About;
    public GameObject uI_SelectLevel;
    public Slider volumeSlider;

    public void OpenSelectLevel()
    {
        uI_MainMenu.SetActive(false);
        uI_SelectLevel.SetActive(true);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Fight()
    {
        int test = 1;
        SceneManager.LoadScene(test.ToString());
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        uI_About.SetActive(false);
        uI_Setting.SetActive(false);
        uI_SelectLevel.SetActive(false);

        uI_MainMenu.SetActive(true);
    }

    public void OpenSetting()
    {
        uI_MainMenu.SetActive(false);
        uI_Setting.SetActive(true);
    }

    public void OpenAbout()
    {
        uI_MainMenu.SetActive(false);
        uI_About.SetActive(true);
    }

    public void SettingAudio()
    {
        AudioListener.volume = volumeSlider.value;
    }
}