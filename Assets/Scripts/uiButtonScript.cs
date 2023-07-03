using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiButtonScript : MonoBehaviour
{

    int sceneIndex = 1;

    public GameObject[] Buttons;

    public void PlayButton()
    {
        Debug.Log("Play");
    }

    public void LeftButton()
    {
        sceneIndex -= 1;
        if (sceneIndex == 0)
        {
            sceneIndex = 4;
        }
        SceneManager();
    }
    public void RightButton()
    {
        sceneIndex += 1;
        if(sceneIndex == 5)
        {
            sceneIndex = 1;
        }
        SceneManager();
    }



    // Start is called before the first frame update
    void Start()
    {
        SceneManager();
    }
    
    
    
    void DisableSceneSpecific()
    {
        foreach (GameObject i in Buttons)
        {
            i.SetActive(false);
        }
    }

    void SceneManager()
    {
        switch (sceneIndex)
        {
            case 1:
                Debug.Log("Play");
                DisableSceneSpecific();
                Buttons[0].SetActive(true);
                break;
            case 2:
                Debug.Log("Kitchen");
                DisableSceneSpecific();
                Buttons[1].SetActive(true);
                break;
            case 3:
                Debug.Log("Toilet");
                DisableSceneSpecific();
                Buttons[2].SetActive(true);
                Buttons[3].SetActive(true);
                break;
            case 4:
                Debug.Log("Sleep Area");
                DisableSceneSpecific();
                Buttons[4].SetActive(true);
                break;
            default:
                DisableSceneSpecific();
        break;
        }
    }


}
