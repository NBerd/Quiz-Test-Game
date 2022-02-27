using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DecisionText : MonoBehaviour
{
    private Text _decisionText;

    private void Awake()
    {
        _decisionText = GetComponent<Text>();
    }

    public void SetText(string text) 
    {
        _decisionText.text = text;
    }
}
