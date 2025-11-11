public class BattleShopPresenter
{
    private readonly IBattleShopView m_view;
    // TOOD: 카드에 필요한 의존성 변수

    public BattleShopPresenter(IBattleShopView view)
    {
        m_view = view;
        m_view.Inject(this);
    }

    public void OpenUI()
    {
        m_view.OpenUI();
    }

    public void CloseUI()
    {
        m_view.CloseUI();
    }
}
