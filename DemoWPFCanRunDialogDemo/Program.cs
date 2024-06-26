﻿using System.Windows;
using Vishnu.Interchange;

namespace DemoWPFCanRunDialogDemo
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            DemoWPFCanRunDialog.DemoWPFCanRunDialog demoWPFCanRunDialog = new DemoWPFCanRunDialog.DemoWPFCanRunDialog();
            object? para = "xyz";
            bool canRun = demoWPFCanRunDialog.CanRun(ref para, new TreeParameters("Tree_01", null), new TreeEvent("DemoTreeEvent", "Demo-Knoten", "Demo-Knoten", "Demo-Knoten",
              @"demoWPFCanRunDialog\Demo-Knoten", true, NodeLogicalState.Done,
              new ResultDictionary() { { "Demo-Knoten", new Result("Demo-Knoten", true, NodeState.Finished, NodeLogicalState.Done, DateTime.Now) } },
              new ResultDictionary()));
            MessageBox.Show(String.Format("canRun: {0}", canRun));
        }
    }
}