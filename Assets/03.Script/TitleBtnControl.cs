using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleBtnControl : MonoBehaviour
{
    public void StartBtn()
    {
        SceneManager.LoadScene(1);
    }
}
