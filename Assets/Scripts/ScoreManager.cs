using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public FloatVariable Score;

    private void Awake()
    {
        Score.SetValue(0.0f);
    }

    public void OnScoreUpdated(GameObject amount)
    {
        Score.ApplyChange(amount.GetComponent<Spacerock>().ScoreValue);
    }
}
