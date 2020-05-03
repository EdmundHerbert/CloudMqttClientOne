

namespace CloudMqttClientOne.MqttLib
{
  /// <summary>
  /// An MQTT Control interface that attaches subscriptions to PublishArrivedDelegate's, allowing
  /// a single IMqttShared interface to be shared my decoupled applications with minimum additional
  /// application logic.
  /// </summary>
  public interface IMqttShared : IMqttPublisher, IMqttSharedSubscriber, IMqttConnectDisconnect
  {
  }
}
