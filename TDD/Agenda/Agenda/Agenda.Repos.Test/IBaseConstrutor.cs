using AutoFixture;
using Moq;

namespace Agenda.Repos.Test
{
    public class IBaseConstrutor<T> where T : class
    {
        protected readonly Fixture _fixture;
        protected readonly Mock<T> _mock;

        protected IBaseConstrutor()
        {
            _fixture = new Fixture();
            _mock = new Mock<T>();
        }

        public T Construir()
        {
            return _mock.Object;
        }

        public Mock<T> ObterMock()
        {
            return _mock;
        }
    }
}
