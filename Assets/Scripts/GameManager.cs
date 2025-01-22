using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float timer = 0f;
    private float efficiency = 10f;
    public float currentGas;
    private GameObject player;
    private Slider slider;
    private TextMeshProUGUI text;
    private bool isStart = false;
    private bool isEnd = false;
    private GameObject mainPanel;
    private GameObject gamePanel;
    private GameObject endPanel;
    private GameObject tileManager;
    private Button startButton;
    private float moveSpeed;

    
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentGas = player.GetComponent<Player>().maxGas;
        moveSpeed = player.GetComponent<Player>().moveSpeed;
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        text = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        mainPanel = GameObject.Find("MainPanel");
        gamePanel = GameObject.Find("GamePanel");
        endPanel = GameObject.Find("EndPanel");
        tileManager = GameObject.Find("TileManager");
        startButton = GameObject.Find("StartButton").GetComponent<Button>();
        startButton.onClick.AddListener(OnClickStartButton);
        gamePanel.SetActive(false);
        endPanel.SetActive(false);
        tileManager.SetActive(false);
    }

    public void OnClickStartButton()
    {
        isStart = true;
        mainPanel.SetActive(false);
        gamePanel.SetActive(true);
        tileManager.SetActive(true);
    }
    
    void Update()
    {
        if (isStart)
        {
            if (!isEnd)
            {
                if (currentGas <= 0f)
                {
                    Debug.Log("GameOver");
                    isEnd = true;
                    gamePanel.SetActive(false);
                    tileManager.SetActive(false);
                    endPanel.SetActive(true);
                }
                else
                {
                    if (Input.GetKey(KeyCode.A))
                    {
                        player.transform.position += new Vector3(-1, 0, 0).normalized * Time.deltaTime * moveSpeed;
                    }
                    if (Input.GetKey(KeyCode.D))
                    {
                        player.transform.position += new Vector3(1, 0, 0).normalized * Time.deltaTime * moveSpeed;
                    }
                    currentGas -= efficiency * Time.deltaTime;
                    slider.value = currentGas * 0.01f;
                    timer += Time.deltaTime;
                    text.text = timer.ToString("0.00");
                }
            }
        }
    }
}
