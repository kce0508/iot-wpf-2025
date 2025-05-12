using CommunityToolkit.Mvvm.ComponentModel;
using NLog;
using System.Diagnostics;
using System.Windows.Threading;

namespace WpfBasicApp01.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        // NLog 객체 생성
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        #region 속성영역
        private string _greeting;

        public string Greeting { 
            get => _greeting; 
            set => SetProperty(ref _greeting, value);   // CommunityToolki.Mvvm의 핵심 C++ & == ref
        }

        private string _currnetTime;

        public string CurrentTime
        {
            get => _currnetTime;
            set => SetProperty(ref _currnetTime, value);
        }

        private readonly DispatcherTimer _timer;    // ViewModel 내에서만 사용

        #endregion

        public MainViewModel()
        {
            _logger.Info("뷰모델 시작!");

            Greeting = "Hello, WPF MVVM!";
            CurrentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);  // 1초마다 변경
            _timer.Tick += (sender, e) =>
            {
                CurrentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Debug.WriteLine($"[DEBUG] {CurrentTime}");
                _logger.Log(LogLevel.Warn,$"{CurrentTime}");
            };
            _timer.Start(); // 타이머 시작
        }

    }
}
