using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    [SerializeField] string sceneName;

    private void Start()
    {
        loadScene();
    }

    public void loadScene()
    {
        SceneManager.LoadScene(sceneName);
    }


}
