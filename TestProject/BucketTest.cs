using BucketClassLibrary.Models;
using BucketClassLibrary.Models.Exceptions;

namespace TestProject
{
    public class BucketTest
    {
        [Fact]
        public void DefaultBucket()
        {
            Bucket bucket = new Bucket();

            Assert.Equal(12, bucket.Capacity);
            Assert.Equal(0, bucket.Content);
        }

        [Theory]
        [InlineData(9, true)]
        [InlineData(10, false)]
        [InlineData(2500, false)]
        [InlineData(2501, true)]
        public void Bucket_HasBucketSizeException(int capacity, bool hasException)
        {
            if (hasException)
            {
                Assert.Throws<BucketSizeException>(() => new Bucket(capacity));
            }
            else
            {
                var ex = Record.Exception(() => new Bucket(capacity));
                Assert.Null(ex);
            }
        }

        [Theory]
        [InlineData(100, 100, -100, false)]
        [InlineData(100, 100, -101, true)]
        public void Bucket_HasEmptyContainerException(int capacity, int fill, int removeValue, bool hasException)
        {
            Bucket bucket = new Bucket(capacity);
            bucket.Fill(fill);

            if (hasException)
            {
                Assert.Throws<EmptyContainerException>(() => bucket.Fill(removeValue));
            }
            else
            {
                var ex = Record.Exception(() => bucket.Fill(removeValue));
                Assert.Null(ex);
            }
        }

        [Fact]
        public void DefaultBucket_EmptyBucket()
        {
            var bucket = new Bucket();
            bucket.Fill(10);

            Assert.Equal(10, bucket.Content);

            bucket.Empty();

            Assert.Equal(0, bucket.Content);
        }

        /*[Theory]
        [InlineData(100, 100, false)]
        [InlineData(100, 101, true)]
        [InlineData(2500, 2500, false)]
        [InlineData(2500, 2501, true)]
        public void Bucket_HasOverflowException(int capacity, int fill, bool hasException)
        {
            Bucket bucket = new Bucket(capacity);

            if (hasException)
            {
                Assert.Throws<OverflowException>(() => bucket.Fill(fill));
            }
            else
            {
                var ex = Record.Exception(() => bucket.Fill(fill));
                Assert.Null(ex);
            }
        }*/

        /*[Theory]
        [InlineData(5, false)]
        [InlineData(12, false)]
        [InlineData(13, true)]
        public void DefaultBucket_HasOverflowException(int fill, bool hasException)
        {
            Bucket bucket = new Bucket();

            if (hasException)
            {
                Assert.Throws<OverflowException>(() => bucket.Fill(fill));
            } else
            {
                var ex = Record.Exception(() => bucket.Fill(fill));
                Assert.Null(ex);
            }
        }*/
    }
}
