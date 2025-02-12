using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TMP_Text ScoreText;
    public Canvas GameOver;
    public Button RestartButton;
    public GameObject Monster;
    public GameObject Platform;
    public GameObject Player;

    public static UnityAction Scoring;
    public static UnityAction CanvasOn;

    int _score;
    Vector3 _platformStartPos;

    private void Awake()
    {
        GameOver.gameObject.SetActive(false);
        Scoring += GetScore;
        CanvasOn += TurnOnCanvas;
        _platformStartPos = Platform.transform.position;
    }

    void Start()
    {
        ScoreText.text = $"Score : {_score}";
        RestartButton.onClick.AddListener(OnRestartButtonClick);
        StartCoroutine(SpawnMonster());
        StartCoroutine(SpawnPlatform());
    }

    IEnumerator SpawnMonster()
    {
        yield return new WaitForSeconds(2f);
        float posY = Random.Range(-4, 4);
        Instantiate(Monster, new Vector3(11, posY, 0), Quaternion.identity);
        StartCoroutine(SpawnMonster());
    }

    IEnumerator SpawnPlatform()
    {
        yield return new WaitForSeconds(12f);
        float posY = Random.Range(-3, 3);
        Instantiate(Platform, new Vector3(13, posY, 0), Quaternion.identity);
        StartCoroutine(SpawnPlatform());
    }

    public void GetScore()
    {
        _score += 10;
        ScoreText.text = $"Score : {_score}";
    }

    void OnRestartButtonClick()
    {
        GameOver.gameObject.SetActive(false);
        StopAllCoroutines();
        GameObject[] currentMonsters = GameObject.FindGameObjectsWithTag("Monster");
        GameObject currentPlatform = GameObject.FindGameObjectWithTag("Platform");

        currentPlatform?.SetActive(false);
        for (int i = 0; i < currentMonsters.Length; i++)
        {
            currentMonsters[i].SetActive(false);
        }
        
        ReStart();
    }

    void ReStart()
    {
        _score = 0;
        ScoreText.text = $"Score : {_score}";
        Instantiate(Player);
        Instantiate(Platform);
        StartCoroutine(SpawnPlatform());
        StartCoroutine(SpawnMonster());
        Background.RestartBg();
    }

    void TurnOnCanvas()
    {
        GameOver.gameObject.SetActive(true);
    }
}
