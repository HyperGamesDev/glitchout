﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkin : MonoBehaviour{
    public int playerID=-1;
    public int skinID;
    IEnumerator Start(){
        if(playerID==-1)Debug.Log("Player ID not set");
        if(GetComponent<Image>()!=null){//Set SkinID from Player
            foreach(Player player in FindObjectsOfType<Player>()){if(player.playerNum==this.playerID){this.skinID=player.GetComponent<PlayerSkin>().skinID;}}
        }
        //Set skinID from current sprite
        string[] num=new string[2];
        if(GetComponent<SpriteRenderer>()!=null)num=GetComponent<SpriteRenderer>().sprite.name.Split('r');
        if(GetComponent<Image>()!=null)num=GetComponent<Image>().sprite.name.Split('r');
        if(num!=null&&num.Length>=2)skinID=int.Parse(num[1]);

        
        GameSession.instance.speedChanged=true;
        GameSession.instance.gameSpeed=0;
        yield return new WaitForSecondsRealtime(0.005f);
    }
    void Update(){
        if(skinID>=0&&skinID<GameAssets.instance.skins.Length){
            if(GetComponent<Player>()!=null){//Set SkinID for Player from config
                foreach(PlayerSkin skin in FindObjectsOfType<PlayerSkin>()){if(skin.playerID==GetComponent<Player>().playerNum){GetComponent<PlayerSkin>().skinID=skin.skinID;}}
            }

            if(GetComponent<SpriteRenderer>()!=null)GetComponent<SpriteRenderer>().sprite=GameAssets.instance.GetSkin(skinID);
            if(GetComponent<Image>()!=null)GetComponent<Image>().sprite=GameAssets.instance.GetSkin(skinID);
        }
    }
    public void SkinPrev(){foreach(PlayerSkin s in transform.root.GetComponentsInChildren<PlayerSkin>()){if(s.playerID!=this.playerID){
        if(skinID>0){
            if(s.skinID!=skinID-1){skinID--;}else if(s.skinID==skinID-1&&skinID>1){skinID-=2;}
        }else if(skinID==0){//Wrap skins outside and dont allow the same one
            skinID=GameAssets.instance.skins.Length-1;for(;s.skinID==skinID&&skinID>0;skinID--);
        }
    }}}
    public void SkinNext(){foreach(PlayerSkin s in transform.root.GetComponentsInChildren<PlayerSkin>()){if(s.playerID!=this.playerID){
        if(skinID<GameAssets.instance.skins.Length-1){
            if(s.skinID!=skinID+1){skinID++;}else if(s.skinID==skinID+1&&skinID<GameAssets.instance.skins.Length-2){skinID+=2;}
        }else if(skinID==GameAssets.instance.skins.Length-1){//Wrap skins outside and dont allow the same one
            skinID=0;for(;s.skinID==skinID;skinID++);
        }
    }}}
}