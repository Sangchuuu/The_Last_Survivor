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
    public int m_nCount = 3;

    public bool m_bGrenade = false;

   
    public void OnMouseDrag()
    {
        if (m_objGrenadeOffBtn.activeSelf == true)
        {
            
            Vector3 mouseposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            Vector3 objposition = Camera.main.ScreenToWorldPoint(mouseposition);
            transform.position = objposition;
        }
    }
   

    void Update()
    {


    }
}
