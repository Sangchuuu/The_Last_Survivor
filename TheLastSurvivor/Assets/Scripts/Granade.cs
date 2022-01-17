using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Granade : MonoBehaviour
{
    public GameObject m_objGrenadeOffBtn;
    public GameObject m_objGrenadeOnBtn;
    public GameObject m_objTempShelter;
    public GameObject m_objGrenade;

    public int m_nDamage;
    public int m_nCount;
    
    Vector2 MousePosition;
    public Camera camera;

    public void SetGrenadeOn()
    {
        if(m_objGrenadeOnBtn.activeSelf == false)
        {
            m_objGrenade.transform.position = m_objTempShelter.transform.position;
        }
    }
    public void MouseLocate()
    {

    }
  

    void Update()
    {
        SetGrenadeOn();

    }
}
