﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace glitchout{
public class Level : MonoBehaviour{
    public static Level instance;
    GameSession gameSession;
    [SerializeField]ParticleSystem transition;
    [SerializeField]Animator transitioner;
    [SerializeField]float transitionTime=0.35f;
    //float prevGameSpeed;
    private void Awake()
    {
        if(FindObjectOfType<GameSession>()!=null){
        gameSession = FindObjectOfType<GameSession>();
        gameSession.gameSpeed=1f;
        }
        Time.timeScale = 1f;
        SetUpSingleton();
    }
    private void SetUpSingleton(){
        int numberOfObj = FindObjectsOfType<GameSession>().Length;
        if(numberOfObj > 1){
            Destroy(gameObject);
        }else{
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start(){
        instance=this;
        gameSession = FindObjectOfType<GameSession>();
        //transition=FindObjectOfType<Tag_Transition>().GetComponent<ParticleSystem>();
        //prevGameSpeed = gameSession.gameSpeed;
    }
    void Update()
    {
        gameSession = FindObjectOfType<GameSession>();
        //transition=FindObjectOfType<Tag_Transition>().GetComponent<ParticleSystem>();
        //transitioner=FindObjectOfType<Tag_Transition>().GetComponent<Animator>();
    }

    public void LoadStartMenu(){
        /*FindObjectOfType<GameSession>().SaveHighscore();
        FindObjectOfType<GameSession>().ResetScore();
        FindObjectOfType<SaveSerial>().Save();
        FindObjectOfType<GameSession>().ResetMusicPitch();*/
        FindObjectOfType<GameSession>().speedChanged=false;
        FindObjectOfType<GameSession>().gameSpeed=1f;
        SceneManager.LoadScene("Menu");
        //LoadLevel("Menu");
        //Time.timeScale = 1f;
        
        //FindObjectOfType<GameSession>().savableData.Save();
        //FindObjectOfType<SaveSerial>().Save();
    }
    public void LoadGameScene(){
        SceneManager.LoadScene("Game");
        GameSession.instance.resize=true;
        //LoadLevel("Game");
        FindObjectOfType<GameSession>().ResetScore();
        FindObjectOfType<GameSession>().gameSpeed=1f;
        Time.timeScale = 1f;
    }
    public void LoadOnlineMatchmakingScene(){SceneManager.LoadScene("OnlineMatchmaking");}
    public void LoadOptionsScene(){SceneManager.LoadScene("Options");}
    public void RestartGame(){
        //PauseMenu.GameIsPaused=false;
        /*FindObjectOfType<GameSession>().SaveHighscore();
        FindObjectOfType<GameSession>().ResetMusicPitch();*/
        FindObjectOfType<GameSession>().ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FindObjectOfType<GameSession>().gameSpeed=1f;
        Time.timeScale = 1f;
    }public void RestartScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameSession.gameSpeed=1f;
        Time.timeScale = 1f;
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void Restart(){
        SceneManager.LoadScene("Loading");
        gameSession.gameSpeed=1f;
        Time.timeScale = 1f;
    }

    void LoadLevel(string sceneName){
        //StartCoroutine(LoadTransition(sceneName));
        LoadTransition(sceneName);
    }
    void LoadTransition(string sceneName){
        //transition=FindObjectOfType<Tag_Transition>().GetComponent<ParticleSystem>();
        //transitioner=FindObjectOfType<Tag_Transition>().GetComponent<Animator>();
        
        //transition.Play();
        transitioner.SetTrigger("Start");

        //yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }

    public void OpenGameJolt(){
        Application.OpenURL("https://gamejolt.com/@HyperGamesDev");
    }
}
}