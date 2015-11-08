using LYLQ.WinUI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LYLQ.WinUI
{
    static class Program
    {
        public static ApplicationContext context;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmLogin());

            try
            {
                //处理未捕获的异常   
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常   
                Application.ThreadException += Application_ThreadException;
                //处理非UI线程异常   
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                Application.ApplicationExit += CheckSynInstockToStockCompleted;

                var aProcessName = Process.GetCurrentProcess().ProcessName;
                if ((Process.GetProcessesByName(aProcessName)).GetUpperBound(0) > 0)
                {
                    MessageBox.Show(@"系统已经在运行中，如果要重新启动，请从进程中关闭...", @"系统警告", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);

                    var sp = new frmLogin(); //create splash screen
                    sp.Show(); //show splash screen
                    context = new ApplicationContext();
                    context.Tag = sp;
                    //Application.Idle += Application_Idle; //注册程序运行空闲去执行主程序窗体相应初始化代码
                    Application.Run(context);
                }
            }
            catch (Exception ex)
            {
                var tt = "";
                // LogHelper.Log(ex);
                //MessageBox.Show("系统出现未知异常，请重启系统！");
            }
        }

        //初始化等待处理函数
        private static void Application_Idle(object sender, EventArgs e)
        {
            Application.Idle -= Application_Idle;
            if (context.MainForm == null)
            {
                //var mw = new Login();
                ////YYQTestForm mw = new YYQTestForm();

                //context.MainForm = mw;
                //var sp = (SplashForm)context.Tag;
                //sp.Close(); //关闭启动窗体 
                //mw.Show(); //启动主程序窗体
            }
        }


        ///<summary>
        ///  这就是我们要在发生未处理异常时处理的方法，我这是写出错详细信息到文本，如出错后弹出一个漂亮的出错提示窗体，给大家做个参考
        ///  做法很多，可以是把出错详细信息记录到文本、数据库，发送出错邮件到作者信箱或出错后重新初始化等等
        ///  这就是仁者见仁智者见智，大家自己做了。
        ///</summary>
        ///<param name="sender"> </param>
        ///<param name="e"> </param>
        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            var ex = e.Exception;
            if (ex != null)
            {
                //LogHelper.Log(ex);
            }

            //MessageBox.Show("系统出现未知异常，请重启系统！");
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                //LogHelper.Log(ex);
            }

            //MessageBox.Show("系统出现未知异常，请重启系统！");
        }

        private static void CheckSynInstockToStockCompleted(object sender, EventArgs e)
        {
            if (!UIContext.SyncInstockToStockTask.IsCompleted)
            {
                UIContext.SyncInstockToStockTask.Wait();
            }
          
        }
    }
}
