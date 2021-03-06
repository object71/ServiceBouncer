﻿using CommandLine;
using System;
using System.Windows.Forms;

namespace ServiceBouncer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] commandLine)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += (sender, args) => MessageBox.Show(args.Exception.Message, "Unhandled error", MessageBoxButtons.OK);

            Parser.Default.ParseArguments<Options>(commandLine)
                .WithParsed((options) =>
                {
                    Application.Run(new MainForm(options.Machine));
                })
                .WithNotParsed((error) =>
                {
                    Application.Run(new MainForm(Environment.MachineName));
                });
        }
    }
}
