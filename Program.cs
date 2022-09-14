/*
Hunting the Manticore - BOSS BATTLE
:: Part 1 Project Capstone ::
*/

// See ReadMe for details

Console.Title = "Hunting the Manticore";
Console.Clear();

// Declare / Init Variables
int currentRound = 1;

int manticoreHP = 10;
int cityHP = 15;

string targetName = "The Manticore";
int manticorePosition;

// Game start
manticorePosition = PreGame();
GameRound();

// Get Manticore starting position from Player 1
int PreGame()
{
    Console.Write("PLAYER ONE: Please enter the Manticore's position (0 - 100): ");
    int position = Convert.ToInt32(Console.ReadLine());
    Console.Clear();
    return position;
}

// Primary game loop
void GameRound()
{
    while (cityHP > 0 || manticoreHP > 0)
    {
        // Display round start stats
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine($"STATUS | Round: {currentRound} City HP: {cityHP} Manticore HP: {manticoreHP}");
        Console.ForegroundColor = ConsoleColor.DarkGray;

        // Display expected cannon damage type
        CannonDamageMessage(currentRound);

        // Player 2 enters the desired cannon range
        Console.Write("Please enter the desired range for the cannon: ");
        int cannonRange = Convert.ToInt32(Console.ReadLine());

        // Display if the the cannon hit or missed
        CannonFireResult(cannonRange);

        // Resolve cannon fire damage
        ResolveManticoreDamage(CannonDamage(currentRound), cannonRange);
        ManticoreHealthCheck();
        if (manticoreHP <= 0) return; // Potentially exit game loop
        
        // Resolve City HP changes
        CityHealthCheck();
        if (cityHP <= 0) return;

        currentRound++;
    }
}

// Display messaging for expected damage type
void CannonDamageMessage(int round)
{
    string cannonExpectedDamagePrefix = "The cannon is expected to deal ";
    string cannonExpectedDamageSuffix = " damage this round.";

    if (round % 3 == 0 && round % 5 != 0)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(cannonExpectedDamagePrefix + "3 fire" + cannonExpectedDamageSuffix);
        Console.ForegroundColor = ConsoleColor.DarkGray;
    }
    else if (round % 5 == 0 && round % 3 != 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(cannonExpectedDamagePrefix + "3 electric" + cannonExpectedDamageSuffix);
        Console.ForegroundColor = ConsoleColor.DarkGray;
    }
    else if (round % 3 == 0 && round % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(cannonExpectedDamagePrefix + "10 Electrifyre" + cannonExpectedDamageSuffix);
        Console.ForegroundColor = ConsoleColor.DarkGray;
    }
    else
    {
        Console.WriteLine(cannonExpectedDamagePrefix + "1 normal" + cannonExpectedDamageSuffix);
    }
}

// Return damage type
string CannonDamage(int round)
{
    if (round % 3 == 0 && round % 5 != 0)
    {
        return "fire";
    }
    else if (round % 5 == 0 && round % 3 != 0)
    {
        return "electric";
    }
    else if (round % 3 == 0 && round % 5 == 0)
    {
        return "electrifyre";
    }
    else
    {
        return "normal";
    }
}

// Display if the cannon hit The Manticore or not
void CannonFireResult(int range)
{
    if (range < manticorePosition)
    {
        Console.WriteLine($"The round FELL SHORT of {targetName}.");
    }
    else if (range > manticorePosition)
    {
        Console.WriteLine($"The round OVERSHOT {targetName}.");
    }
    else
    {
        Console.WriteLine($"The round was a DIRECT HIT!!");
    }
}

// Resolve damage against Manticore if direct hit
void ResolveManticoreDamage(string cannonRound, int cannonRange)
{
    if (cannonRange == manticorePosition)
    {
        switch (cannonRound)
        {
            case "fire":
                manticoreHP -= 3;
                break;
            case "electric":
                manticoreHP -= 3;
                break;
            case "electrifyre":
                manticoreHP -= 10;
                break;
            case "normal":
                manticoreHP--;
                break;
            default:
                break;
        }
    }
}

// Write out victory message if Manticore is destroyed
void ManticoreHealthCheck()
{
    if (manticoreHP <= 0)
    {
        Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!!");
    }
}

// City health goes down every round
void CityHealthCheck()
{
    cityHP--;
    if (cityHP <= 0)
    {
        Console.WriteLine("The Manticore and Uncoded One have prevailed. Game over.");
    }
}