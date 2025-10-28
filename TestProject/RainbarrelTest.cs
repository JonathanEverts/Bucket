using BucketClassLibrary.Models;

namespace TestProject
{
    public class RainbarrelTest
    {
        [Fact]
        public void DefaultRainbarrel_CapacitySmall()
        {
            Rainbarrel rainbarrel = new Rainbarrel(Capacity.Small);

            Assert.Equal(80, rainbarrel.Capacity);
        }

        [Fact]
        public void DefaultRainbarrel_CapacityMedium()
        {
            Rainbarrel rainbarrel = new Rainbarrel(Capacity.Medium);

            Assert.Equal(100, rainbarrel.Capacity);
        }

        [Fact]
        public void DefaultRainbarrel_CapacityLarge()
        {
            Rainbarrel rainbarrel = new Rainbarrel(Capacity.Large);

            Assert.Equal(120, rainbarrel.Capacity);
        }
    }
}
