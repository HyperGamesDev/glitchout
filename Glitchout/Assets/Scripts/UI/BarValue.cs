﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace glitchout{
public enum barType{
    HorizontalR,
    HorizontalL,
    VerticalU,
    VerticalD,
    Fill
}
public class BarValue : MonoBehaviour{
    [SerializeField] barType barType=barType.HorizontalR;
    [SerializeField] string valueName;
    [SerializeField] float value;
    //[SerializeField] string maxValueName;
    [SerializeField] float maxValue;
    public Player[] players;
    void Start(){
        Array.Resize(ref players,FindObjectsOfType<Player>().Length);
    }

    void Update(){
        Array.Resize(ref players,FindObjectsOfType<Player>().Length);
        Player[] allPlayers=FindObjectsOfType<Player>();
        foreach(Player player in allPlayers){
            //if(player.playerNum==playerNum.One){player1=player;}
            //if(player.playerNum==playerNum.Two){player2=player;}
            //if(player.playerNum==0){player1=player;}
            //if(player.playerNum==1){player2=player;}
            //Array.Resize(ref players,allPlayers.Length);
            players[player.playerNum]=player;
        }
        //if(valueName=="health_p1"){value=player1.health;maxValue=player1.maxHealth;}
        //if(valueName=="health_p2"){value=player2.health;maxValue=player2.maxHealth;}
        if(valueName.Contains("health_")){string[] x=valueName.Split('_');int xx=int.Parse(x[1]);if(players[xx].hidden!=true){value=players[xx].health;maxValue=players[xx].maxHealth;}else{value=GameSession.instance.respawnTimer[xx]; maxValue=GameSession.instance.respawnTime;}} 
        if(valueName.Contains("score_")){string[] x=valueName.Split('_');int xx=int.Parse(x[1]);value=GameSession.instance.score[xx];maxValue=GameSession.instance.score[xx];}

        if(barType==barType.HorizontalR){transform.localScale=new Vector2(value/maxValue,transform.localScale.y);}
        if(barType==barType.HorizontalL){transform.localScale=new Vector2(-(value/maxValue),transform.localScale.y);}
        if(barType==barType.VerticalU){transform.localScale=new Vector2(transform.localScale.x,-(value/maxValue));}
        if(barType==barType.VerticalD){transform.localScale=new Vector2(transform.localScale.x,value/maxValue);}
        if(barType==barType.Fill){GetComponent<Image>().fillAmount=value/maxValue;}
    }
}
}