using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    private Canvas m_Cvs_Settings;

    public Button m_Label_Vibration;
    public Scrollbar m_ScrollBar_Vibration;
    public Text m_ScrollBar_Text;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (m_ScrollBar_Vibration.value >= 0.5f)
            m_ScrollBar_Text.text = "OFF";
        else
            m_ScrollBar_Text.text = "ON";
    }
}
