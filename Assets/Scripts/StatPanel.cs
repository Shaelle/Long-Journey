using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetValue(float maxValue, float value)
    {
        if (text != null)  text.text = value.ToString("#.#");
        if (slider != null) slider.value = Mathf.InverseLerp(0, maxValue, value);
    }
}
