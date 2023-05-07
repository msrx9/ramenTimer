namespace ramenTimer.Tests;

public class UnitTest1
{
    [Fact(DisplayName = "Toggle(): TrueをFalseにトグル")]
    public void Toggle_ShouldSetFlagTrueToFalse()
    {
        // Arrange
        var flagControl = new FlagControl();
        bool flag = true;

        // Act
        var actual = flagControl.Toggle(flag);

        // Assert
        Assert.False(actual);
    }

    [Fact(DisplayName = "Toggle(): FalseをTrueにトグル")]
    public void Toggle_ShouldSetFlagFalseToTrue()
    {
        // Arrange
        var flagControl = new FlagControl();
        bool flag = false;

        // Act
        var actual = flagControl.Toggle(flag);

        // Assert
        Assert.True(actual);
    }

    [Fact(DisplayName = "IsTimeout(): タイムアップのためtrueを返す")]
    public void IsTimeoutTrue_ShouldReturnTrue()
    {
        // Arrange
        TimeOnly timer = new TimeOnly(1, 0);
        var flagControl = new FlagControl();


        // Act
        var ret = flagControl.IsTimeout(timer);

        // Assert
        Assert.True(ret);
    }

    [Fact(DisplayName = "IsTimeout(): カウント中のためfalseを返す")]
    public void IsTimeoutFalse_ShouldReturnTrue()
    {
        // Arrange
        TimeOnly timer = new TimeOnly(0, 0);
        int milliseconds = 1;
        timer = timer.Add(TimeSpan.FromMilliseconds(milliseconds));
        var flagControl = new FlagControl();


        // Act
        var ret = flagControl.IsTimeout(timer);

        // Assert
        Assert.False(ret);
    }
}
