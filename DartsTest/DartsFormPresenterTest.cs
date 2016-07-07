using Darts;
using Darts.ViewPresenter;
using NUnit.Framework;

namespace DartsTest
{
    [TestFixture]
    public class DartsFormPresenterTest
    {
        private DartsFormPresenter _dartsFormPresenter;
        private IDartsFormView _dartsForm;

        [SetUp]
        public void SetUp()
        {
            _dartsForm = new DartsFormStub();
            _dartsFormPresenter = new DartsFormPresenter(_dartsForm);
            _dartsFormPresenter.StartNewGame("player 1", "player 2");
        }

        [Test]
        public void EmptyStringValidationTest()
        {
            _dartsFormPresenter.AddScore("");
             
        }
    }
}