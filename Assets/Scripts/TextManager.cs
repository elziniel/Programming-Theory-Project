using UnityEngine;

[RequireComponent(typeof(TMPro.TextMeshProUGUI))]
public class TextManager : MonoBehaviour
{
    public string Text;
    public FloatReference Value;

    private void Start()
    {
        UpdateText();
    }

    public void UpdateText()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = $"{Text} {Value.Variable.Value}";
    }
}
