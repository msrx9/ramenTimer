namespace ramenTimer.Tests;

public class UnitTest1
{
    [Fact(DisplayName = "ToggleFlag(): TrueをFalseにトグル")]
    public void ToggleFlag_ShouldSetFlagTrueToFalse()
    {
        // Arrange
        bool flag = true;

        // Act
        var target = new FlagControl();

        // Assert
        Assert.False(target.Toggle(flag));
    }

    [Fact(DisplayName = "ToggleFlag(): FalseをTrueにトグル")]
    public void ToggleFlag_ShouldSetFlagFalseToTrue()
    {
        // Arrange
        bool flag = false;

        // Act
        var target = new FlagControl();

        // Assert
        Assert.True(target.Toggle(flag));
    }

    [Fact(DisplayName = "IsTimeout(): タイムアップ")]
    public void IsTimeoutTrue_ShouldReturnTrue()
    {
        // Arrange
        TimeOnly timer = new TimeOnly(1, 0);

        // Act
        var test = new FlagControl();
        var ret = test.IsTimeout(timer);

        // Assert
        Assert.True(ret);
    }

    [Fact(DisplayName = "IsTimeout(): カウント中")]
    public void IsTimeoutFalse_ShouldReturnTrue()
    {
        // Arrange
        TimeOnly timer = new TimeOnly(0, 0);
        int milliseconds = 1;
        timer = timer.Add(TimeSpan.FromMilliseconds(milliseconds));

        // Act
        var test = new FlagControl();
        var ret = test.IsTimeout(timer);

        // Assert
        Assert.False(ret);
    }
}
