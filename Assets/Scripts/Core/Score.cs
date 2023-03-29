using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private int maxScore;
    [SerializeField] private TextMeshProUGUI bestScore;
    [SerializeField] private DataManager dataManager;
    private TextMeshProUGUI text;
    public int score;

    private void Awake()
    {
        text= GetComponent<TextMeshProUGUI>();
        dataManager.Load();
        bestScore.text = dataManager.GetGameData().bestScore.ToString();
    }

    private void Update()
    {
        score = player.position.x < maxScore ? Mathf.FloorToInt(player.position.x) : maxScore;
        text.text = score.ToString();
    }

    public void SaveBestScore()
    {
        dataManager.Load();
        if (dataManager.GetGameData().bestScore < score)
        {
            dataManager.SetBestScore(score);
            dataManager.Save();
        }
    }
}
