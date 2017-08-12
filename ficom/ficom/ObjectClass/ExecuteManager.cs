﻿using System;
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
            
            //GlobalFunc.axUCONN21.Comm(command);
            //CloseConnection(detectorIndex);
        }

        public void ReadJobFileSend() 
        {
            string[] scriptText = File.ReadAllLines(this.scriptFilePath, Encoding.UTF8);
            for (int i = 0; i < scriptText.Length; i++)
            {
                this.SendCommand(scriptText[i]);
            }
        }
    }
}
