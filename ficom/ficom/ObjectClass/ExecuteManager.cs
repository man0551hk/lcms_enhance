using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using UMCBILib;
using System.IO;

namespace LCMS
{
    public class ExecuteManager
    {
        public string scriptFilePath = "";
        public int detectorIndex = 0;

        public ExecuteManager() { }
        public ExecuteManager(string scriptFilePath)
        {
            this.scriptFilePath = scriptFilePath;
    
        }

        public void RunScript()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = GlobalFunc.basicSetting.ExePath;
            startInfo.Arguments = "-P DetL " + scriptFilePath + " -B";
            Process.Start(startInfo);
        }



        public void OpenConnection(int detectorIndex)
        {
            //if (detectorIndex == 1)
            //{
            //    if (!GlobalFunc.axUCONN21.IsOpen)
            //    {
            //        GlobalFunc.axUCONN21.Open();
            //    }
            //}
            //else if (detectorIndex == 2)
            //{
            //    if (!GlobalFunc.axUCONN22.IsOpen)
            //    {
            //        GlobalFunc.axUCONN22.Open();
            //    }
            //}
        }

        public void CloseConnection(int detectorIndex)
        {
            //if (GlobalFunc.axUCONN21.IsOpen)
            //{
            //    GlobalFunc.axUCONN21.Close();
            //}
        }

        public void SendCommand(string command)
        {
            //OpenConnection(detectorIndex);

            try
            {
                if (!GlobalFunc.axUCONN21.IsOpen)
                {
                    GlobalFunc.axUCONN21.Open();
                }
                GlobalFunc.axUCONN21.Comm(command);
                //GlobalFunc.axUCONN21.Comm("SHOW_VERSION");
                if (GlobalFunc.axUCONN21.IsOpen)
                {
                    GlobalFunc.axUCONN21.Close();
                }
            }
            catch (Exception ex)
            {
                GlobalFunc.logManager.WriteLog(ex.Message);
            }
            //CloseConnection(detectorIndex);
        }

        public void ReadJobFileSend() 
        {
            string[] scriptText = File.ReadAllLines(this.scriptFilePath, Encoding.UTF8);
            for (int i = 0; i < scriptText.Length; i++)
            {
                if (scriptText[i] != "")
                {
                    if (scriptText[i].Contains("WAIT"))
                    {
                        int wait = Convert.ToInt32(scriptText[i].Replace("WAIT", "").Trim()) * 1000;
                        System.Threading.Thread.Sleep(wait);
                    }
                    else if (!scriptText[i].Contains("REM"))
                    {
                        this.SendCommand(scriptText[i]);
                    }
                }
            }
        }
    }
}
