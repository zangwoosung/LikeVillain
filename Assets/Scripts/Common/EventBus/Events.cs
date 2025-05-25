using System;

public interface IEvent { }

public struct TestEvent : IEvent { }

public struct PlayerEvent : IEvent
{
    public int health;
    public int mana;
    public Action myAction;
    public Func<int, int> myFunc;
}
public struct PlayerEvent01 : IEvent
{
    public Action myAction;
    public Func<int, int> myFunc;
    public int health;
    public int mana;
}