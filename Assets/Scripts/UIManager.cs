using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager gameManager;
    // text score

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timer;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + gameManager.getScore();
        timer.text = "Time: " + gameManager.getTime();
    }
}
