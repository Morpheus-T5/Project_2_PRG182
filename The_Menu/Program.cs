// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

//• The application should make use of Enum menus. [10]
//• Make use of methods to generate new menus. [10]
//• The application should allow you to order various products. [10]
//• It should keep track of what you have ordered as well as how much it costs. [10]
//• A person should be able to check out their order and if they do it should display the items ordered as well as the total price due. [5]
//• The application should loop and after checkout, it should reset your cart.It should also give you the option to close the application.


// Dictionary that will store all purchase information, string is the name of the item purchased and double is the price of the item purchase


// calling the main menu function that will initiate the program
Menu();

Console.ReadKey();

// Method that will display the first menu of the program
static void Menu()
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Welcome to Satiate Café!\n");
    Console.WriteLine("========================");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Main Menu\n");
    

    // loop that is pulling values from the menu enum to display the options
    foreach (MainMenu item in Enum.GetValues(typeof(MainMenu)))
    {
        Console.WriteLine("{0}. {1}", (int)item, item.ToString().Replace("_", " "));
    }

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("========================");
    Console.ForegroundColor = ConsoleColor.White;

    string selection = Console.ReadLine();

    // switchcase to determine what choice the user has made and what needs be executed next
    switch (selection)
    {
        case "1":
            MenuBreakfast();
            break;
        case "2":
            MenuBurgers();
            break;
        case "3":
            MenuSideExtras();
            break;
        case "4":
            MenuMilkshakes();
            break;
        case "5":
            MenuColdDrinks();
            break;
        case "6":
            Checkout();
            break;
        case "7":
            Thread.Sleep(1500);
            Console.WriteLine("Thank you for visiting! Please call again!");
            Thread.Sleep(2000);
            Environment.Exit(0);
            break;
        default: // defualt in the case that a non-existing option is chosen, redisplay the menu
            Menu();
            Console.WriteLine("");
            break;
    }

}

// method that will call a submenu for the user to pick a item to purchase
static void MenuBreakfast()
{
    Dictionary<Breakfast, double> prices;
    // dictionary that stores a key and value, the key being the value of an enuma item, and the value being the corresponding price of that enum item
    // used for display and calculations with the price
    prices = new Dictionary<Breakfast, double>
    {
        { Breakfast.Basic_Omlette_Cheese_Tomato, 45.20},
        { Breakfast.Croissant_With_Scrambled_Egg, 50.90 },
        { Breakfast.Toast_Bacon_Egg, 40.20 },
    };

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\n===========================================");
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("Breakfast Menu:");

    // for loop displaying the items that can be purchased along with their price
    foreach (Breakfast item in Enum.GetValues(typeof(Breakfast)))
    {
        double price = prices[item];
        Console.WriteLine("{0}. {1}: R{2}", (int)item, item.ToString().Replace("_", " "), Math.Round(price, 2).ToString("0.00"));
    }
    Console.WriteLine("4. Back");

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("===========================================");
    Console.ForegroundColor = ConsoleColor.White;

    string choice = Console.ReadLine();
    //switchcase to determine what item has been chosen and to begin calculating how many items and the price for for the items, aswell as adding the purchase to the cart
    switch (choice)
    {
        case "1":
            OrderItem("Basic_Omlette_Cheese_Tomato",45.20);
            Menu();
            break;

        case "2":
            OrderItem("Croissant_With_Scrambled_Egg", 50.90);
            Menu();
            break;

        case "3":
            OrderItem("Toast_Bacon_Egg", 40.20);
            Menu();
            break;

        case "4":
            Console.WriteLine("");
            Menu();
            break;

        default:
            MenuBreakfast();
            break;
    }

}

