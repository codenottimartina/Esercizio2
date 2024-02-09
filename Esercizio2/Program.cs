//indovina numero: sorteggiare un numero intero da 1 a 100 e tenerne traccia, chiedere ciclicamente all'utente di indovinare il numero.
//Se ciò che viene inserito non è un numero valido, segnalare l'errore all'utente proponendo poi un nuovo inserimento
//-Se indovina, stampare a video "hai vinto"
//-Se non indovina, viceversa, fornire un messaggio che indica se il numero inserito è maggiore o minore di quello da indovinare.
//-Ripetere ciclicamente questa operazione fino a che l'utente non riesce ad indovinare il numero.
//Inserendo invece una stringa vuota, il programma termina

Random rand = new Random();

int numSorteggiato = rand.Next(1, 100); // numero creato randomicamente

Console.WriteLine(numSorteggiato);

Console.WriteLine("Ciao! Indovina il numero che ho scelto [compreso tra 1-100]");

var stringaAcquisita = Console.ReadLine();

while(stringaAcquisita != "")
{
    int numeroInserito = 0;
    try
    {
        numeroInserito = Convert.ToInt32(stringaAcquisita);
    }
    catch
    {
        Console.WriteLine("Il valore inserito non è valido");
    }

    if(numeroInserito == numSorteggiato)
    {
        Console.WriteLine("Hai vinto!");
        return;
    }
    else
    {
        Console.WriteLine("Non hai indovinato :(");
        if(numeroInserito > numSorteggiato)
        {
            Console.WriteLine("Il numero che ho scelto è minore di " + numeroInserito);
        }else
        {
            Console.WriteLine("Il numero che ho scelto è maggiore di " + numeroInserito);
        }
        stringaAcquisita = Console.ReadLine();
    }
}