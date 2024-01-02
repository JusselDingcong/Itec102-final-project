using System;
using System.Linq;
class BudgetCalcu {
  static void Main() 
   {
    bool try_Again = true;
    while (try_Again){
    try{
    Console.Clear();	    
    Console.Write("***********************$ Welcome to Money Mate: Your Budget Buddy $***********************\n");
    Console.Write("Enter month today(1-12): ");
    string month = Console.ReadLine();
    Console.Write("Enter the day today: ");
    string day = Console.ReadLine();
    Console.Write("Enter the year today: ");
    string year = Console.ReadLine();
    Console.Write("Add wallet/amount of your budget: ");
    double wallet_amount = Convert.ToDouble(Console.ReadLine());
    Console.Clear();

    Console.WriteLine("\t===================================$ TRANSACTION $===================================");
    Console.WriteLine("Your wallet/amount of your budget: " + wallet_amount);
    Console.WriteLine("Please select to spend your budget below.");
    string [] option = {"Shopping", "Electricity", "Loan", "Water bill", "Wants", "others"};
    double [] cost = new double [option.Length];
   
    for(int i = 0; i < option.Length; i++)
    {
        Console.WriteLine($"[{i}] {option[i]}");
    }
   
	int[] chosen_op;
   bool validInput = false;

   do
   {
    Console.Write("Choose your options(separate by space): ");
       string[] inputs = Console.ReadLine().Split(' ');
       chosen_op = new int[inputs.Length];
       validInput = true;
        for(int i = 0; i < inputs.Length; i++) 
       {
           if (!int.TryParse(inputs[i], out chosen_op[i]) || chosen_op[i] < 0 || chosen_op[i] >= option.Length) 
            {
               Console.Write("Invalid input. ");
               validInput = false;
               break;
            }
        }
    } while (!validInput);

   
    foreach(int click in chosen_op)
    {
        double amount = 0; 
        bool valid = false;
        while (!valid) 
        {
            Console.Write($"Enter amount for {option[click]}: "); 
            string input = Console.ReadLine(); 
            if (double.TryParse(input, out amount)) 
            {
                valid = true; 
            }
            else 
            {
                Console.WriteLine("The input string '{0}' was not in a correct format.", input);
            }
        }
       
        cost[click] = amount; 
    }
 
    double total = cost.Sum();

    double spend= wallet_amount - total;
    
    Console.Clear();
    
    Console.WriteLine("\t\n\btransacting please wait................");
    Console.WriteLine("\t===================================$ TRANSACTION RECEIPT $===================================");
    Date(month, day, year);
    Console.WriteLine("Wallet: "+ wallet_amount);
    Console.WriteLine($"Total calculated of spend: {total}");
    Console.WriteLine($"Remaining wallet: "+ spend);
    int[] indices = Enumerable.Range(0, option.Length).ToArray();
    Array.Sort(indices, (x, y) => cost[y].CompareTo(cost[x]));

    Console.WriteLine("Expense ranked by highest spend");
     foreach (int index in indices)
           {
          Console.WriteLine($"{option[index]}: {cost[index]}");
           }
        }
              catch (Exception e)
               { 
             Console.WriteLine(e.Message);
              }
              finally{
                 Console.Write("Would you like to try again? (y/Y) / pres any key to close: ");
                 string yes = Console.ReadLine();
                  yes = yes.ToUpper();
                   if (yes == "Y")
                   {
                   try_Again= true;
                   }
                     else
                   {
                     try_Again = false;
	       Console.Clear();
               Console.WriteLine("Thank u for using me, comeback again next time:>!");
                   }
                }
            }
          }
    static void Date(string month, string day, string year)
       {
          switch(month){
          case "1":
          Console.WriteLine("Date: "+ "January " + day+ ", "+ year);
          break;
          case "2":
          Console.WriteLine("Date: "+ "February "+ day+ ", "+ year);
          break;
          case "3":
          Console.WriteLine("Date: "+ "March "+ day+ ", "+ year);
          break;
          case "4":
          Console.WriteLine("Date: "+  "April "+ day+ ", "+ year);
          break;
          case "5":
          Console.WriteLine("Date: "+  "May "+ day+ ", "+ year);
          break;
          case "6":
          Console.WriteLine("Date: "+  "June "+ day+ ", "+ year);
          break;
          case "7":
          Console.WriteLine("Date: "+  "July "+ day+ ", "+ year);
          break;
          case "8":
          Console.WriteLine("Date: "+  "August "+ day+ ", "+ year);
          break;
          case "9":
          Console.WriteLine("Date: "+  "September "+ day+ ", "+ year);
          break;
          case "10":
          Console.WriteLine("Date: "+  "October "+ day+ ", "+ year);
          break;
          case "11":
          Console.WriteLine("Date: "+  "November "+ day+ " "+ year);
          break;
          case "12":
          Console.WriteLine("Date: "+  "December "+ day+ " "+ year);
          break;
        }
    }
 }



