using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Canvas Cvs_OnPlayCanvas;
    public Image m_ProgBar_DayTime;
    public Image m_ProgBar_NightTime;
    public Text m_ProgBar_TestTxt;

    public float duration; // 낮/밤 지속시간(단위:초)

    private int numberOfTime; // 몇 초 지났는지 int형으로 저장.
    const float PROGRESS_MAX = 1.0f; // 프로그래스 바 게이지 최대치(100%)
    const float PROGRESS_MIN = 0.0f;

    void Start()
    {
        Cvs_OnPlayCanvas = GetComponent<Canvas>();
        m_ProgBar_NightTime.fillAmount = PROGRESS_MAX;
        #region 테스트用임. 나중에 지울것(변상현)
        m_ProgBar_TestTxt.text = duration + "s";
        #endregion

    }

    void Update()
    {
        if (m_ProgBar_NightTime.fillAmount <= PROGRESS_MIN)
        { // 게이지가 모두 소진되면 다시 최대치로 초기화
            m_ProgBar_NightTime.fillAmount = PROGRESS_MAX;
            m_ProgBar_TestTxt.text = duration + "s"; // 테스트用임. 나중에 지울것(변상현)
        }
        else
        { // 초당 1 / duration 만큼 부드럽게(매 프레임 마다) 감소 
            // duration이 15일 경우,         0초 일 때 1  ->  7.5초 일 때 0.5  ->  15초 일 때 0
            m_ProgBar_NightTime.fillAmount -= PROGRESS_MAX / duration * Time.deltaTime;

            #region 테스트用임. 나중에 지울것(변상현)
            // Math.Ceiling = double형 실수를 정수부분까지 올림
            numberOfTime = (int)System.Math.Ceiling(m_ProgBar_NightTime.fillAmount * duration);
            m_ProgBar_TestTxt.text = numberOfTime + "s";
            #endregion
        }

    }
    private void OnPlayCanvas_EnableChanged()
    { // 게임 플레이 화면 활성화여부가 갱신 될 경우, 게이지 초기화(아직 미적용22.01.15)
        m_ProgBar_NightTime.fillAmount = PROGRESS_MAX;
        m_ProgBar_TestTxt.text = duration + "s"; // 테스트用임. 나중에 지울것(변상현)
    }
}
