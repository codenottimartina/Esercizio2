//indovina numero: sorteggiare un numero intero da 1 a 100 e tenerne traccia, chiedere ciclicamente all'utente di indovinare il numero.
//Se ciò che viene inserito non è un numero valido, segnalare l'errore all'utente proponendo poi un nuovo inserimento
//-Se indovina, stampare a video "hai vinto"
//-Se non indovina, viceversa, fornire un messaggio che indica se il numero inserito è maggiore o minore di quello da indovinare.
//-Ripetere ciclicamente questa operazione fino a che l'utente non riesce ad indovinare il numero.
//Inserendo invece una stringa vuota, il programma termina

Random rand = new Random();

int numSorteggiato = rand.Next(1, 100); // numero creato randomicamente

Console.WriteLine(numSorteggiato);

int? numeroInserito = Utilities.AcquisisciInteroDaConsole("Ciao! Indovina il numero che ho scelto [compreso tra 1-100]", 1, 100);

while(numeroInserito != null)
{

    if(Utilities.CheckVittoria(numeroInserito.Value, numSorteggiato))
    {
        break;
    }

    numeroInserito = Utilities.AcquisisciInteroDaConsole("Riprova: ", 1, 100);
}

class Utilities
{
    public static int? AcquisisciInteroDaConsole(string messsaggioUtente, int min, int max)
    {
        int numeroInserito;
        Console.WriteLine(messsaggioUtente);
        var stringaAcquisita = Console.ReadLine();
        if(stringaAcquisita == "")
        {
            return null;
        }

        try
        {
            numeroInserito = Convert.ToInt32(stringaAcquisita);
        }
        catch
        {
            Console.WriteLine("Attenzione, il valore inserito non è valido");
            return AcquisisciInteroDaConsole(messsaggioUtente, min, max);
        }

        if(!(
            _checkValoreMinoreSogliaMax(numeroInserito, max) 
            && _checkValoreMaggioreSogliaMin(numeroInserito, min)
            ))
        {
            return AcquisisciInteroDaConsole(messsaggioUtente, min, max);
        }

        return numeroInserito;
    }

    private static bool _checkValoreMaggioreSogliaMin(int numeroInserito, int min)
    {
        if(numeroInserito < min)
        {
            Console.WriteLine("Attenzione, il valore non può essere minore di " + min);
            return false;
        }

        return true;
    }

    private static bool _checkValoreMinoreSogliaMax(int numeroInserito, int max)
    {
        if (numeroInserito > max)
        {
            Console.WriteLine("Attenzione, il valore non può essere maggiore di " + max);
            return false;
        }

        return true;
    }

    public static bool CheckVittoria(int numeroInserito, int numeroSorteggiato)
    {
        if(numeroInserito == numeroSorteggiato)
        {
            Console.WriteLine("Complimenti, Hai vinto!");
            return true;
        }
        else
        {
            Console.WriteLine("Non hai indovinato :(");
            if (numeroInserito > numeroSorteggiato)
            {
                Console.WriteLine("Il numero che ho scelto è minore di " + numeroInserito);
            }
            else
            {
                Console.WriteLine("Il numero che ho scelto è maggiore di " + numeroInserito);
            }

            return false;
        }
    }
}