static void MenuBurgers()
{
    Dictionary<Burgers, double> prices;

    prices = new Dictionary<Burgers, double>
    {
        { Burgers.Classic_Hamburger, 50.20},
        { Burgers.Cheese_Burger, 55.50 },
        { Burgers.Bacon_Burger, 60.60 },
        { Burgers.Chicken_Burger, 50.20 },
    };

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\n===========================================");
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("Burger Menu:");

    foreach (Burgers item in Enum.GetValues(typeof(Burgers)))
    {
        double price = prices[item];
        Console.WriteLine("{0}. {1}: R{2}", (int)item, item.ToString().Replace("_", " "), Math.Round(price, 2).ToString("0.00"));
    }
    Console.WriteLine("5. Back");

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("===========================================");
    Console.ForegroundColor = ConsoleColor.White;

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            OrderItem("Classic_Hamburger", 50.20);
            Menu();
            break;

        case "2":
            OrderItem("Cheese_Burger", 55.50);
            Menu();
            break;

        case "3":
            OrderItem("Bacon_Burger", 60.60);
            Menu();
            break;

        case "4":
            OrderItem("Chicken_Burger", 50.20);
            Menu();
            break;

        case "5":
            Console.WriteLine("");
            Menu();
            break;
        default:
            MenuBurgers();
            break;
    }

}

static void MenuSideExtras()
{
    Dictionary<Sides_Extras, double> prices;

    prices = new Dictionary<Sides_Extras, double>
    {
        { Sides_Extras.Small_Fries, 15.50 },
        { Sides_Extras.Medium_Fries, 20.90},
        { Sides_Extras.Large_Fries, 30.90 },
        { Sides_Extras.Greek_Salad, 35.50 },
        { Sides_Extras.Veg_Of_The_Day, 35.50 },
    };

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\n===========================================");
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("Sides/Extras Menu:");

    foreach (Sides_Extras item in Enum.GetValues(typeof(Sides_Extras)))
    {
        double price = prices[item];
        Console.WriteLine("{0}. {1}: R{2}", (int)item, item.ToString().Replace("_", " "), Math.Round(price, 2).ToString("0.00"));
    }
    Console.WriteLine("6. Back");

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("===========================================");
    Console.ForegroundColor = ConsoleColor.White;

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            OrderItem("Small_Fries", 15.50);
            Menu();
            break;

        case "2":
            OrderItem("Medium_Fries", 20.90);
            Menu();
            break;

        case "3":
            OrderItem("Large_Fries", 30.90);
            Menu();
            break;

        case "4":
            OrderItem("Greek_Salad", 35.50);
            Menu();
            break;

        case "5":
            OrderItem("Veg_Of_The_Day", 35.50);
            Menu();
            break;

        case "6":
            Console.WriteLine("");
            Menu();
            break;

        default:
            MenuSideExtras();
            break;
    }

}

static void MenuMilkshakes()
{
    Dictionary<Milkshakes, double> prices;

    prices = new Dictionary<Milkshakes, double>
    {
        { Milkshakes.Strawberry, 35.90 },
        { Milkshakes.Oreo, 45.50},
        { Milkshakes.Chocolate, 35.90 },
        { Milkshakes.Peanut_butter, 45.50 },
    };

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\n===========================================");
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("Milkshake Menu:");

    foreach (Milkshakes item in Enum.GetValues(typeof(Milkshakes)))
    {
        double price = prices[item];
        Console.WriteLine("{0}. {1}: R{2}", (int)item, item.ToString().Replace("_", " "), Math.Round(price, 2).ToString("0.00"));
    }
    Console.WriteLine("5. Back");

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("===========================================");
    Console.ForegroundColor = ConsoleColor.White;

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            OrderItem("Strawberry", 35.90);
            Menu();
            break;
        case "2":
            OrderItem("Oreo", 45.50);
            Menu();
            break;
        case "3":
            OrderItem("Chocolate", 35.90);
            Menu();
            break;
        case "4":
            OrderItem("Peanut_butter", 45.50);
            Menu();
            break;
        case "5":
            Console.WriteLine("");
            Menu();
            break;
        default:
            MenuMilkshakes();
            break;
    }

}

