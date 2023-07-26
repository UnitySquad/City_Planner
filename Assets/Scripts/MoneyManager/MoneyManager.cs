using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Text money_text;
    public Text[] coin_text = new Text[5];

    int money;  //돈
    int rn_updown;  //랜덤 증감 상수
    int rn_per;     //랜덤 퍼센트 상수

    public class coin
    {
        public int coin_value;
        public int coin_count;

        public coin(int coin_value, int coin_count)
        {
            this.coin_value = coin_value;   //코인 가격
            this.coin_count = coin_count;   //코인 갯수
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

    void money_update()  //UI에 글자를 현재 돈으로 수정
    {
        money_text.text = "돈 : " + money.ToString();
    }

    public void random_coin()   //코인이 랜덤하게 증감
    {
        for(int i=0;i<5;i++)
        {
            rn_updown = Random.Range(1, 3);  //1부터 2까지

            if(rn_updown==1) //하락했을 경우
            {
                rn_per = Random.Range(1, 101); //1부터 100까지
                coins[i].coin_value = coins[i].coin_value * (100 - rn_per) / 100;
                coin_text[i].text = coins[i].coin_value + "\n\n" + "-" + rn_per.ToString() + "%";
            }
            else  //증가했을 경우
            {
                rn_per = Random.Range(1, 1001); //1부터 1000까지
                coins[i].coin_value = coins[i].coin_value * rn_per / 100;
                coin_text[i].text = coins[i].coin_value + "\n\n" + rn_per.ToString() + "%";
            }
        }
    }
}
