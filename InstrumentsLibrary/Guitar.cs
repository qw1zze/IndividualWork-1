namespace InstrumentsLibrary;

/// <summary>
/// Class Guitar, inherite from Instrument 
/// </summary>
public class Guitar : Instrument
{
    public Guitar(double volume, int mastery)
    {
         this.volume = volume;
         this.mastery = mastery;
    }

    /// <summary>
    /// Returns result of game.
    /// </summary>
    public override double Play()
    {
         return 2 * volume * 3 * mastery;
    }
    
    /// <summary>
    /// Returns information about object.
    /// </summary>
    public override string ToString()
    {
         return $"Guitar {Volume} {Mastery}";
    }
}