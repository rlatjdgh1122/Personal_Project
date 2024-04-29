using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class TextUI : MonoBehaviour
{
    protected TextMeshProUGUI _text;

    protected virtual void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }
}
