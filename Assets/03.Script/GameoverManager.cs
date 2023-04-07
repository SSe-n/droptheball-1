using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverManager : MonoBehaviour
{
    public GameObject gameover;
    public TextMeshProUGUI score;
    public TextMeshProUGUI coin;
    public GameObject highscore;
    private void OnCollisionEnter(Collision collision)
    {
        gameover.SetActive(true);
        //�Ͻ�����
        Time.timeScale = 0;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SfxPlay(SoundManager.Sfx.GameOver);

        float s = RuleManager._instance._score;
        score.text = s.ToString();
        //����
        coin.text = Mathf.Floor(s / 100).ToString();

        //ó���ϴ� ��������
        PlayerPrefs.SetInt("IsFirst", 1); ;

        #region �ְ� ���� ����
        if (PlayerPrefs.HasKey("HighScore"))
        {
            int hs = PlayerPrefs.GetInt("HighScore");
            Debug.Log("high score : " + hs);
            if (s > hs)
            {
                PlayerPrefs.SetInt("HighScore", (int)s);
                gameover.GetComponent<Animator>().SetTrigger("highScore");
            }
            else
            {
                highscore.SetActive(false);
            }
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", (int)s);
            gameover.GetComponent<Animator>().SetTrigger("highScore");
        }
        #endregion

        #region ���� ȹ��
        if (PlayerPrefs.HasKey("Coin"))
        {
            int coin = PlayerPrefs.GetInt("Coin");
            coin += (int)Mathf.Floor(s / 100);
            PlayerPrefs.SetInt("Coin", coin);
        }
        else
        {
            Mathf.Floor(s / (int)Mathf.Floor(s / 100));
        }
        #endregion
    }

    public void Restart()
    {
        Time.timeScale = 1;
        GameObject.Find("SoundManager").GetComponent<SoundManager>().SfxPlay(SoundManager.Sfx.Button);
        SceneManager.LoadScene(1);
    }
}
