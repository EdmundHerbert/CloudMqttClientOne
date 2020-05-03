namespace CloudMqttClientOne.MqttLib.Core.Messages
{
    internal class MqttPingReqMessage : MqttMessage
    {
        public MqttPingReqMessage() : base(MessageType.PINGREQ, 0)
        {
            // Nothing to construct
        }

        protected override void SendPayload(System.IO.Stream str)
        {
            // Nothing to send
        }

        protected override void ConstructFromStream(System.IO.Stream str)
        {
            // Nothing to construct
        }

    }
}
