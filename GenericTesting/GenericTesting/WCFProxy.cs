using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace GenericTesting
{
  public sealed class WCFProxy<TContract> : IDisposable where TContract : class
  {
    private ChannelFactory<TContract> _channelFactory;
    private TContract _channel;

    public WCFProxy()
    {
      _channelFactory = new ChannelFactory<TContract>();
    }

    public WCFProxy(Binding binding, string remoteAddress)
    {
      _channelFactory = new ChannelFactory<TContract>(binding, remoteAddress);
    }

    public void Execute(Action<TContract> action)
    {
      action.Invoke(Channel);
    }

    public TResult Execute<TResult>(Func<TContract, TResult> function)
    {
      return function.Invoke(Channel);
    }

    private TContract Channel
    {
      get
      {
        if (_channel == null)
        {
          _channel = _channelFactory.CreateChannel();
        }

        return _channel;
      }
    }

    public void Dispose()
    {
      try
      {
        if (_channel != null)
        {
          var currentChannel = _channel as IClientChannel;
          if (currentChannel.State == CommunicationState.Faulted) { currentChannel.Abort(); }
          else { currentChannel.Close(); }
        }
      }
      finally
      {
        _channel = null;
        _channelFactory.Close();
        _channelFactory = null;
        GC.SuppressFinalize(this);
      }
    }
  }
}
