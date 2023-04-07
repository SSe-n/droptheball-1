using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadItem : MonoBehaviour
{
    private int item_count = 5;
    private int coin_data = 10000;
    private int selected = 0;

    [HideInInspector]
    public string skin_data = "";

    public Image prefab_skin;
    public GameObject content;
    public TextMeshProUGUI txt_coin;

    void Awake()
    {
        LoadData();

        //�ӽ� ������
       // skin_data = "01001";

        //���� ������ ǥ��
        txt_coin.text = coin_data.ToString();
        Debug.Log(coin_data);

        #region ��Ų �̹��� �ε�
        for (int i = 0; i < item_count; i++)
        {
            //�̹��� �ν��Ͻ�ȭ
            Image image = Instantiate(prefab_skin);
            image.sprite = Resources.Load<Sprite>("Skins/skin" + (i + 1)) as Sprite;
            GameObject padlock = image.transform.GetChild(0).gameObject;

            #region �ڹ��� ������
            if (skin_data[i] == '0')
            {
                padlock.SetActive(true);
            }
            else if (skin_data[i] == '1')
            {
                padlock.SetActive(false);
            }
            else
            {
                Debug.Log("Skin data error. Skin data : " + skin_data);
            }
            #endregion

            image.transform.SetParent(content.transform);
        }
        #endregion
    }

    public void LoadData()
    {
        #region ��Ų ������
        //��Ų ������ �ҷ�����
        if (PlayerPrefs.HasKey("Skin"))
        {
            skin_data = PlayerPrefs.GetString("Skin");
        }
        else
        {
            //������ �ʱ�ȭ
            for (int i = 0; i < item_count; i++)
            {
                skin_data += "0";
            }
        }

        // ������ ������ ������ ����Ǿ� �ִ� ������ ������ ������ ������ ���� �� �ʱ�ȭ
        if (skin_data.Length < item_count)
        {
            for (int i = skin_data.Length; i < item_count; i++)
            {
                skin_data += "0";
            }
        }
        #endregion

        #region ���� ������
        //���� ������ �ҷ�����
        if (PlayerPrefs.HasKey("Coin"))
        {
            coin_data = PlayerPrefs.GetInt("Coin");
        }
        #endregion
    }

    public void BuySkin()
    {
        //���õ� ������ ��ȣ �ҷ�����
        selected = content.GetComponent<SwipeItem>().selected;
        if (coin_data >= 100) //�ӽ� ����
        {
            //��Ų ������ ����
            var sd = skin_data.ToCharArray();
            sd[selected] = '1';
            skin_data = string.Concat(sd);

            //���� ������ ����
            coin_data -= 100;

            //������ ����
            PlayerPrefs.SetString("Skin", skin_data);
            PlayerPrefs.SetInt("Coin", coin_data);

            //��ư ���ΰ�ħ
            content.GetComponent<SwipeItem>().ShowBuyBtn(selected);
            //���õ� ������ �ڹ��� ��Ȱ��ȭ
            var image = content.transform.GetChild(selected);
            image.transform.GetChild(0).gameObject.SetActive(false);
            //���� ���ΰ�ħ
            txt_coin.text = coin_data.ToString();
        }

    }
}
