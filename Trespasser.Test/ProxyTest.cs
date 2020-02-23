namespace Trespasser.Test
{
    using Trespasser.Test.Classes;
    using Xbehave;
    using Xunit;

    public class ProxyTest
    {
        [Scenario]
        public void TestingProxy()
        {
            dynamic proxy = null;
            "Given a proxy of a class"
                .x(() => { proxy = Proxy.Create(new ClassUnderTest()); });

            "".x(() => { });

            "Then a private method can be called"
                .x(() =>
                {
                    proxy.PrivateMethod();
                    Assert.True(true);
                });

            "Then a protected method can be called"
                .x(() =>
                {
                    proxy.ProtectedMethod();
                    Assert.True(true);
                });

            "Then an internal method can be called"
                .x(() =>
                {
                    proxy.InternalMethod();
                    Assert.True(true);
                });

            "Then a get can be performed on a private property"
                .x(() =>
                {
                    var @value = proxy.PrivateProperty;
                    Assert.Equal(0, @value);
                });

            "Then a set can be performed on a private property"
                .x(() =>
                {
                    proxy.PrivateProperty = 1;
                    Assert.Equal(1, proxy.PrivateProperty);
                });

            "Then a get can be performed on a badly named property"
                .x(() =>
                {
                    var @value = proxy.badlyNamedProperty;
                    Assert.Equal(0, @value);
                });

            "Then a set can be performed on a badly named property"
                .x(() =>
                {
                    proxy.badlyNamedProperty = 1;
                    Assert.Equal(1, proxy.badlyNamedProperty);
                });

            "Then a get can be performed on a protected property"
                .x(() =>
                {
                    var @value = proxy.ProtectedProperty;
                    Assert.Equal(0, @value);
                });

            "Then a set can be performed on a protected property"
                .x(() =>
                {
                    proxy.ProtectedProperty = 1;
                    Assert.Equal(1, proxy.ProtectedProperty);
                });

            "Then a get can be performed on a internal property"
                .x(() =>
                {
                    var @value = proxy.InternalProperty;
                    Assert.Equal(0, @value);
                });

            "Then a set can be performed on a internal property"
                .x(() =>
                {
                    proxy.InternalProperty = 1;
                    Assert.Equal(1, proxy.InternalProperty);
                });

            "Then a get can be performed on a private field"
                .x(() =>
                {
                    var @value = proxy._privateField;
                    Assert.Equal(0, @value);
                });

            "Then a set can be performed on a private field"
                .x(() =>
                {
                    proxy._privateField = 1;
                    Assert.Equal(1, proxy._privateField);
                });

            "Then a get can be performed on a protected field"
                .x(() =>
                {
                    var @value = proxy.ProtectedField;
                    Assert.Equal(0, @value);
                });

            "Then a set can be performed on a protected field"
                .x(() =>
                {
                    proxy.ProtectedField = 1;
                    Assert.Equal(1, proxy.ProtectedField);
                });

            "Then a get can be performed on a badly named field"
                .x(() =>
                {
                    var @value = proxy.BadlyNamedField;
                    Assert.Equal(0, @value);
                });

            "Then a set can be performed on a badly named field"
                .x(() =>
                {
                    proxy.BadlyNamedField = 1;
                    Assert.Equal(1, proxy.BadlyNamedField);
                });

            "Then a get can be performed on a internal field"
                .x(() =>
                {
                    var @value = proxy.BadlyNamedField;
                    Assert.Equal(0, proxy.InternalField);
                });

            "Then a set can be performed on a internal field"
                .x(() =>
                {
                    proxy.InternalField = 1;
                    Assert.Equal(1, proxy.InternalField);
                });
        }

        [Scenario]
        public void TestingMethodsWithParameters()
        {
            dynamic proxy = null;
            ClassWithManyMethods classWithManyMethods = null;

            "Given a proxy of a class"
                .x(() =>
                {
                    classWithManyMethods = new ClassWithManyMethods();
                    proxy = Proxy.Create(classWithManyMethods);
                });

            "".x(() => { });

            "Then calling a method with a null param uses the override with a reference parameter"
                .x(() =>
                {
                    proxy.SomeMethod(null);

                    Assert.False(classWithManyMethods.MethodWithSingleValueParameterCalled);
                    Assert.True(classWithManyMethods.MethodWithSingleReferenceParameterCalled);
                });
        }

        [Scenario]
        public void TestingDerivedClasses()
        {
            dynamic proxy = null;
            DerivedClassUnderTest classWithManyMethods = null;

            "Given a proxy of a derived class"
                .x(() =>
                {
                    classWithManyMethods = new DerivedClassUnderTest();
                    proxy = Proxy.Create(classWithManyMethods);
                });

            "".x(() => { });

            "Then a private method can be called"
                .x(() =>
                {
                    proxy.PrivateMethod();
                    Assert.True(true);
                });

            "Then a protected method can be called"
                .x(() =>
                {
                    proxy.ProtectedMethod();
                    Assert.True(true);
                });

            "Then an internal method can be called"
                .x(() =>
                {
                    proxy.InternalMethod();
                    Assert.True(true);
                });

            "Then a get can be performed on a private property"
                .x(() =>
                {
                    var @value = proxy.PrivateProperty;
                    Assert.Equal(0, @value);
                });

            "Then a set can be performed on a private property"
            .x(() =>
                {
                    proxy.PrivateProperty = 1;
                    Assert.Equal(1, proxy.PrivateProperty);
                });

            "Then a get can be performed on a badly named property"
                .x(() =>
                {
                    var @value = proxy.badlyNamedProperty;
                    Assert.Equal(0, @value);
                });

            "Then a set can be performed on a badly named property"
                .x(() =>
                {
                    proxy.badlyNamedProperty = 1;
                    Assert.Equal(1, proxy.badlyNamedProperty);
                });

            "Then a get can be performed on a protected property"
                .x(() =>
                {
                    var @value = proxy.ProtectedProperty;
                    Assert.Equal(0, @value);
                });

            "Then a set can be performed on a protected property"
                .x(() =>
                {
                    proxy.ProtectedProperty = 1;
                    Assert.Equal(1, proxy.ProtectedProperty);
                });

            "Then a get can be performed on a internal property"
                .x(() =>
                {
                    var @value = proxy.InternalProperty;
                    Assert.Equal(0, @value);
                });

            "Then a set can be performed on a internal property"
                .x(() =>
                {
                    proxy.InternalProperty = 1;
                    Assert.Equal(1, proxy.InternalProperty);
                });

            "Then a get can be performed on a private field"
                .x(() =>
                {
                    var @value = proxy._privateField;
                    Assert.Equal(0, @value);
                });

            "Then a set can be performed on a private field"
                .x(() =>
                {
                    proxy._privateField = 1;
                    Assert.Equal(1, proxy._privateField);
                });

            "Then a get can be performed on a protected field"
                .x(() =>
                {
                    var @value = proxy.ProtectedField;
                    Assert.Equal(0, @value);
                });

            "Then a set can be performed on a protected field"
                .x(() =>
                {
                    proxy.ProtectedField = 1;
                    Assert.Equal(1, proxy.ProtectedField);
                });

            "Then a get can be performed on a badly named field"
                .x(() =>
                {
                    var @value = proxy.BadlyNamedField;
                    Assert.Equal(0, @value);
                });

            "Then a set can be performed on a badly named field"
                .x(() =>
                {
                    proxy.BadlyNamedField = 1;
                    Assert.Equal(1, proxy.BadlyNamedField);
                });

            "Then a get can be performed on a internal field"
                .x(() =>
                {
                    var @value = proxy.InternalField;
                    Assert.Equal(0, @value);
                });

            "Then a set can be performed on a internal field"
                .x(() =>
                {
                    proxy.InternalField = 1;
                    Assert.Equal(1, proxy.InternalField);
                });
        }


        [Scenario]
        public void TestingDerivedClassMethodsWithParameters()
        {
            dynamic proxy = null;
            DerivedClassUnderTest classWithManyMethods = null;

            "Given a proxy of a class"
                .x(() =>
                {
                    classWithManyMethods = new DerivedClassUnderTest();
                    proxy = Proxy.Create(classWithManyMethods);
                });

            "".x(() => { });

            "Then calling a method with a null param uses the override with a reference parameter"
                .x(() =>
                {
                    proxy.SomeMethod(null);

                    Assert.False(classWithManyMethods.MethodWithSingleValueParameterCalled);
                    Assert.True(classWithManyMethods.MethodWithSingleReferenceParameterCalled);
                });
        }
    }
}