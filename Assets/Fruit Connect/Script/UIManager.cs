
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public GameObject Loading;
    public GameObject Menu;
    public GameObject Setting;
    public GameObject Rule;
    public GameObject Level;
    public GameObject GamePlay;
    public GameObject Win;
    public GameObject Loss;
    public GameObject GeneraterLevel;


    public List<GameObject> AllScreen;
    public List<GameObject> levels;

    public int Wincount;
    public int currentLevel;

    Coroutine coroutine;

    public Text winTimeText;
    public Text gameTimeText;


    public List<LineRenderer> GeneratedLineRendere;
    public bool isWin;

    private void Awake() {
        Instance = this;

        if (PlayerPrefs.HasKey("currentLevel")) {
            currentLevel = PlayerPrefs.GetInt("currentLevel");
            Debug.Log("currentLevel == " + currentLevel);
        }
    }
    private void OnEnable() {
        StartCoroutine(OpenLoading());
    }

    public void GenerateLevel(int levelNumber) {

        DestroyLine();
        if (GeneraterLevel != null) {
            Destroy(GeneraterLevel);
            /*GeneratedLineRendere.ForEach(x => Destroy(x.gameObject));
        GeneratedLineRendere.Clear();*/
        }
        currentLevel = levelNumber;
        PlayerPrefs.SetInt("currentLevel", currentLevel);
        Wincount = 0;
        gameTimeText.text = "30 Sec";
        OpenGame();
        GeneraterLevel = Instantiate(levels[levelNumber]);
        coroutine = StartCoroutine(GameCountDown(80));
    }

    public IEnumerator OpenLoading() {
        AllScreen.ForEach(x => x.SetActive(false));
        Loading.SetActive(true);

        yield return new WaitForSecondsRealtime(2f);
        OpenMenu();
    }
    public void OpenLevel() {
        if (coroutine != null)
            StopCoroutine(coroutine);

        DestroyLine();

        if (GeneraterLevel != null) {
            Destroy(GeneraterLevel);
            /*GeneratedLineRendere.ForEach(x => Destroy(x.gameObject));
            GeneratedLineRendere.Clear();*/
        }

        Win.SetActive(false);
        Loss.SetActive(false);
        AllScreen.ForEach(x => x.SetActive(false));
        Level.SetActive(true);
    }

    public void OpenMenu() {
        if (coroutine != null)
            StopCoroutine(coroutine);
        DestroyLine();

        if (GeneraterLevel != null) {
            Destroy(GeneraterLevel);
            /*GeneratedLineRendere.ForEach(x => Destroy(x.gameObject));
            GeneratedLineRendere.Clear();*/
        }
        AllScreen.ForEach(x => x.SetActive(false));
        Menu.SetActive(true);
    }

    public void OpenGame() {
        if (GeneraterLevel != null) {
            GeneraterLevel.SetActive(true);
        }
        AllScreen.ForEach(x => x.SetActive(false));
        GamePlay.SetActive(true);
    }

    public void OpenSetting() {

        if (GeneraterLevel != null) {
            GeneraterLevel.SetActive(false);
        }
        AllScreen.ForEach(x => x.SetActive(false));
        Setting.SetActive(true);
    }
    public void OpenRule() {

        if (GeneraterLevel != null) {
            GeneraterLevel.SetActive(false);
        }
        AllScreen.ForEach(x => x.SetActive(false));
        Rule.SetActive(true);
    }

    public void OpenWin() {
        Win.SetActive(true);
        if (coroutine != null)
            StopCoroutine(coroutine);
        if (currentLevel != 9) {
            currentLevel += 1;
            PlayerPrefs.SetInt("currentLevel", currentLevel);
            PlayerPrefs.SetInt("UnlockedLevel", currentLevel);
        }
    }

    public void OpenLoss() {
        if (coroutine != null)
            StopCoroutine(coroutine);
        Loss.SetActive(true);
    }
    public void SettingRuleBack() {
        if (GeneraterLevel == null) {
            OpenMenu();
        }
        else {
            OpenGame();
        }
    }

    public async void OnJointFruit() {
        Wincount++;

        await Task.Delay(800);
        if (FruitConnector.Instance.winCount == Wincount) {
            OpenWin();
        }
    }

    private IEnumerator GameCountDown(float duration) {
        float timer = duration;
        yield return new WaitForSecondsRealtime(1f);

        while (timer >= 0) {
            timer -= Time.deltaTime;
            winTimeText.text = timer.ToString("F0") + " Sec Left";
            gameTimeText.text = timer.ToString("F0") + " Sec";
            yield return null;
        }

        OpenLoss();
    }

    public void DestroyLine() {
        foreach (LineRenderer lr in GeneratedLineRendere) {
            if (lr != null) {
                Destroy(lr.gameObject);
            }
        }
        GeneratedLineRendere.Clear();

    }

}
