using System;
using System.Numerics;

namespace Botiga
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nElem = -1, aux = 0, aux1 = 0, quantitat = 0;
            string[] productes = new string[1]; string user = "", P433 = "123", opcioString = "", sino = "", compraTornar = "", producteComprar = "", cistella = "", cistellaTicet = "", filtrarProductePreu = "";//qxNspZYt0DcUQ4pIsUqEV7IweebFyn9nJXdf8Tby02qH8C8tS9
            double[] preus = new double[1]; double saldo = 0, preuTotal = 0, AfegirSaldo = 0;
            bool tancarSessio = true, tancarSessioIntern = true, tancarSessioIntern2 = true;
            while (tancarSessio)
            {
                IniciarSessio();
                user = Console.ReadLine().ToLower();
                switch (user)
                {
                    case "administrador":
                        int intents = 3; bool passwdCorrecte = false;
                        while (intents >= 0 && !passwdCorrecte)
                        {
                            Console.WriteLine("Escrigui la contrasenya:");
                            string contrasenya = Console.ReadLine();
                            if (contrasenya == P433)
                            {
                                passwdCorrecte = true;
                                tancarSessioIntern = true;
                                for (int i = 3; i >= 0; i--)
                                {
                                    Console.Write("\r");
                                    Console.Write($"Inician't Sessió... {i}");
                                    Thread.Sleep(1000);
                                }
                                BorrarConsola();
                                while (tancarSessioIntern)
                                {
                                    Administrador();
                                    Console.Write("Quina opció vols escollir? ");
                                    opcioString = Console.ReadLine();
                                    if (opcioString == "Q" || opcioString == "q")
                                    {
                                        Console.WriteLine("D'acord tancant la sessió");
                                        tancarSessioIntern = false;

                                        RetornTresSegons();
                                        BorrarConsola();
                                    }
                                    else if (!ValidarOpcio(opcioString))
                                    {
                                        Console.WriteLine("No has escollit una opció de les possibles.");
                                        opcioString = "";
                                        RetornCincSegons();
                                        BorrarConsola();
                                    }
                                    else
                                    {
                                        aux = Convert.ToInt32(opcioString);
                                        opcioString = "";
                                        switch (aux)
                                        {
                                            case 1:
                                                BorrarConsola();
                                                CapcaleraProductes();
                                                string nouProducte; double nouPreu; bool acabar = false, espais = false, afegirProductes = false;
                                                while (!acabar)
                                                {
                                                    acabar = false; afegirProductes = false;
                                                    Console.WriteLine("Com s'anomenarà el producte que vols afegir?");
                                                    nouProducte = Console.ReadLine();
                                                    Console.WriteLine("A quin preu el vols possar?");
                                                    nouPreu = Convert.ToDouble(Console.ReadLine());
                                                    ComprovarEspais(productes, preus, ref nElem, ref espais);
                                                    if (espais)
                                                    {
                                                        AfegirProducte(productes, preus, ref nElem, nouProducte, nouPreu);
                                                        Console.WriteLine($"S'ha afegit el producte '{nouProducte}' amb preu '{nouPreu}'");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("No hi ha suficients espais, vols afegir-n'he?");
                                                        sino = Console.ReadLine();
                                                        if ("NONono".Contains(sino))
                                                        {
                                                            acabar = true;
                                                        }
                                                        else if ("SISisi".Contains(sino))
                                                        {
                                                            Console.WriteLine("D'acord");
                                                            AmpliarBotiga(ref productes, ref preus, nElem);
                                                            AfegirProducte(productes, preus, ref nElem, nouProducte, nouPreu);
                                                            Console.WriteLine($"S'ha afegit el producte '{nouProducte}' amb preu '{nouPreu}'");
                                                        }
                                                    }
                                                    while (!afegirProductes)
                                                    {
                                                        Console.WriteLine("Vols afegir més productes?");
                                                        sino = Console.ReadLine();
                                                        if ("NONono".Contains(sino))
                                                        {
                                                            acabar = true;
                                                            afegirProductes = true;
                                                        }
                                                        else if ("SISisi".Contains(sino))
                                                        {
                                                            Console.WriteLine("D'acord");
                                                            afegirProductes = true;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("No has escollit una de les opcions possibles"); 
                                                        }
                                                    }
                                                    BorrarConsola();
                                                }
                                                BorrarConsola();
                                                break;
                                            case 2:
                                                BorrarConsola();
                                                CapcaleraEspais();
                                                AmpliarBotiga(ref productes, ref preus, nElem);
                                                break;
                                            case 3:
                                                BorrarConsola();
                                                CapcaleraModificarProducte();
                                                ModificarProducte(productes, preus, nElem);
                                                break;
                                            case 4:
                                                BorrarConsola();
                                                CapcaleraModificarPreu();
                                                Modificarpreu(productes, preus, nElem);
                                                break;
                                            case 5:
                                                BorrarConsola();
                                                acabar = false;
                                                while (!acabar)
                                                {
                                                    CapcaleraMostrar();
                                                    MostrarBotiga(productes, preus, nElem);
                                                    Console.WriteLine("Vols tornar?");
                                                    sino = Console.ReadLine();
                                                    if ("SISisi".Contains(sino))
                                                    {
                                                        acabar = true;
                                                    }
                                                }
                                                RetornCincSegons();
                                                BorrarConsola();
                                                break;
                                            case 6:
                                                BorrarConsola();
                                                acabar = false;
                                                while (!acabar)
                                                {
                                                    CapcaleraMostrar();
                                                    BotigaToString(productes, preus, nElem);
                                                    Console.WriteLine("Vols tornar?");
                                                    sino = Console.ReadLine();
                                                    if ("SISisi".Contains(sino))
                                                    {
                                                        acabar = true;
                                                    }
                                                }
                                                RetornCincSegons();
                                                BorrarConsola();
                                                break;
                                            default: Console.WriteLine("No has escollit una de les opcions possibles."); break;
                                        }
                                    }
                                }
                            }
                        }
                        break;                 
                    case "usuari":
                        tancarSessioIntern2 = true;
                        for (int i = 3; i >= 0; i--)
                        {
                            Console.Write("\r");
                            Console.Write($"Inician't Sessió... {i}");
                            Thread.Sleep(1000);
                        }
                        BorrarConsola();
                        while (tancarSessioIntern2)
                        {
                            Usuari(saldo);
                            Console.Write("Quina opció vols escollir? ");
                            opcioString = Console.ReadLine();
                            if (opcioString == "Q" || opcioString == "q")
                            {
                                Console.WriteLine("D'acord tancant la sessió");
                                tancarSessioIntern2 = false;
                                opcioString = "";
                                RetornTresSegons();
                                BorrarConsola();
                            }
                            else if (!ValidarOpcio(opcioString))
                            {
                                Console.WriteLine("No has escollit una opció de les possibles.");
                                opcioString = "";
                                RetornCincSegons();
                                BorrarConsola();
                            }
                            else
                            {
                                BorrarConsola();
                                aux1 = Convert.ToInt32(opcioString);
                                opcioString = "";
                                switch (aux1)
                                {
                                    case 1:
                                        bool espais = false, acabar = false;
                                        while (!acabar)
                                        {
                                            CapcaleraMostrar();
                                            MostrarBotiga(productes, preus, nElem);
                                            Console.WriteLine("Vols realitzar una comprar, tornar al menu o filtrar els productes? (Escrigui 'Compra' / 'Tornar' / 'Filtrar'):");
                                            compraTornar = Console.ReadLine().ToLower(); ;
                                            switch (compraTornar)
                                            {
                                                case "compra":
                                                    Console.WriteLine("Quin producte vols comprar?");
                                                    producteComprar = Console.ReadLine();
                                                    Console.WriteLine($"Quants {producteComprar} vols comprar?");
                                                    quantitat = Convert.ToInt32(Console.ReadLine());
                                                    AfegirProducteCistella(productes, preus, nElem, producteComprar, ref cistella, ref preuTotal, ref saldo, quantitat);
                                                    RetornTresSegons();
                                                    BorrarConsola();
                                                    break;
                                                case "tornar":
                                                    Console.WriteLine("D'acord tornant");
                                                    acabar = true;
                                                    break;
                                                case "filtrar":
                                                    Console.WriteLine("Com vols filtar per productes o per preus?");
                                                    filtrarProductePreu = Console.ReadLine().ToLower(); ;
                                                    switch (filtrarProductePreu)
                                                    {
                                                        case "productes":
                                                            Console.WriteLine("D'acord filtrant per producte.");
                                                            for (int i = 3; i >= 0; i--)
                                                            {
                                                                Console.Write("\r");
                                                                Console.Write($"Filtran't productes... {i}");
                                                                Thread.Sleep(1000);
                                                            }
                                                            OrdenarProducteSeleccio(productes, preus, nElem);
                                                            break;
                                                        case "preus":
                                                            Console.WriteLine("D'acord filtrant per preu.");
                                                            for (int i = 3; i >= 0; i--)
                                                            {
                                                                Console.Write("\r");
                                                                Console.Write($"Filtran't preus... {i}");
                                                                Thread.Sleep(1000);
                                                            }
                                                            OrdenarPreuSeleccio(productes, preus, nElem);
                                                            break;
                                                        default:
                                                            Console.WriteLine("Has d'escollir preu o producte.");
                                                            break;
                                                    }
                                                    BorrarConsola();
                                                    break;
                                                default:
                                                    Console.WriteLine("No has escollit una de les opcions possibles.");
                                                    RetornTresSegons();
                                                    BorrarConsola();
                                                    break;
                                            }
                                        }
                                        RetornCincSegons();
                                        BorrarConsola();
                                        break;
                                    case 2:
                                        BorrarConsola();
                                        acabar = false;
                                        string opcio;
                                        while (!acabar)
                                        {
                                            CapcaleraMostrar();
                                            MostrarBotiga(productes, preus, nElem);
                                            Console.WriteLine("Com vols ordenar els productes, per preu o per producte:");
                                            opcio = Console.ReadLine().ToLower();
                                            switch (opcio)
                                            {
                                                case "producte":
                                                    for (int i = 3; i >= 0; i--)
                                                    {
                                                        Console.Write("\r");
                                                        Console.Write($"Filtran't productes... {i}");
                                                        Thread.Sleep(1000);
                                                    }
                                                    OrdenarProducteSeleccio(productes, preus, nElem);
                                                    break;
                                                case "preu":
                                                    for (int i = 3; i >= 0; i--)
                                                    {
                                                        Console.Write("\r");
                                                        Console.Write($"Filtran't productes per preu... {i}");
                                                        Thread.Sleep(1000);
                                                    }
                                                    OrdenarPreuSeleccio(productes, preus, nElem);
                                                    break;
                                            }
                                            Console.WriteLine("\n");
                                            Console.WriteLine("Vols tornar?");
                                            sino = Console.ReadLine();
                                            if ("SISisi".Contains(sino))
                                            {
                                                acabar = true;
                                            }
                                        }
                                        RetornCincSegons();
                                        BorrarConsola();
                                        break;
                                    case 3:
                                        acabar = false;
                                        BorrarConsola();
                                        while (!acabar)
                                        {
                                            CapcaleraCistella();
                                            Console.WriteLine("LLista de productes per comprar:");
                                            Console.WriteLine("\n");
                                            Console.Write(cistella);
                                            Console.WriteLine("\n");
                                            Console.WriteLine("Vols tornar?");
                                            sino = Console.ReadLine();
                                            if ("SISisi".Contains(sino))
                                            {
                                                acabar = true;
                                            }
                                        }                                        
                                        BorrarConsola();
                                        break;
                                    case 4:
                                        acabar = false;
                                        BorrarConsola();
                                        while (!acabar)
                                        {
                                            CapcaleraCistella();
                                            Console.WriteLine("LLista de productes per comprar:");
                                            Console.WriteLine("\n");
                                            Console.Write(cistella);
                                            Console.WriteLine("\n");
                                            Console.WriteLine("Vols Finalitzar la compra?");
                                            sino = Console.ReadLine();
                                            if ("SISisi".Contains(sino))
                                            {
                                                for (int i = 3; i >= 0; i--)
                                                {
                                                    Console.Write("\r");
                                                    Console.Write($"Creant ticket de compra... {i}");
                                                    Thread.Sleep(1000);
                                                }
                                                cistellaTicet = cistella;
                                                cistella = "";
                                                acabar = true;
                                            }
                                            else if ("NONono".Contains(sino))
                                            {
                                                Console.WriteLine("Vols tornar?");
                                                sino = Console.ReadLine();
                                                if ("SISisi".Contains(sino))
                                                {
                                                    acabar = true;
                                                }
                                                else if ("NONono".Contains(sino))
                                                {
                                                    Console.WriteLine("D'acord");
                                                }
                                                else
                                                {
                                                    Console.WriteLine("M'has descriure 'Si' o 'No'");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("M'has descriure 'Si' o 'No'");
                                            }
                                        }
                                        RetornTresSegons();
                                        BorrarConsola();
                                        break;
                                    case 5:
                                        acabar = false;
                                        BorrarConsola();
                                        CapcaleraSaldo();

                                        while (!acabar)
                                        {
                                            Console.WriteLine($"Saldo Actual {saldo,8:F2}:");
                                            Console.WriteLine("\n");
                                            Console.WriteLine("Quant de saldo vols afegir?");
                                            AfegirSaldo = Convert.ToDouble(Console.ReadLine());
                                            for (int i = 3; i >= 0; i--)
                                            {
                                                Console.Write("\r");
                                                Console.Write($"Afegin't saldo... {i}");
                                                Thread.Sleep(1000);
                                            }
                                            Console.WriteLine("\n");
                                            saldo += AfegirSaldo;
                                            Console.WriteLine($"Afegit {AfegirSaldo} al moneder...");
                                            Console.WriteLine("\n");
                                            Console.WriteLine("Vols afegir més saldo?");
                                            sino = Console.ReadLine();
                                            if ("NONono".Contains(sino))
                                            {
                                                Console.WriteLine("D'acord tornant");
                                                acabar = true;
                                            }
                                            else
                                            {
                                                Console.WriteLine("D'acord");
                                            }
                                        }
                                        RetornTresSegons();
                                        BorrarConsola();
                                        break;
                                    case 6:
                                        acabar = false;
                                        while (!acabar)
                                        {
                                            CapcaleraTicket();
                                            TicketFinal(cistellaTicet, preuTotal, quantitat);
                                            Console.WriteLine("Vols tornar?");
                                            sino = Console.ReadLine();
                                            if ("SISisi".Contains(sino))
                                            {
                                                acabar = true;
                                            }
                                        }
                                        BorrarConsola();
                                        break;
                                    default: Console.WriteLine("No has escollit una de les opcions possibles."); break;
                                }
                            }
                        }
                        break;

                    case "sortir":

                        Console.WriteLine("D'acord, ens veiem.");
                        tancarSessio = false;
                        break;

                    default:

                        Console.WriteLine("No has escollit una opció valida.");
                        RetornTresSegons();
                        BorrarConsola();
                        break;
                }
            }

        }
        static void IniciarSessio()
        {
            ConsolaFons();
            CapcaleraInici();
            MenuIniciText();
        }
        static void Administrador()
        {
            ConsolaFons();
            CapcaleraAdmin();
            MenuTextAdmin();
        }
        static void Usuari(double saldo)
        {
            ConsolaFons();
            CapcaleraUsuari();
            MenuTextClient(saldo);
        }
        static void CapcaleraInici()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                     INICIAR SESSIO                         ");
            Console.WriteLine("\r");
            Console.WriteLine("\r");
            return;
        }
        static void CapcaleraAdmin()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                      ADMINSTRADOR                         ");
            Console.WriteLine("\r");
            Console.WriteLine("\r");
            return;
        }
        static void CapcaleraUsuari()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                          USUARI                         ");
            Console.WriteLine("\r");
            Console.WriteLine("\r");
            return;
        }
        static void CapcaleraProductes()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                       AFEGIR PRODUCTES                         ");
            Console.WriteLine("\r");
            Console.WriteLine("\r");
            return;
        }
        static void CapcaleraEspais()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                       AFEGIR ESPAIS                         ");
            Console.WriteLine("\r");
            Console.WriteLine("\r");
            return;
        }
        static void CapcaleraModificarProducte()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                     MODIFICAR PRODUCTES                         ");
            Console.WriteLine("\r");
            Console.WriteLine("\r");
            return;
        }
        static void CapcaleraModificarPreu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                      MODIFICAR PREU                         ");
            Console.WriteLine("\r");
            Console.WriteLine("\r");
            return;
        }
        static void CapcaleraMostrar()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                     MOSTRAR PRODUCTES                         ");
            Console.WriteLine("\r");
            Console.WriteLine("\r");
            return;
        }
        static void CapcaleraSaldo()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                       AFEGIR SALDO                         ");
            Console.WriteLine("\r");
            Console.WriteLine("\r");
            return;
        }
        static void CapcaleraCistella()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                   CISTELLA DE PRODUCTES                         ");
            Console.WriteLine("\r");
            Console.WriteLine("\r");
            return;
        }
        static void CapcaleraTicket()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                       TICKET DE COMPRA                        ");
            Console.WriteLine("\r");
            Console.WriteLine("\r");
            return;
        }
        static string MenuTextAdmin() // Aquest es el menu en text
        {
            string text;
            text = "╔═══════════════════════════════════════════════════════╗\n" +
                   "║                        OPCIONS                        ║\n" +
                   "╠═══════════════════════════════════════════════════════╣\n" +
                   "║                                                       ║\n" +
                   "║                  1 - AFEGIR PRODUCTES                 ║\n" +
                   "║                  2 - AFEGIR ESPAIS                    ║\n" +
                   "║                  3 - MODIFICAR PRODUCTE               ║\n" +
                   "║                  4 - MODIFICAR PREU                   ║\n" +
                   "║                  5 - MOSTRAR BOTIGA                   ║\n" +
                   "║                  6 - BOTIGA TEXT                      ║\n" +
                   "║                  Q - TANCAR SESSIO                    ║\n" +
                   "║                                                       ║\n" +
                   "╚═══════════════════════════════════════════════════════╝";
            Console.WriteLine(text);

            return text;
        }
        static string MenuTextClient(double saldo) // Aquest es el menu en text
        {
            string espais = "";
            for (int i = 0; i < 9 - saldo.ToString().Length; i++)
                espais += " ";
            string text =
                   "╔═══════════════════════════════════════════════════════╗\n" +
                   "║                        OPCIONS                        ║\n" +
                   "╠═════════════════════════════════════╦═════════════════╣\n" +
                  $"║                                     ║ SALDO: {saldo}" + espais + "║\n" +
                   "║                                     ╚═════════════════╣\n" +
                   "║                                                       ║\n" +
                   "║                  1 - PRODUCTES                        ║\n" +
                   "║                  2 - ORDENAR CISTELLA                 ║\n" +
                   "║                  3 - MOSTRAR CISTELLA                 ║\n" +
                   "║                  4 - FINALITZAR COMPRA                ║\n" +
                   "║                  5 - AFEGIR SALDO                     ║\n" +
                   "║                  6 - TICKET                           ║\n" +
                   "║                  Q - TANCAR SESSIO                    ║\n" +
                   "║                                                       ║\n" +
                   "╚═══════════════════════════════════════════════════════╝";
            Console.WriteLine(text);

            return text;
        }
        static string MenuIniciText()
        {
            string text;
            text = "╔═══════════════════════════════════════════════════════╗\n" +
                   "║                     INICIAR SESSIO                    ║\n" +
                   "╠═══════════════════════════════════════════════════════╣\n" +
                   "║                                                       ║\n" +
                   "║                      IDENTIFICA'T                     ║\n" +
                   "║                                                       ║\n" +
                   "║                         USUARI                        ║\n" +
                   "║                      ADMINISTRADOR                    ║\n" +
                   "║                         SORTIR                        ║\n" +
                   "║                                                       ║\n" +
                   "╚═══════════════════════════════════════════════════════╝";
            Console.WriteLine(text);

            return text;
        }
        static void ConsolaFons()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
        }
        static bool ValidarOpcio(string opcioS) // Aquest validara si la opció que hem escollit esta entre els valors possibles.
        {
            int opcioN = 0;
            bool validacio = false;
            if ("654321".Contains(opcioS))
            {
                opcioN = Convert.ToInt32(opcioS);
                validacio = true;
                if (opcioN > 6 || opcioN < 1)
                {
                    validacio = false;
                }
            }
            else
            {
                validacio = false;
            }
            return validacio;
        }
        static void RetornCincSegons()
        {
            int contador = 5;
            while (contador >= 0)
            {
                Console.Write("\r");
                Console.Write($"Tornant al menù en {contador} segons...");
                Thread.Sleep(1000);
                contador--;
            }
            return;
        }
        static void RetornTresSegons()
        {
            int contador = 3;
            while (contador >= 0)
            {
                Console.Write("\r");
                Console.Write($"Tornant al menù en {contador} segons...");
                Thread.Sleep(1000);
                contador--;
            }
            return;
        }
        static void BorrarConsola()
        {
            Console.Clear();
            return;
        }
        static void AfegirProducte(string[] productes, double[] preus, ref int nElem, string nouProducte, double nouPreu)
        {
                nElem += 1;
                productes[nElem] = nouProducte;
                preus[nElem] = nouPreu;
        }
        static void MostrarProductes(string[] productes, double[] preus, int nElem)
        {
            Console.WriteLine("Mostrar Taula:");
            for (int i = 0; i <= nElem; i++)
            {
                Console.WriteLine("Taula[{0}] = {1}", i, productes[i]);
                Console.WriteLine("Taula[{0}] = {1}", i, preus[i]);
            }
        }
        static bool ComprovarEspais(string[] productes, double[] preus, ref int nElem, ref bool espais)
        {
            if (nElem == productes.Length - 1)
            {
                espais = false;
            }
            else espais = true;

            return espais;
        }
        static void AmpliarBotiga(ref string[] productes, ref double[] preus, int nElem)
        {
            int valorsAfegir;
            Console.WriteLine("Quants valors vols afegir a la taula?");
            valorsAfegir = Convert.ToInt32(Console.ReadLine());
            string[] productesTemp = new string[productes.Length + valorsAfegir];
            double[] preusTemp = new double[preus.Length + valorsAfegir];
            for (int i = 0;i < productes.Length; i++)
            {
                productesTemp[i] = productes[i];
                preusTemp[i] = preus[i];
            }
            Console.WriteLine($"S'han afegit {valorsAfegir} espais.");
            productes = productesTemp;
            preus = preusTemp;
        }
        static void Modificarpreu(string[] productes, double[] preus, int nElem)
        {
            string producteCercar, sino = ""; double nouPreu = 0; bool noTrobat = false;
            while (!noTrobat)
            {
                Console.WriteLine("Quin es el producte que vols modificar el preu?");
                producteCercar = Console.ReadLine();
                for (int i = 0; i <= nElem; i++)
                {
                    if (productes[i] == producteCercar)
                    {
                        Console.WriteLine($"El producte seleccionat es {productes[i]} es correcte?");
                        sino = Console.ReadLine();
                        if ("SISisi".Contains(sino))
                        {
                            Console.WriteLine($"El preu actual del producte '{productes[i]}' és {preus[i]}, quin es el nou preu?");
                            nouPreu = Convert.ToDouble(Console.ReadLine());
                            preus[i] = nouPreu;
                            Console.WriteLine("S'ha actualitzat el preu correctament");
                            Console.WriteLine("Vols canviar el preu d'algun producte més?");
                            sino = Console.ReadLine();
                            if ("SISisi".Contains(sino))
                            {
                                Console.WriteLine("D'acord");
                            }
                            else if ("NONono".Contains(sino))
                            {
                                Console.WriteLine("D'acord");
                                noTrobat = true;
                            }
                        }
                        else if ("NONono".Contains(sino))
                        {
                            Console.WriteLine("D'acord");
                        }
                    }
                }
                if (!noTrobat)
                {
                    Console.WriteLine("El producte mencionat no existeix, en vols cercar algun altre?");
                    sino = Console.ReadLine();
                    
                    if ("SISisi".Contains(sino))
                    {
                        Console.WriteLine("D'acord");
                    }
                    
                    else if ("NONono".Contains(sino))
                    {
                        Console.WriteLine("D'acord");
                        noTrobat = true;
                    }
                }
            }
        }
        static void ModificarProducte(string[] productes, double[] preus, int nElem)
        {
            string producteCercar, sino = "", producteNou = "", producteAntic = ""; bool noTrobat = false;
            Console.WriteLine("Quin es el producte que vols modificar?");
            producteCercar = Console.ReadLine();
            while (!noTrobat)
            {
                for (int i = 0; i <= nElem; i++)
                {
                    if (productes[i] == producteCercar)
                    {
                        Console.WriteLine($"El producte seleccionat es {productes[i]} es correcte?");
                        sino = Console.ReadLine();
                        if ("SISisi".Contains(sino))
                        {
                            Console.WriteLine($"El producte seleccionat com vols anomenar-lo?");
                            producteNou = Console.ReadLine();
                            producteAntic = productes[i];
                            productes[i] = producteNou;
                        }
                        else if ("NONono".Contains(sino))
                        {
                            Console.WriteLine("D'acord");
                        }
                    }
                    if (!noTrobat)
                    {
                        Console.WriteLine("El producte mencionat no existeix, en vols cercar algun altre?");
                        sino = Console.ReadLine();

                        if ("SISisi".Contains(sino))
                        {
                            Console.WriteLine("D'acord");
                        }

                        else if ("NONono".Contains(sino))
                        {
                            Console.WriteLine("D'acord");
                            noTrobat = true;
                        }
                    }
                }
            }
        }
        static void OrdenarProducteSeleccio(string[] productes, double[] preus, int nElem)
        {
            int posMenor = 0;
            for (int volta = 0; volta <= nElem - 1; volta++)
            {
                posMenor = volta;
                for (int i = volta + 1; i <= nElem; i++)
                {
                    if (productes[posMenor].CompareTo(productes[i]) > 0 ) posMenor = i;
                }
                if (posMenor != volta)
                {
                    string aux = productes[posMenor]; double aux2 = preus[posMenor];
                    productes[posMenor] = productes[volta];
                    productes[volta] = aux;
                    preus[posMenor] = preus[volta];
                    preus[volta] = aux2;
                }
            }
        }
        static void OrdenarPreuSeleccio(string[] productes, double[] preus, int nElem)
        {
            int posMenor = 0;
            for (int volta = 0; volta <= nElem - 1; volta++)
            {
                posMenor = volta;
                for (int i = volta + 1; i <= nElem; i++)
                {
                    if (preus[posMenor] > preus[i]) posMenor = i;
                }
                if (posMenor != volta)
                {
                    string aux = productes[posMenor]; double aux2 = preus[posMenor];
                    productes[posMenor] = productes[volta];
                    productes[volta] = aux;
                    preus[posMenor] = preus[volta];
                    preus[volta] = aux2;
                }
            }
        }
        static void MostrarBotiga(string[] productes, double[] preus, int nElem)
        {
            Console.WriteLine("Llistat de prodcutes i preus:");
            Console.WriteLine("\n");
            for (int i = 0;i <= nElem; i++)
            {
                Console.WriteLine($"{productes[i],-15} : {preus[i],8:F2}");
                Console.WriteLine("\n");
            }
        }
        static void BotigaToString(string[] productes, double[] preus, int nElem)
        {
            string lineaProductes = "";
            for (int i = 0; i <= nElem; i++)
            {
                lineaProductes += $"{productes[i]};{preus[i]} \n";
                lineaProductes += "\n";
                //Console.WriteLine($"{productes[i]};{preus[i]} \r");
            }
            Console.WriteLine(lineaProductes);
            
        }
        static string AfegirProducteCistella(string[] productes, double[] preus, int nElem, string producteComprar, ref string cistella, ref double preuTotal, ref double saldo, int quantitat)
        {
            bool AfegitCorrectament = false;
            double preuQuantitat = 0;
            for (int i = 0;i <= nElem; i++)
            {
                preuQuantitat = preus[i] * quantitat;
                if (preuQuantitat <= saldo)
                {
                    if (productes[i] == producteComprar)
                    {
                        cistella += $"{productes[i],-15} : {preus[i],8:F2}";
                        preuTotal += preuQuantitat;
                        saldo -= preuQuantitat;
                        Console.WriteLine($"Producte '{productes[i]}' amb preu '{preus[i]}' individual, total de {preuQuantitat} afegit correctament a la cistella");
                        AfegitCorrectament = true;
                        
                    }
                }               
            }
            if (!AfegitCorrectament)
            {
                Console.WriteLine("No tens suficient saldo, o aquest producte no existeix.");
            }
            return cistella;
        }
        static string TicketFinal(string cistellaTicet, double preuTotal, int quantitat)
        {
            string text;
            text = "╔═══════════════════════════════════════════════════════╗\n" +
                   "║                     TICKET DE COMPRA                  ║\n" +
                   "╠═══════════════════════════════════════════════════════╣\n" +
                   "║   Producte                PREU          QUANTITAT     ║\n" +
                   "╠═══════════════════════════════════════════════════════╣\n" +
                   "║                                                       ║\n" +
                  $"║ {cistellaTicet}            {quantitat}                ║\n" +
                   "╠═══════════════════════════════════════════════════════╣\n" +
                  $"║ Preu Total: {preuTotal}                               ║\n" +
                   "╚═══════════════════════════════════════════════════════╝";
            Console.WriteLine(text);

            return text;
        }
    }
}