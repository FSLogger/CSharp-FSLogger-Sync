using System;
using System.IO;
using System.Text;
namespace CSharp_FSL.Classes
{
    class Logger
    {
        private byte[] LogData;
        private FileStream LogStream;
        private string LogFileName = String.Format(@"{0}\Logs\{1:(HH-mm-ss)___(dd-MM-yyyy)}.log", AppDomain.CurrentDomain.BaseDirectory, DateTime.Now);
        public Logger()
        {
            LogStream = File.Open(LogFileName.ToString(), FileMode.Append);
        }
        public void CreateLog(int Level, String Data)
        {
            try
            {
                switch (Level)
                {
                    case 1:
                        LogData = new UTF8Encoding(true).GetBytes(String.Format("[{0}] : |DEBUG| {1}{2}", DateTime.Now.ToString("HH:mm:ss"), Data.ToString(), Environment.NewLine));
                        break;
                    case 2:
                        LogData = new UTF8Encoding(true).GetBytes(String.Format("[{0}] : |INFO| {1}{2}", DateTime.Now.ToString("HH:mm:ss"), Data.ToString(), Environment.NewLine));
                        break;
                    case 3:
                        LogData = new UTF8Encoding(true).GetBytes(String.Format("[{0}] : |WARN| {1}{2}", DateTime.Now.ToString("HH:mm:ss"), Data.ToString(), Environment.NewLine));
                        break;
                    case 4:
                        LogData = new UTF8Encoding(true).GetBytes(String.Format("[{0}] : |ERROR| {1}{2}", DateTime.Now.ToString("HH:mm:ss"), Data.ToString(), Environment.NewLine));
                        break;
                    case 5:
                        LogData = new UTF8Encoding(true).GetBytes(String.Format("[{0}] : |CRITICAL| {1}{2}", DateTime.Now.ToString("HH:mm:ss"), Data.ToString(), Environment.NewLine));
                        break;
                    default:
                        break;
                }
                LogStream.Write(LogData, 0, LogData.Length);
            }
            catch (Exception)
            {
            }
            finally
            {
                LogStream.Flush(true);
            }
        }
    }
}
