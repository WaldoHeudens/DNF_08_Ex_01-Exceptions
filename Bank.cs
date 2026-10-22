namespace Bank;

/// <summary>
/// Eigen exception-klasse. Ze erft van <see cref="Exception"/> en draagt extra
/// context mee (het tekort), zodat de code die haar opvangt kan beslissen wat te doen.
/// </summary>
public class OnvoldoendeSaldoException : Exception
{
    public decimal Tekort { get; }

    public OnvoldoendeSaldoException(decimal tekort)
        : base($"Onvoldoende saldo. Tekort: {tekort:0.00}.")
    {
        Tekort = tekort;
    }
}

/// <summary>Een eenvoudige rekening waarvan je geld kan opnemen.</summary>
public class Rekening
{
    public decimal Saldo { get; private set; }

    public Rekening(decimal saldo) => Saldo = saldo;

    public void NeemOp(decimal bedrag)
    {
        // Guard clause: weiger ongeldige invoer meteen.
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(bedrag);

        if (bedrag > Saldo)
        {
            throw new OnvoldoendeSaldoException(bedrag - Saldo);
        }

        Saldo -= bedrag;
    }
}
