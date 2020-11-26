using System;
using System.Diagnostics.Tracing;

namespace FrameworkEventListener
{
    public class ThreadPoolSchedulingEventListener : EventListener
    {
        private const long ThreadPoolKeyword = 0x0002;
        private static readonly Guid EventSourceGuid = Guid.Parse("8E9F5090-2D75-4d03-8A81-E5AFBF85DAF1");

        private readonly Action<string> _writer;

        public ThreadPoolSchedulingEventListener(Action<string> writer)
        {
            _writer = writer;
            EventSourceCreated += OnEventSourceCreated;
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            _writer($"EventId :{eventData.EventId} Payload[0]={eventData.Payload[0]}");
        }

        private void OnEventSourceCreated(object sender, EventSourceCreatedEventArgs e)
        {
            var es = e.EventSource;

            if (es?.Guid == EventSourceGuid)
            {
                EnableEvents(es, EventLevel.Verbose, (EventKeywords)ThreadPoolKeyword);
            }
        }

        public override void Dispose()
        {
            EventSourceCreated -= OnEventSourceCreated;
            base.Dispose();
        }
    }
}