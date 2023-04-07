using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RuleManager : MonoBehaviour
{
    public static RuleManager _instance;
    /// <summary>
    /// ��ŲŸ��
    /// </summary>
    public enum BallType
    {
        Balls = 0,
        sdfS
    }
    public static int _maxLevel = 8;            // ���� �ִ� ����
    public BallType _ballType;                  // ���� Ÿ��
    public List<GameObject> _balls;               // ���� ���۽� ���� ��Ų�� ��Ƽ����
    public static float _reloadTime = 0.5f;        // ���� ���� �ð�
    public int _score;
    // �ӽ�
    private void Awake()
    {
        _instance = this;
        GameObject[] go = Resources.LoadAll<GameObject>(_ballType.ToString());
        for (int i = 0; i < go.Length; i++)
        {
            _balls.Add(go[i]);
        }
    }

    public void Pause(int t)
    {
        Time.timeScale = t;
    }

}
