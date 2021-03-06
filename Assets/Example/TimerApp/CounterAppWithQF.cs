using UnityEngine;
using QFramework;
using UniRx;

// 1.请在菜单 编辑器扩展/Namespace Settings 里设置命名空间
// 2.命名空间更改后，生成代码之后，需要把逻辑代码文件（非 Designer）的命名空间手动更改
namespace Example.TimerApp
{
	public partial class CounterAppWithQF : ViewController
	{
		[Inject] public CounterAppWithQFModel Model {get;set;}
		[Inject] public ICounterApiService ApiService { get; set; }
		
		//CounterAppWithQFModel _model = new CounterAppWithQFModel();

		void Start()
		{
			// 注入实例
			CounterApp.Container.Inject(this);
			
			
			
			// Model -> view
			Model.Count.Select(count => count.ToString())
				.SubscribeToText(Number)
				.AddTo(this);

			Model.SomeData.Select(somedata => somedata.ToString())
				.SubscribeToText(ResultText)
				.AddTo(this);
			
			// view -> model
			BtnAdd.OnClickAsObservable().Subscribe((_) => Model.Count.Value++);
			BtnSub.OnClickAsObservable().Subscribe((_) => Model.Count.Value--);

			BtnRequest.OnClickAsObservable().Subscribe(_ =>
			{
				ApiService.RequestSomeData(someData =>
				{
					Model.SomeData.Value = someData;
				});
			});
		}
	}
}
