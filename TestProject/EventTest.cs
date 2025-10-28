using BucketClassLibrary.Models;
using System.Diagnostics.Metrics;
using static BucketClassLibrary.Models.Container;

namespace TestProject
{
    public class EventTest
    {
        [Fact]
        public void Bucket_HasFullEvent()
        {
            //Arrange
            Bucket bucket = new Bucket();
            bool eventFired = false;
            object? eventSender = null;
            EventArgs? eventArgs = null;

            bucket.Full += (sender, args) =>
            {
                eventFired = true;
                eventSender = sender;
                eventArgs = args;
            };

            var senderObject = bucket;
            var argsObject = EventArgs.Empty;

            //Act
            bucket.OnFull(argsObject);

            //Assert
            Assert.True(eventFired);
            Assert.Equal(senderObject, eventSender);
            Assert.Equal(argsObject, eventArgs);
        }

        [Fact]
        public void Bucket_HasOverflowingEvent()
        {
            //Arrange
            Bucket bucket = new Bucket();
            int? allowedOverflowAmount = null;

            bucket.Overflowing += (sender, args) =>
            {
                allowedOverflowAmount = args.AllowedOverflowAmount;
            };

            //Act
            bucket.Fill(14);

            //Assert
            Assert.NotNull(allowedOverflowAmount);
            Assert.Equal(0, allowedOverflowAmount);
        }

        [Fact]
        public void Bucket_HasOverflowedEvent()
        {
            //Arrange
            Bucket bucket = new Bucket();
            int? overflowAmount = null;

            bucket.Overflowed += (sender, args) =>
            {
                overflowAmount = args.OverflowAmount;
            };

            //Act
            bucket.Fill(14);

            //Assert
            Assert.NotNull(overflowAmount);
            Assert.Equal(2, overflowAmount);
        }
    }
}