static void MenuColdDrinks()
{
    Dictionary<Colddrinks, double> prices;

    prices = new Dictionary<Colddrinks, double>
    {
        { Colddrinks.Coke, 15.50 },
        { Colddrinks.Fanta, 15.50},
        { Colddrinks.Apple_Juice, 12.90 },
        { Colddrinks.Sprite, 15.50 },
        { Colddrinks.Water, 10.50}
    };

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\n===========================================");
    Console.ForegroundColor = ConsoleColor.White;

    Console.WriteLine("Cold drinks Menu:");

    foreach (Colddrinks item in Enum.GetValues(typeof(Colddrinks)))
    {
        double price = prices[item];
        Console.WriteLine("{0}. {1}: R{2}", (int)item, item.ToString().Replace("_", " "), Math.Round(price, 2).ToString("0.00"));
    }
    Console.WriteLine("6. Back");

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("===========================================");
    Console.ForegroundColor = ConsoleColor.White;

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            OrderItem("Coke", 15.50);
            Menu();
            break;

        case "2":
            OrderItem("Fanta", 15.50);
            Menu();
            break;

        case "3":
            OrderItem("Apple_Juice", 12.90);
            Menu();
            break;

        case "4":
            OrderItem("Sprite", 15.50);
            Menu();
            break;

        case "5":
            OrderItem("Water", 10.50);
            Menu();
            break;

        case "6":
            Console.WriteLine("");
            Menu();
            break;

        default:
            MenuColdDrinks();
            break;
    }

}

static void OrderItem(string item, double price) // used to place all the items ordered in a dictionary
                                                 // that be called to print the menu
{
    Console.WriteLine("");
    Console.WriteLine("How many of the {0} would you like?", item.Replace("_", " "));
    int quantity = Convert.ToInt32(Console.ReadLine());
    key++;
    Item.Add(key, item);
    Quantity.Add(key, quantity);
    Price.Add(key, price);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("\n=======================================================");
    Console.WriteLine("{0} of the {1} has been ordered:", quantity, item.Replace("_", " "));
    Console.WriteLine("=======================================================\n");
    Console.ForegroundColor = ConsoleColor.White;
}

//used to display all items ordered as well as their quantity and price
static void Checkout()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\n====================");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Welcome to Checkout:");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("====================\n");
    Console.ForegroundColor = ConsoleColor.White; ;
    double total = 0;
    Console.WriteLine("Ordered Items:");

    foreach (var item in Item)
    {
        int quantity = Quantity[item.Key];
        double price = Price[item.Key];
        double itemTotal = quantity * price;

        Console.WriteLine("{0} x {1}: R{2}", quantity, item.Value.Replace("_", " "), itemTotal.ToString("0.00"));

        total += itemTotal;
    }

    Console.WriteLine("\nTotal Price Due: R{0}", total.ToString("0.00"));

    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("\n====================");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("1. Back to Main Menu");
    Console.WriteLine("2. Close Application");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("====================");
    Console.ForegroundColor = ConsoleColor.White;
    //switch case used to give the user the option to go back to main menu to start over which will clear the cart
    //user also has the option to close the program
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            ResetCart();
            Menu();
            break;

        case "2":
            Thread.Sleep(1500);
            Console.WriteLine("Thank you for visiting! Please call again!");
            Thread.Sleep(2000);
            Environment.Exit(0);
            break;

        default:
            Console.WriteLine("");
            Checkout();
            break;
    }
}
//this method is used to reset the cart when called
static void ResetCart()
{
    Item.Clear();
    Quantity.Clear();
    Price.Clear();
}

// enums that are used to display menu's
public enum MainMenu
{
    Breakfast = 1,
    Burgers,
    Sides_Extras,
    Milkshakes,
    Cold_drinks,
    Proceed_to_Checkout,
    Exit
}

public enum Breakfast
{
    Basic_Omlette_Cheese_Tomato = 1,
    Croissant_With_Scrambled_Egg,
    Toast_Bacon_Egg
}
public enum Burgers
{
    Classic_Hamburger = 1,
    Cheese_Burger,
    Bacon_Burger,
    Chicken_Burger
}

public enum Sides_Extras
{
    Small_Fries = 1,
    Medium_Fries,
    Large_Fries,
    Greek_Salad,
    Veg_Of_The_Day
}

public enum Milkshakes
{
    Strawberry = 1,
    Oreo,
    Chocolate,
    Peanut_butter
}

public enum Colddrinks
{
    Coke = 1,
    Fanta,
    Apple_Juice,
    Sprite,
    Water
}

public partial class Program
{
    static int key = 0;//will be used as a unique identifier for all the dictionaries
    static Dictionary<int, string> Item = new Dictionary<int, string>();// used to store each item which was selected
    static Dictionary<int, int> Quantity = new Dictionary<int, int>();// used to store the amount of said item
    static Dictionary<int, double> Price = new Dictionary<int, double>();//used to store the price of one of the items

}