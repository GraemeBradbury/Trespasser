namespace Trespasser.Test
{
    using Trespasser.Test.Classes;
    using Xbehave;
    using Xunit;

    public class ProxyOfTTest
    {
        [Scenario]
        public void TestingStaticClasses()
        {
            dynamic proxy = null;
            "Given a proxy of a static class"
                .x(() => { proxy = Proxy.Static<ClassUnderTest>(); });

            "".x(() => { });

            "Then a static method can be called"
                .x(() =>
               {
                   proxy.StaticMethod();
                   Assert.True(true);
               });

            "Then a static property can be called"
                .x(() =>
                {
                    var @value = proxy.StaticProperty;
                    Assert.Equal(0, @value);
                });

            "Then a static property can be set"
                .x(() =>
                {
                    proxy.StaticProperty = 1;
                    Assert.Equal(1, proxy.StaticProperty);
                });

            "Then a get can be performed on a field"
                .x(() =>
                {
                    var @value = proxy._staticField;
                    Assert.Equal(0, @value);
                });

            "Then a set can be performed on a field"
                .x(() =>
                {
                    proxy._staticField = 1;
                    Assert.Equal(1, proxy._staticField);
                });
        }
    }
}