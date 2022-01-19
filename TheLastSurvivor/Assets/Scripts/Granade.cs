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

    CircleCollider2D collider2D;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("충돌");
            this.gameObject.SetActive(false);
        }
    }
   
    void Update()
    {
        collider2D = this.gameObject.GetComponent<CircleCollider2D>();
        if (m_bGrenade == false)
        {
            if (m_objGrenadeOffBtn.activeSelf == true)
            {
                transform.position = m_objTempShelter.transform.position;
                m_bGrenade = true;
            }
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mouseposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
            Vector3 objposition = Camera.main.ScreenToWorldPoint(mouseposition);
            objposition.z = 0; 
            transform.position = objposition;
            collider2D.enabled = false;
        }
        if (Input.GetMouseButtonUp(0))
        {
            collider2D.enabled = true;
            
        }


    }
}
