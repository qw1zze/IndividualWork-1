namespace InstrumentsLibrary;

/// <summary>
/// Class Instrument, consider common information about instruments.
/// </summary>
public class Instrument
{

    private protected double volume;
    private protected int mastery;
    
    public double Volume
    {
        get
        {
            return volume;
        }
    }

    public int Mastery
    {
        get
        {
            return mastery;
        }
    }

    /// <summary>
    /// Returns result of game.
    /// </summary>
    public virtual double Play()
    {
        return volume * mastery;
    }
}