namespace Trespasser.Test
{
    using SubSpec;
    using Trespasser.Test.Classes;
    using Xunit;

    public class ProxyTest
    {
        [Specification]
        public void TestingProxy()
        {
            dynamic proxy = null;
            "Given a proxy of a static class"
                .Context(() =>
                         {
                             proxy = Proxy.Create(new ClassUnderTest());
                         });

            "".Do(() => { });

            "Then a private method can be called"
                .Assert(() =>
                        {
                            proxy.PrivateMethod();
                            Assert.True(true);
                        });

            "Then a protected method can be called"
                .Assert(() =>
                        {
                            proxy.ProtectedMethod();
                            Assert.True(true);
                        });

            "Then an internal method can be called"
                .Assert(() =>
                        {
                            proxy.InternalMethod();
                            Assert.True(true);
                        });

            "Then a get can be performed on a private property"
                .Observation(() => Assert.Equal(0, proxy.PrivateProperty));

            "Then a set can be performed on a private property"
                .Assert(() =>
                        {
                            proxy.PrivateProperty = 1;
                            Assert.Equal(1, proxy.PrivateProperty);
                        });

            "Then a get can be performed on a badly named property"
                .Observation(() => Assert.Equal(0, proxy.badlyNamedProperty));

            "Then a set can be performed on a badly named property"
                .Assert(() =>
                        {
                            proxy.badlyNamedProperty = 1;
                            Assert.Equal(1, proxy.badlyNamedProperty);
                        });

            "Then a get can be performed on a protected property"
                .Observation(() => Assert.Equal(0, proxy.ProtectedProperty));

            "Then a set can be performed on a protected property"
                .Assert(() =>
                        {
                            proxy.ProtectedProperty = 1;
                            Assert.Equal(1, proxy.ProtectedProperty);
                        });

            "Then a get can be performed on a internal property"
                .Observation(() => Assert.Equal(0, proxy.InternalProperty));

            "Then a set can be performed on a internal property"
                .Assert(() =>
                        {
                            proxy.InternalProperty = 1;
                            Assert.Equal(1, proxy.InternalProperty);
                        });

            "Then a get can be performed on a private field"
                .Observation(() => Assert.Equal(0, proxy._privateField));

            "Then a set can be performed on a private field"
                .Assert(() =>
                        {
                            proxy._privateField = 1;
                            Assert.Equal(1, proxy._privateField);
                        });

            "Then a get can be performed on a protected field"
                .Observation(() => Assert.Equal(0, proxy.ProtectedField));

            "Then a set can be performed on a protected field"
                .Assert(() =>
                        {
                            proxy.ProtectedField = 1;
                            Assert.Equal(1, proxy.ProtectedField);
                        });

            "Then a get can be performed on a badly named field"
                .Observation(() => Assert.Equal(0, proxy.BadlyNamedField));

            "Then a set can be performed on a badly named field"
                .Assert(() =>
                        {
                            proxy.BadlyNamedField = 1;
                            Assert.Equal(1, proxy.BadlyNamedField);
                        });

            "Then a get can be performed on a internal field"
                .Observation(() => Assert.Equal(0, proxy.InternalField));

            "Then a set can be performed on a internal field"
                .Assert(() =>
                        {
                            proxy.InternalField = 1;
                            Assert.Equal(1, proxy.InternalField);
                        });
        }
    }
}