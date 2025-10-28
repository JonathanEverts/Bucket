using BucketClassLibrary.Models;

namespace TestProject
{
    public class OilbarrelTest
    {
        [Fact]
        public void DefaultOilbarrel()
        {
            Oilbarrel oilbarrel = new Oilbarrel();

            Assert.Equal(159, oilbarrel.Capacity);
            Assert.Equal(0, oilbarrel.Content);
        }
    }
}
