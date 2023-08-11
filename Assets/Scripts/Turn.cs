using System;
public struct Turn : IComparable
{
    public int Number { get; }
    public Label Label { get; }

    public Turn(Label label, int number)
    {
        Number = number;
        Label = label;
    }

    public override string ToString() => $"{Label} {Number}";

    public int CompareTo(object turn)
    {
        return this.ToString().CompareTo(turn.ToString());
    }
}
