namespace UIFrameWork
{


	public class MainView : EnabledView
	{
		public override void Init ()
		{
			base.Init ();

		}
		public override void OnEnter(BaseContext context)
		{
			base.OnEnter(context);
		}

		public override void OnExit(BaseContext context)
		{
			base.OnExit(context);
		}

		public override void OnPause(BaseContext context)
		{
			base.OnPause(context);
		}
		public override void OnResume(BaseContext context)
		{
			base.OnResume(context);
		}
		public override void Excute()
		{
			base.Excute();
		}
		public void StartCallBack()
		{
			if (!GameManager.Instance.CanOperate ())
				return;
			UIManager.Instance.StartBlackTrans ();
			UIManager.Instance.Push(new LevelSelectContext());
		}
		public void OptionCallBack()
		{
			if (!GameManager.Instance.CanOperate ())
				return;
			UIManager.Instance.Push(new OptionMenuContext());
		}

	}

	public class MainContext : BaseContext
	{
		public MainContext() : base(UIType.Main)
		{

		}

	}
}
