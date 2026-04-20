using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public static LevelTimer instance;

    public float time;
    public bool running;

    public TextMeshProUGUI timerText;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        time = 0f;
        running = true;
    }

    void Update()
    {
        if (!running) return;

        time += Time.deltaTime;

        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    public float GetTime()
    {
        return time;
    }

    public void StopTimer()
    {
        running = false;
    }
}