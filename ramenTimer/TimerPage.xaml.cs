namespace ramenTimer;

public partial class TimerPage : ContentPage
{
    // 設定時分（初期値は3分）
    private TimeOnly _startTime = new(0, 3);

    // 残り時分（初期値は3分）
    private TimeOnly _leftTime = new(0, 3);

    // 実行中ならtrue
    private bool _isLive = false;

    private IFlagControl _flagControl;


    public TimerPage(IFlagControl fc)
    {
        _flagControl = fc;
        InitializeComponent();
        SetLabel();
    }


    /// <summary>
    /// ラベル、プログレスバーの表示更新
    /// </summary>
    private void SetLabel()
    {
        MinutesLabel.Text = _leftTime.ToString("mm分ss秒ff");
        PrgBar.Progress = (_startTime - _leftTime).TotalSeconds / (_startTime - new TimeOnly(0, 0)).TotalSeconds;
    }

    /// <summary>
    /// タイマーの実行中フラグを反転する
    /// </summary>
    private void Toggle()
    {
        _isLive = _flagControl.Toggle(_isLive);

        // ボタン名を変更する
        StartButton.Text = (_isLive) ? "停止" : "開始";
    }

    /// <summary>
    /// タイマーを減算して、タイムアップしたらメッセージを出力する
    /// </summary>
    private async void DecreaseTime()
    {
        var span = 10; // 10ミリ秒

        while (_isLive)
        {
            // 10ミリ秒ごとにタイマ減算して表示を更新
            await Task.Delay(TimeSpan.FromMilliseconds(span));
            _leftTime = _leftTime.Add(TimeSpan.FromMilliseconds(-span));
            SetLabel();

            // タイムアップ処理
            if (_flagControl.IsTimeout(_leftTime))
            {
                Toggle();
                await DisplayAlert("終了", "ラーメンができました", "OK");
            }
        }
    }

    /// <summary>
    /// 開始ボタン処理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnStartButton(object sender, EventArgs e)
    {
        Toggle();
        DecreaseTime();
    }

    /// <summary>
    /// +1分ボタン処理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnPlusButton(object sender, EventArgs e)
    {
        _leftTime = _leftTime.Add(TimeSpan.FromMinutes(1));
        _startTime = _leftTime;
        SetLabel();
    }

    /// <summary>
    /// -1分ボタン処理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void OnMinusButton(object sender, EventArgs e)
    {
        _leftTime = _leftTime.Add(TimeSpan.FromMinutes(-1));
        _startTime = _leftTime;
        SetLabel();
    }
}
