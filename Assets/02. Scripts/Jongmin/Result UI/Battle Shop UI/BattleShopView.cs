using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class BattleShopView : MonoBehaviour, IBattleShopView
{
    [Header("UI 관련 컴포넌트")]
    [Header("카드의 부모 트랜스폼")]
    [SerializeField] private Transform m_slot_root;

    [Header("확률 텍스트")]
    [SerializeField] private TMP_Text m_card_rate_label;

    [Header("새로고침 버튼")]
    [SerializeField] private Button m_refresh_button;

    private Animator m_animator;
    private BattleShopPresenter m_presenter;

    private void Awake()
    {
        m_animator = GetComponent<Animator>();

        m_refresh_button.onClick.AddListener(() => { m_animator.SetTrigger("Refresh");} );
    }

    public void Inject(BattleShopPresenter presenter)
    {
        m_presenter = presenter;
    }

    public void OpenUI()
    {
        ToggleUI(true);
    }

    public void CloseUI()
    {
        ToggleUI(false);
    }

    private void ToggleUI(bool active)
    {
        m_animator.SetBool("Open", active);
    }

    public void CallbackToInstantiateCard()
    {
        // TODO: Object Pool을 통한 카드 생성
#if UNITY_EDITOR
        Debug.Log("카드가 생성되었습니다.");
#endif
    }

    public void CallbackToDestroyCard()
    {
        // TODO: Object Pool을 통한 카드 제거
#if UNITY_EDITOR
        Debug.Log("카드가 제거되었습니다.");
#endif
    }
}
