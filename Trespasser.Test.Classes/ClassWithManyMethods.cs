namespace Trespasser.Test.Classes
{
    public class ClassWithManyMethods
    {
        public bool MethodWithSingleValueParameterCalled { get; set; }
        public bool MethodWithSingleReferenceParameterCalled { get; set; }

        private void SomeMethod(int paramOne)
        {
            MethodWithSingleValueParameterCalled = true;
        }

        private void SomeMethod(object paramOne)
        {
            MethodWithSingleReferenceParameterCalled = true;
        }
    }
}