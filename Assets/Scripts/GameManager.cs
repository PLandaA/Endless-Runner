using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour {


    public static GameManager instance;
    public TextMeshProUGUI score;

    bool hasLost = false;

    [SerializeField] GameObject _enemy, otherEnemy, player, gameOverPanel;
    [SerializeField] List<Transform> _clones = new List<Transform>();
    [SerializeField] List<Transform> _enemyClones2 = new List<Transform>();



    private void Awake () {
        instance = this;
    }

    // Start is called before the first frame update
    void Start () {

        _clones.Add(_enemy.transform);
        for (int i = 0; i < 5; i++) {
            GameObject clone = Instantiate(_enemy);
            clone.SetActive(false);
            clone.transform.position = new Vector3(7.5f, 0, 0);
            _clones.Add(clone.transform);

        }
        _enemyClones2.Add(otherEnemy.transform);
        for (int i = 0; i < 5; i++) {
            GameObject clone = Instantiate(otherEnemy);
            clone.SetActive(false);
            clone.transform.position = new Vector3(7.5f, 0, 0);
            _enemyClones2.Add(clone.transform);
        }


        InvokeRepeating("SelectEnemy", 4, 3);
        InvokeRepeating("SelectOtherEnemy", 20, 3);

    }



    void Update () {
        if (!hasLost) {
            score.text = "Score:" + Time.timeSinceLevelLoad.ToString("F0");
        }
    }

    void SelectEnemy () {
        foreach (Transform c in _clones) {
            if (c.gameObject.activeInHierarchy == false) {
                float yPos = Random.Range(-4, 4);
                c.transform.position = new Vector3(7.5f, yPos, 0);
                c.gameObject.SetActive(true);
                break;

            }
        }
    }

    void SelectOtherEnemy () {
        foreach (Transform c in _enemyClones2) {
            if (c.gameObject.activeInHierarchy == false) {
                float yPos = Random.Range(-4, 4);
                c.transform.position = new Vector3(7.5f, yPos, 0);
                c.gameObject.SetActive(true);
                break;

            }
        }

    }

    public void gameOver () {
        hasLost = true;
        Destroy(player);
        Invoke("Delay", 0.6f);
    }

    void Delay () {
        CancelInvoke();

        gameOverPanel.SetActive(true);

    }

    public void Restart () {
        SceneManager.LoadScene("GameScene");
    }

    public void BackToMenu () {
        SceneManager.LoadScene("MainMenuScene");
    }



}
