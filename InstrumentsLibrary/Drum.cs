namespace InstrumentsLibrary;

/// <summary>
/// Class Drum, inherite from Instrument 
/// </summary>
public class Drum : Instrument
{
    public Drum(double volume, int mastery)
    {
        this.volume = volume;
        this.mastery = mastery;
    }

    /// <summary>
    /// Returns result of game.
    /// </summary>
    public override double Play()
    {
        return 2 * volume * mastery;
    }

    /// <summary>
    /// Returns information about object.
    /// </summary>
    public override string ToString()
    {
        return $"Drum {Volume} {Mastery}";
    }
}