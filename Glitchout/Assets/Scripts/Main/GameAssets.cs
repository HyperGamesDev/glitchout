﻿using System;
using UnityEngine;

public class GameAssets : MonoBehaviour{
//GameAssets.instance.Make("",);
//GameAssets.instance.Get("");
//GameAssets.instance.Spr("");
    public static GameAssets instance;
	public GObject[] objects;
	public GObject[] vfx;
	public GSprite[] sprites;
	public Sprite[] skins;
    
    void Awake(){if(instance!=null){Destroy(gameObject);}else{instance=this;DontDestroyOnLoad(gameObject);}}

    public GameObject Make(string obj, Vector2 pos){
		GObject o = Array.Find(objects, item => item.name == obj);
        GameObject gobj=o.gobj;
		if (o == null){
			Debug.LogWarning("Object: " + name + " not found!");
			return null;
		}
        GameObject objref = Instantiate(gobj,pos,Quaternion.identity);
        return objref;
	}
    public GameObject VFX(string obj, Vector2 pos, float duration){
		GObject o = Array.Find(vfx, item => item.name == obj);
        GameObject gobj=o.gobj;
		if (o == null){
			Debug.LogWarning("Object: " + name + " not found!");
			return null;
		}
        GameObject objref = Instantiate(gobj,pos,Quaternion.identity);
		Destroy(objref,duration);
        return objref;
	}
    public GameObject Get(string obj){
		GObject o = Array.Find(objects, item => item.name == obj);
        GameObject gobj=o.gobj;
		if (o == null){
			Debug.LogWarning("Object: " + name + " not found!");
			return null;
		}
        return gobj;
	}public GameObject GetVFX(string obj){
		GObject o = Array.Find(vfx, item => item.name == obj);
        GameObject gobj=o.gobj;
		if (o == null){
			Debug.LogWarning("Object: " + name + " not found!");
			return null;
		}
        return gobj;
	}

    public Sprite Spr(string spr){
		GSprite s = Array.Find(sprites, item => item.name == spr);
        Sprite gs=s.spr;
		if (s == null){
			Debug.LogWarning("Sprite: " + name + " not found!");
			return null;
		}
        return gs;
	}
    public Sprite GetSkin(int i){
		Sprite s = skins[i];
		if (s == null){
			Debug.LogWarning("Skin: " + name + " not found!");
			return null;
		}
        return s;
	}
}


[System.Serializable]
public class GObject {

	public string name;

	public GameObject gobj;
}

[System.Serializable]
public class GSprite {

	public string name;

	public Sprite spr;
}
