using AutoFixture;

namespace CarInsurance.Test
{
    public abstract class BaseTest
    {
        public Fixture _fixture;

        protected void GetInMemory()
        {

            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }
    }
}
