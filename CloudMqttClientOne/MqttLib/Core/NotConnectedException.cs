using System;

namespace CloudMqttClientOne.MqttLib.Core
{
    public class NotConnectedException : Exception
    {
        public NotConnectedException() : base() { }

        public NotConnectedException(string message) : base(message) { }
    }
}
