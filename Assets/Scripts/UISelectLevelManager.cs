using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UISelectLevelManager : MonoBehaviour
{
    public GameObject[] uiLevelList;
    public Scene[] sceneLevelList;

    private int levelProgress;

    // Start is called before the first frame update
    void Start()
    {
        levelProgress = PlayerPrefs.GetInt("LevelProgress", 1);
        UnlockToCurrentLevel();
    }


    private void UnlockToCurrentLevel()
    {
        for (int i = 0; i < levelProgress; i++)
        {
            uiLevelList[i].GetComponent<UILevelController>().UnlockLevel();
        }
        for (int i = levelProgress; i < uiLevelList.Length; i++)
        {
            uiLevelList[i].GetComponent<UILevelController>().LockLevel();
        }
    }
}
