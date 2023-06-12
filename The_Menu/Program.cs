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
Dictionary<string, double> cart = new Dictionary<string, double>();

// calling the main menu function that will initiate the program
Menu(cart);

Console.ReadKey();

// Method that will display the first menu of the program
static void Menu(Dictionary<string, double> cart)
{
    Console.WriteLine("Welcome to Satiate Café!\n\nMain Menu\n");

    // loop that is puliing values from the menu enum to display the options
    foreach (MainMenu item in Enum.GetValues(typeof(MainMenu)))
    {
        Console.WriteLine("{0}. {1}", (int)item, item.ToString().Replace("_", " "));
    }

    string selection = Console.ReadLine();

    // switchcase to determine what choice the user has made and what needs be executed next
    switch (selection)
    {
        case "1":
            cart = MenuBreakfast(cart);
            break;
        case "2":
            cart = MenuBurgers(cart);
            break;
        case "3":
            cart = MenuSideExtras(cart);
            break;
        case "4":
            cart = MenuMilkshakes(cart);
            break;
        case "5":
            cart = MenuColdDrinks(cart);
            break;
        case "6:":
            Checkout(cart);
            break;
        case "7":
            Thread.Sleep(1500);
            Console.WriteLine("Thank you for visiting! Please call again!");
            Thread.Sleep(2000);
            System.Environment.Exit(0);
            break;
        default: // defualt in the case that an non existing option is chosen to redisplay the menu
            Menu(cart);
            Console.WriteLine("");
            break;
    }

}

// method that will call a submenu for the user to pick a item to purchase
static Dictionary<string, double> MenuBreakfast(Dictionary<string, double> cart)
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

    Console.WriteLine("\nBreakfast Menu:");

    // for loop displaying the items that can be purchased along with their price
    foreach (Breakfast item in Enum.GetValues(typeof(Breakfast)))
    {
        double price = prices[item];
        Console.WriteLine("{0}. {1}: R{2}", (int)item, item.ToString().Replace("_", " "), Math.Round(price, 2).ToString("0.00"));
    }
    Console.WriteLine("4. Back");

    string choice = Console.ReadLine();
    //switchcase to determine what item has been chosen and to begin calculating how many items and the price for for the items, aswell as adding the purchase to the cart
    switch (choice)
    {
        case "1":

            break;
        case "2":

            break;
        case "3":

            break;
        case "4":
            Console.WriteLine("");
            Menu(cart);
            break;
        default:
            MenuBreakfast(cart);
            break;
    }

    return cart;
}

static Dictionary<string, double> MenuBurgers(Dictionary<string, double> cart)
{
    Dictionary<Burgers, double> prices;

    prices = new Dictionary<Burgers, double>
    {
        { Burgers.Classic_Hamburger, 50.20},
        { Burgers.Cheese_Burger, 55.50 },
        { Burgers.Bacon_Burger, 60.60 },
        { Burgers.Chicken_Burger, 50.20 },
    };

    Console.WriteLine("\nBurger Menu:");

    foreach (Burgers item in Enum.GetValues(typeof(Burgers)))
    {
        double price = prices[item];
        Console.WriteLine("{0}. {1}: R{2}", (int)item, item.ToString().Replace("_", " "), Math.Round(price, 2).ToString("0.00"));
    }
    Console.WriteLine("5. Back");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":

            break;
        case "2":

            break;
        case "3":

            break;
        case "4":

            break;
        case "5":
            Console.WriteLine("");
            Menu(cart);
            break;
        default:
            MenuBurgers(cart);
            break;
    }

    return cart;
}

static Dictionary<string, double> MenuSideExtras(Dictionary<string, double> cart)
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

    Console.WriteLine("\nSides/Extras Menu:");

    foreach (Sides_Extras item in Enum.GetValues(typeof(Sides_Extras)))
    {
        double price = prices[item];
        Console.WriteLine("{0}. {1}: R{2}", (int)item, item.ToString().Replace("_", " "), Math.Round(price, 2).ToString("0.00"));
    }
    Console.WriteLine("6. Back");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":

            break;
        case "2":

            break;
        case "3":

            break;
        case "4":

            break;
        case "5":

            break;
        case "6":
            Console.WriteLine("");
            Menu(cart);
            break;
        default:
            MenuSideExtras(cart);
            break;
    }

    return cart;
}

static Dictionary<string, double> MenuMilkshakes(Dictionary<string, double> cart)
{
    Dictionary<Milkshakes, double> prices;

    prices = new Dictionary<Milkshakes, double>
    {
        { Milkshakes.Strawberry, 35.90 },
        { Milkshakes.Oreo, 45.50},
        { Milkshakes.Chocolate, 35.90 },
        { Milkshakes.Peanut_butter, 45.50 },
    };

    Console.WriteLine("\nMilkshake Menu:");

    foreach (Milkshakes item in Enum.GetValues(typeof(Milkshakes)))
    {
        double price = prices[item];
        Console.WriteLine("{0}. {1}: R{2}", (int)item, item.ToString().Replace("_", " "), Math.Round(price, 2).ToString("0.00"));
    }
    Console.WriteLine("5. Back");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":

            break;
        case "2":

            break;
        case "3":

            break;
        case "4":

            break;
        case "5":
            Console.WriteLine("");
            Menu(cart);
            break;
        default:
            MenuMilkshakes(cart);
            break;
    }

    return cart;
}

static Dictionary<string, double> MenuColdDrinks(Dictionary<string, double> cart)
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

    Console.WriteLine("\nCold drinks Menu:");

    foreach (Colddrinks item in Enum.GetValues(typeof(Colddrinks)))
    {
        double price = prices[item];
        Console.WriteLine("{0}. {1}: R{2}", (int)item, item.ToString().Replace("_", " "), Math.Round(price, 2).ToString("0.00"));
    }
    Console.WriteLine("6. Back");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":

            break;
        case "2":

            break;
        case "3":

            break;
        case "4":

            break;
        case "5":

            break;
        case "6":
            Console.WriteLine("");
            Menu(cart);
            break;
        default:
            MenuColdDrinks(cart);
            break;
    }

    return cart;
}

static void Checkout(Dictionary<string, double> cart)
{

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