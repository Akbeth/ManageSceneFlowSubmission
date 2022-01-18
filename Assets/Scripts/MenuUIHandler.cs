using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour {

    public Text PlayerName;

    public Text BestScore;

    public void Start() {
        BestScore.text += " : " +  ScoreManager.Instance.BestScoreText;
    }

    public void UpdatePlayerName() {
        ScoreManager.Instance.PlayerName = PlayerName.text;
    }

    public void StartNew() {
        SceneManager.LoadScene(1);
    }

    public void Exit() {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
