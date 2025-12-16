using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// By Ayoub Fellah
namespace MyFullServiceImplementationState
{
    public partial class MyFullServiceImplementationState : ServiceBase
    {  
        private string logDirectory;
        private string logFilePath;
        public MyFullServiceImplementationState()
        {
            InitializeComponent();
            // Set the CanPauseAndContinue property to true
            CanPauseAndContinue = true; //The service supports pausing and resuming operations.

            // Enable support for OnShutdown
            CanShutdown = true; // The service is notified when the system shuts down.


            // Read log directory path from App.config
            //The service reads the log directory path from an external configuration file (App.config) for flexibility.
            logDirectory = ConfigurationManager.AppSettings["LogDirectory"];


            // Validate and create directory if it doesn't exist
            if (string.IsNullOrWhiteSpace(logDirectory))
            {
                throw new ConfigurationErrorsException("LogDirectory is not specified in the configuration file.");
            }

            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            logFilePath = Path.Combine(logDirectory, ConfigurationManager.AppSettings["LogFile"] );
        }

        private void LogServiceEvent(string message)
        {
            string logMessage = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}\n";
            File.AppendAllText(logFilePath, logMessage);

            // Write to console if running interactively
            if (Environment.UserInteractive)
            {
                Console.WriteLine(logMessage);
            }
        }
        protected override void OnStart(string[] args)
        {

            LogServiceEvent(" Hi I am Your Start event");
            
           

            // Set the current process priority to High
            Process process = Process.GetCurrentProcess();
            process.PriorityClass = ProcessPriorityClass.Normal;

            // Start a background task with fault handling
            Thread workerThread = new Thread(WorkerTask);
            workerThread.Start();

            LogServiceEvent($"Service Priority Set to: {process.PriorityClass}");
        }
        private void WorkerTask()
        {
            try
            {
                // Simulate work
                while (true)
                {
                    LogServiceEvent("Service is running...");
                    Thread.Sleep(5000);

                    // Simulate a failure
                    throw new Exception("Simulated error for testing recovery.");
                }
            }
            catch (Exception ex)
            {
                LogServiceEvent($"Error: {ex.Message}");
                // Exit the process to simulate failure
                Environment.Exit(1);
            }
        }
        protected override void OnStop()
        {
            LogServiceEvent(" Hi I am Your Stop event");
        }
        protected override void OnPause()
        {
            LogServiceEvent("Service Paused");
            // Add pause logic here
        }

        // OnContinue Event
        protected override void OnContinue()
        {
            LogServiceEvent("Service Resumed");
            Console.WriteLine("Good job");
            // Add resume logic here
        }

        // OnShutdown Event
        protected override void OnShutdown()
        {
            LogServiceEvent("Service Shutdown due to system shutdown");
            // Add shutdown cleanup logic here
        }
        // This is added
        // Simulate service behavior in console mode
        public void StartInConsole()
        {
            OnStart(null); // Trigger OnStart logic
            Console.WriteLine("Press Enter to stop the service...");
            Console.ReadLine(); // Wait for user input to simulate service stopping
            OnStop(); // Trigger OnStop logic
            Console.ReadKey();

        }


    }
}
