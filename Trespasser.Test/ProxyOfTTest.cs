namespace Trespasser.Test
{
    using SubSpec;
    using Trespasser.Test.Classes;
    using Xunit;

    public class ProxyOfTTest
    {
        [Specification]
        public void TestingStaticClasses()
        {
            dynamic proxy = null;
            "Given a proxy of a static class"
                .Context(() => { proxy = Proxy.Static<ClassUnderTest>(); });

            "".Do(() => { });

            "Then a static method can be called".
                Assert(() =>
                       {
                           proxy.StaticMethod();
                           Assert.True(true);
                       });

            "Then a static property can be called"
                .Assert(() => Assert.Equal(0, proxy.StaticProperty));

            "Then a static property can be set"
                .Assert(() =>
                        {
                            proxy.StaticProperty = 1;
                            Assert.Equal(1, proxy.StaticProperty);
                        });

            "Then a get can be performed on a field"
                .Assert(() => Assert.Equal(0, proxy._staticField));

            "Then a set can be performed on a field"
                .Assert(() =>
                        {
                            proxy._staticField = 1;
                            Assert.Equal(1, proxy._staticField);
                        });
        }
    }
}