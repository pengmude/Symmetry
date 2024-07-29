using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Logger;
using System.Collections.Generic;
using System.Threading.Tasks;
using log4net.Core;

namespace FrmResultView
{
    public partial class FrmLogger : DockContent
    {
        /// <summary>
        /// 标记本类实例是否初始化完成
        /// </summary>
        public static FrmLogger Instance { get; private set; }
        public bool IsLoaded { get; private set; }

        /// <summary>
        /// 通知主窗口本窗口是否还显示在DockContent中
        /// </summary>
        public static event EventHandler<bool> IsShowOnDockContentChanged;

        /// <summary>
        /// 用来缓存一开始因为日志窗口还没初始化导致的日志显示异常
        /// </summary>
        private static Queue<Tuple<MsgLevel, string, bool>> queueLogs = new Queue<Tuple<MsgLevel, string, bool>>();
        private static Timer _timer = new Timer();

        public FrmLogger()
        {
            InitializeComponent();
            Instance = this;
            _timer.Interval = 20;
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        /// <summary>
        /// 窗口初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogger_Load(object sender, EventArgs e)
        {
            IsLoaded = true;
        }

        /// <summary>
        /// 用于处理一开始日志窗口没有初始化时，
        /// 其他类就输出日志的情况，会导致异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void _timer_Tick(object sender, EventArgs e)
        {
            if (queueLogs.Count == 0)
                return;
            while (queueLogs.Count > 0)
            {
                if (!CheckIfLoaded())
                    return;
                var item = queueLogs.Dequeue();
                LogHelper.Add(item.Item1, item.Item2, item.Item3);
            };
        }

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="level"></param>
        /// <param name="info"></param>
        public static void AddLog(string info, MsgLevel level)
        {
            if (CheckIfLoaded())
            {
                LogHelper.Add(level, info, true);
            }
            else
            {
                queueLogs.Enqueue(Tuple.Create(level, info, true));
            }
        }

        public static bool CheckIfLoaded()
        {
            if (Instance != null && Instance.IsLoaded)
                return true;
            else
                return false;
        }

        private void FrmLogger_VisibleChanged(object sender, EventArgs e)
        {
            IsShowOnDockContentChanged?.Invoke(this, Visible);
        }

        private void FrmLogger_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

    }
}
