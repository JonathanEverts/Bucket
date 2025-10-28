namespace BucketClassLibrary.Models
{
    public class Rainbarrel : Container
    {
        public Rainbarrel(Capacity capacity)
        {
            Capacity = (int)capacity;
        }
    }

    public enum Capacity
    {
        Small = 80,
        Medium = 100,
        Large = 120
    }
}
