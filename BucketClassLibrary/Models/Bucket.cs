using BucketClassLibrary.Models.Exceptions;

namespace BucketClassLibrary.Models
{
    public class Bucket : Container
    {
        public Bucket()
        {
            Capacity = 12;
        }

        public Bucket(int capacity)
        {
            if (capacity < 10) throw new BucketSizeException("De capaciteit is te klein");
            if (capacity > 2500) throw new BucketSizeException("De capaciteit is te groot");

            Capacity = capacity;
        }

        public void Fill(Bucket bucket)
        {
            Fill(bucket.Content);
        }
    }
}
