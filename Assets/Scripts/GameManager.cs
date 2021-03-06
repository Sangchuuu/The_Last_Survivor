using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region 싱글톤구현
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (!_instance)
            {// 인스턴스가 없는 경우에 접근하려 하면 인스턴스를 할당해준다.
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (_instance == null)
                    Debug.Log("no Singleton obj");
            }
            return _instance;
        }
    }
    #endregion

    public Image m_ProgBar_NightTime;
    public Text m_ProgBar_TestTxt;
    public Text m_Text_StageTxt;
    public Image m_ProgBar_DayTime;

    public GameObject m_objOnPlayCanvas; //수정(김상현)22.01.17 원코드 : private Canvas = Cvs_OnPlayCanvas;
    public GameObject m_objTitleCanvas;
    public GameObject m_objUpgradeCanvas;
    public GameObject m_objSetupCanvas;

    public float stageDuration; // 낮/밤 지속시간(단위:초)
    private int numberOfTime; // 몇 초 지났는지 int형으로 저장.
    public int numberOfStage = 1; // 스테이지 단계(항상 1단계부터 시작)
    const float PROGRESS_MAX = 1.0f; // 프로그래스 바 게이지 최대치(100%)
    const float PROGRESS_MIN = 0.0f;

    // 오디오
    public Button Btn_Next;
    public Button GameStartButton;
    public Button GameStartButton2; // 랭크에서도 게임스타트 가능함
    public AudioSource[] m_NightSound; // 스테이지 시작 사운드 트랙
    public AudioSource m_BackgroundMusic; // 배경음
    int soundTrackNum = 0;
    int preTrackNum = 0;

    void Start()
    {
        Canvas Cvs_OnPlayCanvas = m_objOnPlayCanvas.GetComponent<Canvas>();       // 수정(김상현)22.01.17 원코드 : Cvs_OnPlayCanvas = GetComponent<Canvas>();
        m_ProgBar_NightTime.fillAmount = PROGRESS_MAX;
        #region 테스트用임. 나중에 지울것(변상현)
        m_ProgBar_TestTxt.text = stageDuration + "s";

        Btn_Next.onClick.AddListener(SoundTrackPlay); // 스테이지 시작 시 사운드트랙 재생
        GameStartButton.onClick.AddListener(SoundTrackPlay);
        GameStartButton2.onClick.AddListener(SoundTrackPlay);

        #endregion

    }
    void Update()
    {
        m_Text_StageTxt.text = "Stage" + numberOfStage;
        if (m_ProgBar_NightTime.fillAmount <= PROGRESS_MIN)
        { // 게이지가 모두 소진되면 다시 최대치로 초기화
            m_ProgBar_NightTime.fillAmount = PROGRESS_MAX;
            m_ProgBar_TestTxt.text = stageDuration + "s"; // 테스트用임. 나중에 지울것(변상현)

            EndOfNight();
        }
        else
        { // 초당 1 / duration 만큼 부드럽게(매 프레임 마다) 감소 
            // duration이 15일 경우,         0초 일 때 1  ->  7.5초 일 때 0.5  ->  15초 일 때 0
            m_ProgBar_NightTime.fillAmount -= PROGRESS_MAX / stageDuration * Time.deltaTime;
            #region 테스트用임. 나중에 지울것(변상현)
            // Math.Ceiling = double형 실수를 정수부분까지 올림
            numberOfTime = (int)System.Math.Ceiling(m_ProgBar_NightTime.fillAmount * stageDuration);
            m_ProgBar_TestTxt.text = numberOfTime + "s";
            #endregion
        }
        OnPlayCanvas_EnableChanged();

    }

    private void EndOfNight()
    {
        numberOfStage++;
        m_objUpgradeCanvas.SetActive(true);
        //m_objOnPlayCanvas.gameObject.SetActive(false);

    }


    private void OnPlayCanvas_EnableChanged()
    { // 게임 플레이 화면 활성화여부가 갱신 될 경우, 게이지 초기화(아직 미적용22.01.15)


        if (m_objTitleCanvas.activeSelf == true) // 타이틀캔버스가 켜진다 = 게임종료 = 게임시간이 초기화 되어야함(22.01.17)
        {
            m_ProgBar_NightTime.fillAmount = PROGRESS_MAX;
            m_ProgBar_TestTxt.text = stageDuration + "s"; // 테스트用임. 나중에 지울것(변상현)
            numberOfStage = 1;
        }
        else if (m_objUpgradeCanvas.activeSelf == true)
        {
            m_ProgBar_NightTime.fillAmount = PROGRESS_MAX;
            m_ProgBar_TestTxt.text = stageDuration + "s";
        }
        if (m_objSetupCanvas.activeSelf == true)  // 게임중 셋팅창이켜지면 시간이 흐르면 안됨.
        {
            Time.timeScale = 0;
        }
        else Time.timeScale = 1;

    }

    public void SoundTrackPlay()
    { // 스테이지 시작 효과음 재생 및 변경
        m_NightSound[preTrackNum].enabled = false;
        m_NightSound[soundTrackNum].enabled = true;
        preTrackNum = soundTrackNum;
        soundTrackNum = (soundTrackNum < m_NightSound.Length - 1) ? (soundTrackNum + 1) : 0;
    }
}
