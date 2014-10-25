using System.Text;
using Yak.Common;

namespace Yak.Sherpa.Lib.Tests.Infrastructure
{
    internal class DebugLog : ILog
    {
        private StringBuilder sb = new StringBuilder();

        public string CurrentContent
        {
            get
            {
                var current = sb.ToString();
                sb.Length = 0;
                return current;
            }
        }

        public void Debug(string message)
        {
            sb.AppendFormat("DEBUG: {0}", message).AppendLine();
        }

        public void Info(string message)
        {
            sb.AppendFormat("INFO: {0}", message).AppendLine();
        }

        public void Warn(string message)
        {
            sb.AppendFormat("WARN: {0}", message).AppendLine();
        }

        public void Error(string message)
        {
            sb.AppendFormat("ERROR: {0}", message).AppendLine();
        }
    }
}