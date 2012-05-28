namespace Trespasser.Test.Classes
{
    public class DerivedClassUnderTest : BaseClassUnderTest
    {
    }

    public abstract class BaseClassUnderTest
    {
        public bool PublicPrivate { get; private set; }
    }
}