using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class EndGame : MonoBehaviour
{
    Image image;
    Button button;
    TextMeshProUGUI label;

    [SerializeField] string loseMessage = "Game Over";
    [SerializeField] Color loseColor = Color.red;

    [SerializeField] string winMessage = "You're Win";
    [SerializeField] Color winColor = Color.green;


    private void Awake()
    {
        image = GetComponent<Image>();

        button = GetComponent<Button>();

        label = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        image.enabled = false;
        label.enabled = false;

        button.interactable = false;

        button.onClick.AddListener(RestartGame);
    }

    private void OnDestroy()
    {
        button.onClick.RemoveListener(RestartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        PlayerConditions.OnGameOver += Lose;
        Home.OnFindHome += Win;
    }

    private void OnDisable()
    {
        PlayerConditions.OnGameOver -= Lose;
        Home.OnFindHome -= Win;
    }


    private void Lose()
    {
        label.text = loseMessage;

        label.color = loseColor;

        Finish();
    }


    private void Win()
    {
        label.text = winMessage;
        label.color = winColor;

        Finish();
    }

    void Finish()
    {
        Time.timeScale = 0;

        image.enabled = true;
        label.enabled = true;


        //Color color = image.color;

        //color.a = 1;

        // image.color = color;

        button.interactable = true;
    }


    private void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
