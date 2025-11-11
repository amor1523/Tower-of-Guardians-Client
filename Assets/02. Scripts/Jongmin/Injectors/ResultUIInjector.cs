using UnityEngine;

public class ResultUIInjector : MonoBehaviour, IInjector
{
    [Header("의존성 목록")]
    [Header("보상 뷰")]
    [SerializeField] private RewardView m_reward_view;

    [Header("결과 뷰")]
    [SerializeField] private ResultView m_result_view; 

    public void Inject()
    {
        InjectReward();
        InjectResult();
    }

    private void InjectReward()
    {
        DIContainer.Register<RewardView>(m_reward_view);

        var reward_presenter = new RewardPresenter(m_reward_view);
        DIContainer.Register<RewardPresenter>(reward_presenter);
    }

    private void InjectResult()
    {
        DIContainer.Register<ResultView>(m_result_view);

        var result_presenter = new ResultPresenter(m_result_view,
                                                   DIContainer.Resolve<RewardPresenter>());
        DIContainer.Register<ResultPresenter>(result_presenter);
    }
}