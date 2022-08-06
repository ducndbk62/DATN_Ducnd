using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILevelController : MonoBehaviour
{
    public Image background;
    public Text number;

    public Color darkColor;

    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() => SceneManager.LoadScene(number.text));
    }

    public void LockLevel()
    {
        this.GetComponent<Button>().enabled = false;
        background.color = darkColor;
        number.color = darkColor;
    }

    public void UnlockLevel()
    {
        this.GetComponent<Button>().enabled = true;
        background.color = Color.white;
        number.color = Color.white;
    }
}
