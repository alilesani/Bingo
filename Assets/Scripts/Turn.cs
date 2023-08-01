public struct Turn
{
    public int Number { get;}
    public Label Label { get;}

    public Turn(Label label, int number)
    {
        Number = number;
        Label = label;
    }

    public override string ToString() => $"{Label} {Number}";
}
