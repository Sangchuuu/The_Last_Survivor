using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeControl : MonoBehaviour
{
    private Button m_GrenadeButton;
    public Image m_GrenadeRange;
    public GameObject m_StartPoint;

    public float rangeSize;

    private void Start()
    {
        m_GrenadeButton = this.GetComponent<Button>();
        m_GrenadeButton.onClick.AddListener(GrenadeButtonClick);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            m_GrenadeRange.gameObject.SetActive(true);
            Vector3 mousePos = Input.mousePosition;
            m_GrenadeRange.transform.localPosition = mousePos*2.3f;  // << 이게 왜 x2.3해야됨??
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            m_GrenadeRange.gameObject.SetActive(false);
        }

    }

    void GrenadeButtonClick()
    {
        m_GrenadeRange.transform.position = m_StartPoint.transform.position;
        m_GrenadeRange.gameObject.SetActive(true);
    }
}
