using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public FloatVariable Score;

    public void OnScoreUpdated(GameObject amount)
    {
        Score.ApplyChange(amount.GetComponent<Spacerock>().ScoreValue);
    }
}
