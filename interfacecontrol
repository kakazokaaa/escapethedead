using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interface Control : MonoBehaviour {

    private PlayerControl scriptPlayerControl;
    public Slider SliderPlayerLife;
    public GameObject GameOverPanel;
    public Text TextSurvivalTime;
    public Text TextMaxScore;
    private float timeSavedScore;
    private int amountDeadZombies;
    public Text TextAmountDeadZombies;
    public Text TextBossSpawns;

	// Use this for initialization
	void Start () {
        scriptPlayerControl = GameObject.FindWithTag("Player")
                                .GetComponent<PlayerControl>();

        SliderPlayerLife.maxValue = scriptPlayerLife.playerStatus.Life;
        UpdateSliderPlayerLife();
        Time.timeScale = 1;
        timeSavedScored = PlayerPrefs.GetFloat("MaxScore");
    }

    public void UpdateSliderPlayerLife ()
    {
        SliderPlayerLife.value = scriptPlayerControl.playerStatus.Life;
    }

    public void UpdateAmountDeadZombies()
    {
        amountDeadZombies++;
        TextAmountDeadZombies.text = string.Format("x {0}", amountDeadZombies);
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;

        int minutes = (int)(Time.timeSinceLevelLoad / 60);
        int seconds = (int)(Time.timeSinceLevelLoad % 60);
        TextoSurvivalTime.text = "Você sobreviveu por " + minutos + "min e " + segundos + "s";

        AdjustMaxScore(minutes, seconds);
    }

    void AdjustMaxScore(int min, int sec)
    {
        if(Time.timeSinceLevelLoad > timeSavedScored)
        {
            timeSavedScore = Time.timeSinceLevelLoad;
            TextMaxScore.text = string.Format("Seu melhor tempo é {0}min e {1}s", min, sec);
            PlayerPrefs.SetFloat("MaxScore", timeSavedScore);
        }
        if(TextMaxScore.text =="")
        {
            min = (int)timeSavedScore / 60;
            sec = (int)timeSavedScore % 60;
            TextMaxScore.text = string.Format("Seu melhor tempo é {0}min e {1}s", min, sec);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void ShowBossSpawnsText()
    {
        StartCoroutine(VanishText(2, TextBossSpawns));
    }

    IEnumerator VanishText(float vanishTime, Text vanishText)
    {
        vanishText.gameObject.SetActive(true);
        Color textColor = vanishText.color;
        textColor.a = 1;
        vanishText.color = textColor;
        yield return new WaitForSeconds(1);
        float counter = 0;
        while(vanishText.color.a > 0)
        {
            counter += Time.deltaTime / vanishTime;
            textColor.a = Mathf.Lerp(1, 0, counter);
            vanishText.color = textColor;
            if(vanishText.color.a <= 0)
            {
                vanishText.gameObject.SetActive(false);
            }
            yield return null;
        }
    }
}
