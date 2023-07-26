using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Text money_text;
    public Text[] coin_text = new Text[5];

    int money;  //��
    int rn_updown;  //���� ���� ���
    int rn_per;     //���� �ۼ�Ʈ ���

    public class coin
    {
        public int coin_value;
        public int coin_count;

        public coin(int coin_value, int coin_count)
        {
            this.coin_value = coin_value;   //���� ����
            this.coin_count = coin_count;   //���� ����
        }
    }

    coin[] coins = new coin[]
    {
        new coin(5000,0),
        new coin(5000,0),
        new coin(5000,0),
        new coin(5000,0),
        new coin(5000,0)
    };

    void Start()
    {
        money = 5000;
        money_update();
    }

    void money_update()  //UI�� ���ڸ� ���� ������ ����
    {
        money_text.text = "�� : " + money.ToString();
    }

    public void random_coin()   //������ �����ϰ� ����
    {
        for(int i=0;i<5;i++)
        {
            rn_updown = Random.Range(1, 3);  //1���� 2����

            if(rn_updown==1) //�϶����� ���
            {
                rn_per = Random.Range(1, 101); //1���� 100����
                coins[i].coin_value = coins[i].coin_value * (100 - rn_per) / 100;
                coin_text[i].text = coins[i].coin_value + "\n\n" + "-" + rn_per.ToString() + "%";
            }
            else  //�������� ���
            {
                rn_per = Random.Range(1, 1001); //1���� 1000����
                coins[i].coin_value = coins[i].coin_value * rn_per / 100;
                coin_text[i].text = coins[i].coin_value + "\n\n" + rn_per.ToString() + "%";
            }
        }
    }
}
