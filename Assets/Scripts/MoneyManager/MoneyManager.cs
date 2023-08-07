using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Text money_text;
    public Text[] coin_name_text = new Text[5];     //보여주는 이름
    public Text[] coin_value_text = new Text[5];    //보여주는 돈
    public Text[] coin_per_text = new Text[5];      //보여주는 퍼센트
    public Text[] coin_count_text = new Text[5];    //보여주는 코인 개수

    int money;  //돈
    int rn_updown;  //랜덤 증감 상수
    int rn_per;     //랜덤 퍼센트 상수

    List<string> coin_name_list = new List<string>() { "루나", "도지", "솔라", "시바", "비트", "정기", "나토", "나사",
    "바보","석류","레드","블루","그린","육성","오성","사성","이성","일성","리얼","폭스","래빗"};

    public class coin
    {
        public int coin_value;
        public int coin_count;
        public string coin_name;

        public coin(int coin_value, int coin_count, string coin_name)
        {
            this.coin_value = coin_value;   //코인 가격
            this.coin_count = coin_count;   //코인 개수
            this.coin_name = coin_name;     //코인 이름
        }
    }

    coin[] coins = new coin[]
    {
        new coin(5000,0,"없"),
        new coin(5000,0,"없"),
        new coin(5000,0,"없"),
        new coin(5000,0,"없"),
        new coin(5000,0,"없")
    };

    void Start()
    {
        money = 50000000;
        money_update();
        change_coin(0);
        change_coin(1);
        change_coin(2);
        change_coin(3);
        change_coin(4);
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

            if(coins[i].coin_value == 0)
            {
                coins[i].coin_value = 5000;
                coin_value_text[i].text = coins[i].coin_value.ToString();
                change_coin(i);
                coin_per_text[i].text = "0%";
            }
            else if(rn_updown==1) //하락했을 경우
            {
                rn_per = Random.Range(1, 101); //1부터 100까지
                coins[i].coin_value = coins[i].coin_value * (100 - rn_per) / 100;
                coin_value_text[i].text = coins[i].coin_value.ToString();
                coin_per_text[i].text = "-" + rn_per.ToString() + "%";
            }
            else  //증가했을 경우
            {
                rn_per = Random.Range(1, 301); //1부터 300까지
                coins[i].coin_value = coins[i].coin_value * rn_per / 100;
                coin_value_text[i].text = coins[i].coin_value.ToString();
                coin_per_text[i].text = rn_per.ToString() + "%";
            }

            if(coins[i].coin_value <= 100)  //상장 폐지
            {
                coins[i].coin_value = 0;
                coin_value_text[i].text = coins[i].coin_value.ToString();
                coins[i].coin_count = 0;
                coin_count_text[i].text = coins[i].coin_value.ToString();
            }
        }
    }

    public void buy_coin(int coin_num)  //코인을 산다
    {
        if(money>=coins[coin_num].coin_value && coins[coin_num].coin_value != 0)
        {
            money -= coins[coin_num].coin_value;
            money_update();
            coins[coin_num].coin_count++;
            coin_count_text[coin_num].text = coins[coin_num].coin_count.ToString();
        }
    }

    public void sell_coin(int coin_num) //코인을 판다
    {
        if(coins[coin_num].coin_count>0)
        {
            coins[coin_num].coin_count--;
            coin_count_text[coin_num].text = coins[coin_num].coin_count.ToString();
            money += coins[coin_num].coin_value;
            money_update();
        }
    }

    public void change_coin(int coin_num)   //이름을 랜덤으로 리셋
    {
        int tmp_name = Random.Range(0, coin_name_list.Count);
        coins[coin_num].coin_name = coin_name_list[tmp_name];
        coin_name_text[coin_num].text = coins[coin_num].coin_name;
        coin_name_list.RemoveAt(tmp_name);
    }
}
