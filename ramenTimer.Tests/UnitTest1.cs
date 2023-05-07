namespace ramenTimer.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var target = new MyClass();
        Assert.Equal(1, target.MyMethod());
    }
}
