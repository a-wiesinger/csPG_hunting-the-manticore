/*
Hunting the Manticore - BOSS BATTLE
:: Part 1 Project Capstone ::
*/

// Criteria:
//
// *** Est. game start state with Manticore HP at 10, City at 15
// *** Ask the first player to enter the Manticore's starting position ( 0 - 100 )
// *** Clear screen
// Game loop runs until either the City or the Manticore's HP drops to 0 (or below)
// *** Before player 2's round starts, display the following:
    // - round number
    // - City HP
    // - Manticore HP
// *** Compute cannon damage:
    // - (if round number % 3 || 5 == 0 then dmg = 3)
        // 3 = Fire Blast
        // 5 = Electric Blast
    // - (if round number % 3 && 5 == 0 then dmg = 10) (Electrifyre Blast)
    // - Use different colors for the different shot types
    // - Tell the player what the upcoming damage will be
// *** - Get target range from player 2 ( 0 - 100 )
    // Tell player 2 if they under or overshot
    // Resolve effect of shot (dmg resolves on Manticore possibly)
// TODO - If Manticore still lives, the City suffers -1 HP
// Advance to next round
// When Manticore or City health drops to 0, the game is over

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
    // Display round start stats
    Console.WriteLine("------------------------------------------------------");
    Console.WriteLine($"STATUS | Round: {currentRound} City HP: {cityHP} Manticore HP: {manticoreHP}");

    // Compute cannon damage
    Console.WriteLine($"The cannon is expected to deal {CannonDamage(currentRound)} damage this round.");

    // Player 2 enters the desired cannon range
    Console.Write("Please enter the desired range for the cannon: ");
    int cannonRange = Convert.ToInt32(Console.ReadLine());

    // Display if the the cannon hit or missed
    // If hit, will then calculate damage to The Manticore
    CannonFireResult(cannonRange);

    // Resolve cannon fire damage
    

}

string CannonDamage(int round)
{
    if (round % 3 == 0 && round % 5 != 0)
    {
        return "3 fire";
    }
    else if (round % 5 == 0 && round % 3 != 0)
    {
        return "3 electric";
    }
    else if (round % 3 == 0 && round % 5 == 0)
    {
        return "10 Electrifyre";
    }
    else
    {
        return "1 normal";
    }
}

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
        ResolveManticoreDamage(CannonDamage(currentRound)); // cannon fire damage
    }
}

void ResolveManticoreDamage(string cannonRound)
{
    switch (cannonRound)
    {
        case "3 fire":
            manticoreHP -= 3;
            break;
        case "3 electric":
            manticoreHP -= 3;
            break;
        case "10 Electrifyre":
            manticoreHP -= 10;
            break;
        case "1 normal":
            manticoreHP--;
            break;
        default:
            break;
    }
}
